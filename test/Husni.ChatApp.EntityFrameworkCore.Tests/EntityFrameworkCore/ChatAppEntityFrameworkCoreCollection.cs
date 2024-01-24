using Xunit;

namespace Husni.ChatApp.EntityFrameworkCore;

[CollectionDefinition(ChatAppTestConsts.CollectionDefinitionName)]
public class ChatAppEntityFrameworkCoreCollection : ICollectionFixture<ChatAppEntityFrameworkCoreFixture>
{

}
