using Volo.Abp.Modularity;

namespace Husni.ChatApp;

public abstract class ChatAppApplicationTestBase<TStartupModule> : ChatAppTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
