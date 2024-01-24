using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Blazorise;
using Blazorise.DataGrid;
using Husni.ChatApp.Articles;
using Husni.ChatApp.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;

namespace Husni.ChatApp.Blazor.Pages;

public partial class Articles
{
    private IReadOnlyList<ArticleDto> ArticleList { get; set; }

    private int PageSize { get; } = LimitedResultRequestDto.DefaultMaxResultCount;
    private int CurrentPage { get; set; }
    private string CurrentSorting { get; set; }
    private int TotalCount { get; set; }

    private bool CanCreateArticle { get; set; }
    private bool CanEditArticle { get; set; }
    private bool CanDeleteArticle { get; set; }

    private CreateArticleDto NewArticle { get; set; }

    private int EditingArticleId { get; set; }
    private UpdateArticleDto EditingArticle { get; set; }

    private Modal CreateArticleModal { get; set; }
    private bool CreateArticleDialog { get; set; }
    private Modal EditArticleModal { get; set; }
    private bool EditArticleDialog { get; set; }

    private Validations CreateValidationsRef;
    private Validations EditValidationsRef;
    private Annotation annotation = new Annotation();

    public Articles()
    {
        NewArticle = new CreateArticleDto();
        EditingArticle = new UpdateArticleDto();
    }

    protected override async Task OnInitializedAsync()
    {
        await SetPermissionsAsync();
    }

    private async Task SetPermissionsAsync()
    {
        CanCreateArticle = await AuthorizationService
            .IsGrantedAsync(ChatAppPermissions.Article.Create);
        CanEditArticle = await AuthorizationService
            .IsGrantedAsync(ChatAppPermissions.Article.Edit);
        CanDeleteArticle = await AuthorizationService
            .IsGrantedAsync(ChatAppPermissions.Article.Delete);
    }

    private async Task GetArticlesAsync()
    {
        var result = await ArticleAppService.GetListAsync(
            new GetArticleListDto
            {
                MaxResultCount = PageSize,
                SkipCount = CurrentPage * PageSize,
                Sorting = CurrentSorting
            }
        );

        ArticleList = result.Items;
        TotalCount = (int) result.TotalCount;
    }

    private async Task OnDataGridReadAsync(DataGridReadDataEventArgs<ArticleDto> e)
    {
        CurrentSorting = e.Columns
            .Where(c => c.SortDirection != SortDirection.Default)
            .Select(c => c.Field + (c.SortDirection == SortDirection.Descending ? " DESC" : ""))
            .JoinAsString(",");
        CurrentPage = e.Page - 1;

        await GetArticlesAsync();

        await InvokeAsync(StateHasChanged);
    }

    private void OpenCreateArticleModal()
    {
        CreateValidationsRef.ClearAll();

        NewArticle = new CreateArticleDto();
        CreateArticleModal.Show();
        CreateArticleDialog = true;
    }

    private void CloseCreateArticleModal()
    {
        CreateArticleModal.Hide();
        CreateArticleDialog = false;
    }

    private void OpenEditArticleModal(ArticleDto article)
    {
        EditValidationsRef.ClearAll();

        EditingArticleId = article.Id;
        EditingArticle = ObjectMapper.Map<ArticleDto, UpdateArticleDto>(article);
        EditArticleModal.Show();
        EditArticleDialog = true;
    }

    private async Task DeleteArticleAsync(ArticleDto article)
    {
        var confirmMessage = L["ArticleDeletionConfirmationMessage", article.Title];
        if(!await Message.Confirm(confirmMessage))
        {
            return;
        }

        await ArticleAppService.DeleteAsync(article.Id);
        await GetArticlesAsync();
    }

    private void CloseEditArticleModal()
    {
        EditArticleModal.Hide();
        EditArticleDialog = false;
    }

    private async Task CreateArticleAsync()
    {
        if(await CreateValidationsRef.ValidateAll())
        {
            await ArticleAppService.CreateAsync(NewArticle);
            await GetArticlesAsync();
            CreateArticleModal.Hide();
            CreateArticleDialog = false;
        }
    }

    private async Task UpdateArticleAsync()
    {
        if(await EditValidationsRef.ValidateAll())
        {
            await ArticleAppService.UpdateAsync(EditingArticleId, EditingArticle);
            await GetArticlesAsync();
            EditArticleModal.Hide();
            EditArticleDialog = false;
        }
    }

    public class Annotation
    {
        [Required(ErrorMessage = "The title field is required.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "The slug field is required.")]
        public string Slug { get; set; }
        [Required(ErrorMessage = "The description field is required.")]
        public string Description { get; set; }
    }
}