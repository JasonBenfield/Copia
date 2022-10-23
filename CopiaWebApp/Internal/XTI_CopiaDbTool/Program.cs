using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using XTI_CopiaDB;
using XTI_CopiaDB.Extensions;
using XTI_CopiaDbTool;
using XTI_Core;
using XTI_Core.Extensions;
using XTI_DB;

await Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        config.UseXtiConfiguration(hostingContext.HostingEnvironment, "", "", args);
    })
    .ConfigureServices((hostContext, services) =>
    {
        services.AddSingleton(_ => new XtiEnvironment(hostContext.HostingEnvironment.EnvironmentName));
        services.AddConfigurationOptions<ToolOptions>();
        services.AddConfigurationOptions<DbOptions>(DbOptions.DB);
        services.AddCopiaDbContextForSqlServer();
        services.AddScoped<DbAdmin<CopiaDbContext>>();
        services.AddHostedService<HostedService>();
    })
    .RunConsoleAsync();