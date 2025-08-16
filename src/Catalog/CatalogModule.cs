using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Catalog
{
    public static class CatalogModule
    {
        public static IServiceCollection AddCatalogModule(this IServiceCollection service, IConfiguration configuration)
        {
 
            // OR  var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            service.AddDbContext<CatalogDbContext>(options =>
            {
                var environment = service.BuildServiceProvider().GetRequiredService<IHostEnvironment>();
                options.UseNpgsql(configuration.GetConnectionString("CatalogConnection"), sql =>
                {
                    //sql.MigrationsAssembly(typeof(CatalogDbContext).Assembly.FullName);
                    sql.EnableRetryOnFailure(3); // retry transient errors enables automatic retries for transient database failures (e.g., network issues, timeouts, deadlocks), helping improve reliability without manual try/catch logic
                    sql.CommandTimeout(60); // seconds
                });
                if (environment.IsDevelopment())
                {
                    options.EnableSensitiveDataLogging();
                    options.EnableDetailedErrors();
                }
            });
            service.AddScoped<IDataSeeder, CatalogDataSeed>(); // Register the data seeder for catalog module  
            return service;
        }

        public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
        {
            app.UseMigration<CatalogDbContext>(); // Apply migrations at startup
            return app;
        }

    }
}
