using Husni.ChatApp.Samples;
using Xunit;

namespace Husni.ChatApp.EntityFrameworkCore.Domains;

[Collection(ChatAppTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<ChatAppEntityFrameworkCoreTestModule>
{

}
