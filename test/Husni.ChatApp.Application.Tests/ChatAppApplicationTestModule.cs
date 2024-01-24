using Volo.Abp.Modularity;

namespace Husni.ChatApp;

[DependsOn(
    typeof(ChatAppApplicationModule),
    typeof(ChatAppDomainTestModule)
)]
public class ChatAppApplicationTestModule : AbpModule
{

}
