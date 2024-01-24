using System.Threading.Tasks;

namespace Husni.ChatApp.Data;

public interface IChatAppDbSchemaMigrator
{
    Task MigrateAsync();
}
