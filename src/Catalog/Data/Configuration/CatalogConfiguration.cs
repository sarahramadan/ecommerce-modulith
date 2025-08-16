using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.Configuration
{
    public class CatalogConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasData(new[]
                {
                    new Category(){Name = "Laptop",Description = "Different types of laptops for different usage",Id = new Guid("8af41da1-4217-49db-a7d3-2d2f702a7495") ,CreatedBy  = "system",CreationDate = null,ModificationDate=null,ModifiedBy=null},
                    new Category(){Name = "Mobile",Description = "A wide usage of mobile with different shape", Id = new Guid("8af41da1-4217-49db-a7d3-2d2f702a7494"),CreatedBy  = "system",CreationDate = null,ModificationDate=null,ModifiedBy=null},
                }
            );
        }
    }
}
