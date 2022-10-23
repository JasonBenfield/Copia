using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using XTI_Core;
using XTI_Core.Extensions;
using XTI_DB;

namespace XTI_CopiaDB.Extensions;

public static class SqlServerExtensions
{
    public static void AddCopiaDbContextForSqlServer(this IServiceCollection services)
    {
        services.AddConfigurationOptions<DbOptions>(DbOptions.DB);
        services.AddDbContext<CopiaDbContext>((sp, options) =>
        {
            var xtiEnv = sp.GetRequiredService<XtiEnvironment>();
            var dbOptions = sp.GetRequiredService<DbOptions>();
            var connectionString = new XtiConnectionString
            (
                dbOptions, 
                new XtiDbName(xtiEnv.EnvironmentName, "Copia")
            );
            options.UseSqlServer
            (
                connectionString.Value(),
                b => b.MigrationsAssembly("XTI_CopiaDB.SqlServer")
            );
            if (xtiEnv.IsDevelopmentOrTest())
            {
                options.EnableSensitiveDataLogging();
            }
            else
            {
                options.EnableSensitiveDataLogging(false);
            }
        });
    }
}