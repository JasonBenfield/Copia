using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CopiaSetupApp;
using XTI_App.Abstractions;
using XTI_App.Api;
using XTI_AppSetupApp.Extensions;
using XTI_CopiaWebAppApi;
using XTI_CopiaDB.Extensions;
using XTI_DB;
using XTI_CopiaDB;

await XtiSetupAppHost.CreateDefault(CopiaInfo.AppKey, args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddSingleton(_ => AppVersionKey.Current);
        services.AddScoped<AppApiFactory, CopiaAppApiFactory>();
        services.AddScoped<IAppSetup, CopiaAppSetup>();
        services.AddCopiaDbContextForSqlServer();
        services.AddScoped<DbAdmin<CopiaDbContext>>();
    })
    .RunConsoleAsync();