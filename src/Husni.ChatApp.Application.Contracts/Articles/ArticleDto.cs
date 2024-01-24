using Volo.Abp.Application.Dtos;

namespace Husni.ChatApp.Articles;

public class ArticleDto : EntityDto<int>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
}
