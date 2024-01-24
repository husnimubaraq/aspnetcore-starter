using Volo.Abp.Application.Dtos;

namespace Husni.ChatApp.Articles;

public class GetArticleListDto : PagedAndSortedResultRequestDto
{
    public string? Filter { get; set; }
}