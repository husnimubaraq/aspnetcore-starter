using AutoMapper;
using Husni.ChatApp.Articles;

namespace Husni.ChatApp.Blazor;

public class ChatAppBlazorAutoMapperProfile : Profile
{
    public ChatAppBlazorAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Blazor project.
        CreateMap<ArticleDto, UpdateArticleDto>();

    }
}
