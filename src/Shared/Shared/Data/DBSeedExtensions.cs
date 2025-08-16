using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Data
{
    public static class DBSeedExtensions
    {
        public static async Task SeedIfNotExistsAsync<TEntity>(
    this DbContext context,
    Func<TEntity, bool> predicate,
    params TEntity[] entities) where TEntity : class
        {
            foreach (var entity in entities)
            {
                if (!context.Set<TEntity>().Any(predicate))
                {
                    context.Set<TEntity>().Add(entity);
                }
            }

            await context.SaveChangesAsync();
        }
    }
}
