using System.ComponentModel.DataAnnotations;

namespace Husni.ChatApp.Articles;

public class UpdateArticleDto
{
    [Required]
    [StringLength(128)]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Slug { get; set; }
}