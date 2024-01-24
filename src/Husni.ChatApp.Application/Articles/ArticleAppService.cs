using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Husni.ChatApp.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Husni.ChatApp.Articles;

[Authorize(ChatAppPermissions.Article.Default)]
public class ArticleAppService : ChatAppAppService, IArticleAppService
{
    private readonly IArticleRepository _articleRepository;
    private readonly ArticleManager _articleManager;
    public ArticleAppService(
        IArticleRepository articleRepository,
        ArticleManager articleManager
    )
    {
        _articleRepository = articleRepository;
        _articleManager = articleManager;
    }
    [Authorize(ChatAppPermissions.Article.Create)]

    public async Task<ArticleDto> CreateAsync(CreateArticleDto input)
    {
        var article = await _articleManager.CreateAsync(
            input.Title,
            input.Description,
            input.Slug
        );

        await _articleRepository.InsertAsync(article);

        return ObjectMapper.Map<Article, ArticleDto>(article);
    }

    [Authorize(ChatAppPermissions.Article.Delete)]
    public async Task DeleteAsync(int id)
    {
        await _articleRepository.DeleteAsync(id);
    }

    public async Task<ArticleDto> GetAsync(int id)
    {
        var article = await _articleRepository.GetAsync(id);
        return ObjectMapper.Map<Article, ArticleDto>(article);
    }

    public async Task<PagedResultDto<ArticleDto>> GetListAsync(GetArticleListDto input)
    {
        if(input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = nameof(Article.Title);
        }

        var articles = await _articleRepository.GetListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting,
            input.Filter
        );

        var totalCount = input.Filter == null
            ? await _articleRepository.CountAsync()
            : await _articleRepository.CountAsync(
                article => article.Title.Contains(input.Filter)
            );

        return new PagedResultDto<ArticleDto>(
            totalCount,
            ObjectMapper.Map<List<Article>, List<ArticleDto>>(articles)
        );
    }
    [Authorize(ChatAppPermissions.Article.Edit)]
    public async Task UpdateAsync(int id, UpdateArticleDto input)
    {
        var article = await _articleRepository.GetAsync(id);

        if(article.Slug != input.Slug)
        {
            await _articleManager.ChangeSlugAsync(article, input.Slug);
        }

        article.Title = input.Title;
        article.Description = input.Description;

        await _articleRepository.UpdateAsync(article);
    }
}
