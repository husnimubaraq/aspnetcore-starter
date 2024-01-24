using System;
using System.Collections.Generic;
using System.Text;
using Husni.ChatApp.Localization;
using Volo.Abp.Application.Services;

namespace Husni.ChatApp;

/* Inherit your application services from this class.
 */
public abstract class ChatAppAppService : ApplicationService
{
    protected ChatAppAppService()
    {
        LocalizationResource = typeof(ChatAppResource);
    }
}
