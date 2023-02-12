using XTI_App.Abstractions;
using XTI_CopiaDB;
using XTI_DB;
using XTI_HubAppClient;

namespace CopiaSetupApp;

internal sealed class CopiaAppSetup : IAppSetup
{
    private readonly DbAdmin<CopiaDbContext> dbAdmin;

    public CopiaAppSetup(DbAdmin<CopiaDbContext> dbAdmin)
    {
        this.dbAdmin = dbAdmin;
    }

    public async Task Run(AppVersionKey versionKey)
    {
        await dbAdmin.Update();
    }
}
