using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Data
{
    public static class MigrationExtensions
    {
        public static IApplicationBuilder UseMigration<TContext>(this IApplicationBuilder app) where TContext : DbContext
        {
            RunMigration<TContext>(app.ApplicationServices).GetAwaiter().GetResult();
            RunSeedData(app.ApplicationServices).GetAwaiter().GetResult();
            return app;
        }

        public static async Task RunMigration<TContext>(IServiceProvider serviceProvider) where TContext : DbContext
        {
            var db = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<TContext>();
            if (db.Database.GetPendingMigrations().Any())
            {
               await db.Database.MigrateAsync().ConfigureAwait(false); // Apply migrations at startup
            }
        }
        public static async Task RunSeedData(IServiceProvider serviceProvider)
        {
            var seeders = serviceProvider.CreateScope().ServiceProvider.GetServices<IDataSeeder>();
            foreach (var seeder in seeders)
            {
                await seeder.SeedDataAsync(serviceProvider).ConfigureAwait(false);
            }
        }
    }
}
