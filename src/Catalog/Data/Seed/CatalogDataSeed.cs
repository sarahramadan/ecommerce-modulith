using Microsoft.EntityFrameworkCore;

namespace Catalog.Data.Seed
{
    public class CatalogDataSeed(CatalogDbContext dbContext) : IDataSeeder
    {
        // Approach 1 to seed data -> more flexible can ad logic to check if exist or not
        public async Task SeedDataAsync(IServiceProvider serviceProvider)
        {
            if(dbContext is not CatalogDbContext catalogDbContext)
            {
                throw new ArgumentException("Invalid DbContext type. Expected CatalogDbContext.", nameof(dbContext));
            }
            if (!await catalogDbContext.Products.AnyAsync())
            {
                catalogDbContext.Products.AddRange(
                    new Product().Create("seed product 1", "description", string.Empty, 20)
                );
                await catalogDbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            // Approach 3 to seed data -> more flexible can ad logic to check if exist or not
            //await catalogDbContext.SeedIfNotExistsAsync<Product>(
            //    p => p.ProductName == "seed product 1",
            //    new Product().Create("seed product 1", "description", string.Empty, 20)
            //);
        }
    }
}
