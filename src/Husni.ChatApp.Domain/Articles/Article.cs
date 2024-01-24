using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Husni.ChatApp.Articles;

[Table("articles")]
public class Article : Entity<int>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }
    [Column("title")]
    public string Title { get; set; }
    [Column("description")]
    public string Description { get; set; }
    [Column("slug")]
    public string Slug { get; set; }
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    [Column("created_by")]
    public int CreatedBy { get; set; }
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
    [Column("updated_by")]
    public int UpdatedBy { get; set; }

    private Article()
    {

    }

    internal Article(
        [NotNull] string title,
        [NotNull] string description,
        [NotNull] string slug
    )
    {
        SetSlug(slug);
        Title = title;
        Description = description;
    }

    internal Article ChangeSlug([NotNull] string slug)
    {
        SetSlug(slug);
        return this;
    }

    private void SetSlug([NotNull] string slug)
    {
        Slug = Check.NotNullOrWhiteSpace(
            slug,
            nameof(slug),
            maxLength: 128
        );
    }
}
