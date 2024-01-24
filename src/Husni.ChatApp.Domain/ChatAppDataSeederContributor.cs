using System;
using System.Threading.Tasks;
using Husni.ChatApp.Articles;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Husni.ChatApp;

public class BookStoreDataSeederContributor
    : IDataSeedContributor, ITransientDependency
{
    private readonly IArticleRepository _articleRepository;
    private readonly ArticleManager _articleManager;

    public BookStoreDataSeederContributor(
        IArticleRepository articleRepository,
        ArticleManager articleManager
    )
    {
        _articleRepository = articleRepository;
        _articleManager = articleManager;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _articleRepository.GetCountAsync() <= 0)
        {
            await _articleRepository.InsertAsync(
                await _articleManager.CreateAsync(
                    "Cara Bayar",
                    "Bayar menggunakan payment QRIS",
                    "cara-bayar"
                )
            );

            await _articleRepository.InsertAsync(
                await _articleManager.CreateAsync(
                    "Fitur Upload",
                    "Tips fitur upload",
                    "fitur-upload"
                )
            );
        }
    }
}
