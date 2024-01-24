using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Husni.ChatApp.Articles;

public interface IArticleAppService : IApplicationService
{
    Task<ArticleDto> GetAsync(int id);
    Task<PagedResultDto<ArticleDto>> GetListAsync(GetArticleListDto input);
    Task<ArticleDto> CreateAsync(CreateArticleDto input);
    Task UpdateAsync(int id, UpdateArticleDto input);
    Task DeleteAsync(int id);
}
