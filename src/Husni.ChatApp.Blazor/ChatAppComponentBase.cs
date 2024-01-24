using Husni.ChatApp.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Husni.ChatApp.Blazor;

public abstract class ChatAppComponentBase : AbpComponentBase
{
    protected ChatAppComponentBase()
    {
        LocalizationResource = typeof(ChatAppResource);
    }
}
