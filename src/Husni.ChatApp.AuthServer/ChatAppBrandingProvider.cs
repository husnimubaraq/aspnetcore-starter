using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Husni.ChatApp;

[Dependency(ReplaceServices = true)]
public class ChatAppBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ChatApp";
}
