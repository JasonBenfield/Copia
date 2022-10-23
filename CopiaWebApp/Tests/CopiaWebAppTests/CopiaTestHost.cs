using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using XTI_App.Abstractions;
using XTI_App.Extensions;
using XTI_App.Fakes;
using XTI_CopiaDB.Extensions;
using XTI_CopiaWebAppApi;
using XTI_Core;
using XTI_Core.Extensions;
using XTI_Core.Fakes;

namespace CopiaWebAppTests;

internal sealed class CopiaTestHost
{
    public Task<IServiceProvider> Setup(string envName = "Development", Action<IServiceCollection>? configure = null)
    {
        Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", envName);
        var xtiEnv = XtiEnvironment.Parse(envName);
        var builder = new XtiHostBuilder(xtiEnv, CopiaInfo.AppKey.Name.DisplayText, CopiaInfo.AppKey.Type.DisplayText, new string[0]);
        builder.Services.AddSingleton<IHostEnvironment>
        (
            _ => new FakeHostEnvironment { EnvironmentName = envName }
        );
        builder.Services.AddSingleton(_ => CopiaInfo.AppKey);
        builder.Services.AddSingleton(_ => AppVersionKey.Current);
        builder.Services.AddFakesForXtiApp();
        builder.Services.AddSingleton<XtiFolder>();
        builder.Services.AddSingleton(sp => sp.GetRequiredService<XtiFolder>().AppDataFolder(CopiaInfo.AppKey));
        builder.Services.AddCopiaAppApiServices();
        builder.Services.AddScoped<CopiaAppApiFactory>();
        builder.Services.AddScoped<AppApiFactory>(sp => sp.GetRequiredService<CopiaAppApiFactory>());
        builder.Services.AddScoped(sp => sp.GetRequiredService<AppApiFactory>().CreateForSuperUser());
        builder.Services.AddScoped(sp => (CopiaAppApi)sp.GetRequiredService<IAppApi>());
        builder.Services.AddCopiaDbContextForInMemory();
        if (configure != null)
        {
            configure(builder.Services);
        }
        var sp = builder.Build().Scope();
        var appContext = sp.GetRequiredService<FakeAppContext>();
        var apiFactory = sp.GetRequiredService<CopiaAppApiFactory>();
        var template = apiFactory.CreateTemplate();
        var copiaApp = appContext.AddApp(template.ToModel());
        appContext.SetCurrentApp(copiaApp);
        return Task.FromResult(sp);
    }
}
