using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using XTI_CopiaDB;
using XTI_CopiaDB.Extensions;
using XTI_Core;
using XTI_Core.Extensions;
using XTI_DB;

namespace XTI_CopiaDbTool;

internal sealed class CopiaDbContextFactory : IDesignTimeDbContextFactory<CopiaDbContext>
{
    public CopiaDbContext CreateDbContext(string[] args)
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.UseXtiConfiguration(hostingContext.HostingEnvironment, "", "", args);
            })
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton(_ => new XtiEnvironment(hostContext.HostingEnvironment.EnvironmentName));
                services.AddConfigurationOptions<DbOptions>(DbOptions.DB);
                services.Configure<ToolOptions>(hostContext.Configuration);
                services.AddCopiaDbContextForSqlServer();
            })
            .Build();
        var scope = host.Services.CreateScope();
        return scope.ServiceProvider.GetRequiredService<CopiaDbContext>();
    }
}