using Volo.Abp.Modularity;

namespace Husni.ChatApp;

[DependsOn(
    typeof(ChatAppDomainModule),
    typeof(ChatAppTestBaseModule)
)]
public class ChatAppDomainTestModule : AbpModule
{

}
