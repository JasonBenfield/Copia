using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CopiaSetupApp;
using XTI_App.Abstractions;
using XTI_App.Api;
using XTI_AppSetupApp.Extensions;
using XTI_CopiaWebAppApi;

await XtiSetupAppHost.CreateDefault(CopiaInfo.AppKey, args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddSingleton(_ => AppVersionKey.Current);
        services.AddScoped<AppApiFactory, CopiaAppApiFactory>();
        services.AddScoped<IAppSetup, CopiaAppSetup>();
    })
    .RunConsoleAsync();