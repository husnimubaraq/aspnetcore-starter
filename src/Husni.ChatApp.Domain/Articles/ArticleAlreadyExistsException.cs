using Volo.Abp;

namespace Husni.ChatApp.Articles;

public class ArticleAlreadyExistsException : BusinessException
{
    public ArticleAlreadyExistsException(string slug)
        : base(ChatAppDomainErrorCodes.ArticleAlreadyExists)
        {
            WithData("slug", slug);
        }
}