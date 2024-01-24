using Husni.ChatApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Husni.ChatApp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ChatAppController : AbpControllerBase
{
    protected ChatAppController()
    {
        LocalizationResource = typeof(ChatAppResource);
    }
}
