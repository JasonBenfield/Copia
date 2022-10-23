using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using XTI_CopiaDB;
using XTI_Core;
using XTI_DB;

namespace XTI_CopiaDbTool;

internal sealed class HostedService : IHostedService
{
    private readonly IServiceProvider sp;

    public HostedService(IServiceProvider sp)
    {
        this.sp = sp;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = sp.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<CopiaDbContext>();
        var options = scope.ServiceProvider.GetRequiredService<ToolOptions>();
        var xtiEnv = scope.ServiceProvider.GetRequiredService<XtiEnvironment>();
        try
        {
            if (options.Command == "reset")
            {
                if (!xtiEnv.IsTest() && !options.Force)
                {
                    throw new ArgumentException("Database reset can only be run for the test environment");
                }
                var dbAdmin = scope.ServiceProvider.GetRequiredService<DbAdmin<CopiaDbContext>>();
                await dbAdmin.Reset();
            }
            else if (options.Command == "backup")
            {
                if (string.IsNullOrWhiteSpace(options.BackupFilePath))
                {
                    throw new ArgumentException("Backup file path is required for backup");
                }
                var dbAdmin = scope.ServiceProvider.GetRequiredService<DbAdmin<CopiaDbContext>>();
                await dbAdmin.BackupTo(options.BackupFilePath);
            }
            else if (options.Command == "restore")
            {
                if (xtiEnv.IsProduction())
                {
                    throw new ArgumentException("Database restore cannot be run for the production environment");
                }
                if (string.IsNullOrWhiteSpace(options.BackupFilePath))
                {
                    throw new ArgumentException("Backup file path is required for restore");
                }
                var dbAdmin = scope.ServiceProvider.GetRequiredService<DbAdmin<CopiaDbContext>>();
                await dbAdmin.RestoreFrom(options.BackupFilePath);
            }
            else if (options.Command == "update")
            {
                var dbAdmin = scope.ServiceProvider.GetRequiredService<DbAdmin<CopiaDbContext>>();
                await dbAdmin.Update();
            }
            else
            {
                throw new NotSupportedException($"Command '{options.Command}' is not supported");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Environment.ExitCode = 999;
        }
        var lifetime = scope.ServiceProvider.GetRequiredService<IHostApplicationLifetime>();
        lifetime.StopApplication();
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}