using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Husni.ChatApp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Husni.ChatApp.Articles;

public class EfCoreArticleRepository
    : EfCoreRepository<ChatAppDbContext, Article, int>, IArticleRepository
{
    public EfCoreArticleRepository(
        IDbContextProvider<ChatAppDbContext> dbContextProvider
    ) : base(dbContextProvider)
    {
        
    }

    public async Task<Article> FindBySlugAsync(string slug)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet.FirstOrDefaultAsync(article => article.Slug == slug);
    }

    public async Task<List<Article>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet
            .WhereIf(
                !filter.IsNullOrWhiteSpace(),
                article => article.Title.Contains(filter)
            )
            .OrderBy(sorting)
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync();
    }
}