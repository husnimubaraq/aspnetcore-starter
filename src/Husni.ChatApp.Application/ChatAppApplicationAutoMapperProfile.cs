using AutoMapper;
using Husni.ChatApp.Articles;

namespace Husni.ChatApp;

public class ChatAppApplicationAutoMapperProfile : Profile
{
    public ChatAppApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Article, ArticleDto>();
    }
}
