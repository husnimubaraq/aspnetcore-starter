using Husni.ChatApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Husni.ChatApp.Permissions;

public class ChatAppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ChatAppPermissions.GroupName);

        var articlesPermission = myGroup.AddPermission(ChatAppPermissions.Article.Default, L("Permissions:Articles"));
        articlesPermission.AddChild(ChatAppPermissions.Article.Create, L("Permissions:Articles.Create"));
        articlesPermission.AddChild(ChatAppPermissions.Article.Edit, L("Permissions:Articles.Edit"));
        articlesPermission.AddChild(ChatAppPermissions.Article.Delete, L("Permissions:Articles.Delete"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ChatAppPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ChatAppResource>(name);
    }
}
