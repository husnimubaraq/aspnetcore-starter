using System;
using System.ComponentModel.DataAnnotations;

namespace Husni.ChatApp.Articles;

public class CreateUpdateArticleDto
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Slug { get; set; }
}
