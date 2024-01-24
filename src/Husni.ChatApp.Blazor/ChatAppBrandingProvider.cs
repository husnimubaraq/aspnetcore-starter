using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Husni.ChatApp.Blazor;

[Dependency(ReplaceServices = true)]
public class ChatAppBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ChatApp";
}
