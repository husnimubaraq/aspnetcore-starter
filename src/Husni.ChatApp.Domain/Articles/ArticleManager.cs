using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Husni.ChatApp.Articles;

public class ArticleManager : DomainService
{
    private readonly IArticleRepository _articleRepository;

    public ArticleManager(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    public async Task<Article> CreateAsync(
        [NotNull] string title,
        [NotNull] string description,
        [NotNull] string slug
    )
    {
        Check.NotNullOrWhiteSpace(slug, nameof(slug));

        var existingArticle = await _articleRepository.FindBySlugAsync(slug);
        if(existingArticle != null)
        {
            throw new ArticleAlreadyExistsException(slug);
        }

        return new Article(
            title,
            description,
            slug
        );
    }

    public async Task ChangeSlugAsync(
        [NotNull] Article article,
        [NotNull] string newSlug
    )
    {
        Check.NotNull(article, nameof(article));
        Check.NotNullOrWhiteSpace(newSlug, nameof(newSlug));

        var existingArticle = await _articleRepository.FindBySlugAsync(newSlug);
        if(existingArticle != null)
        {
            throw new ArticleAlreadyExistsException(newSlug);
        }

        article.ChangeSlug(newSlug);
    }
}