using Husni.ChatApp.Samples;
using Xunit;

namespace Husni.ChatApp.EntityFrameworkCore.Applications;

[Collection(ChatAppTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<ChatAppEntityFrameworkCoreTestModule>
{

}
