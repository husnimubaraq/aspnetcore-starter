using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Husni.ChatApp.Articles;

public interface IArticleRepository : IRepository<Article, int>
{
    Task<Article> FindBySlugAsync(string slug);
    Task<List<Article>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null
    );
}