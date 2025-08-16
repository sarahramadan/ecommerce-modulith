using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Categories.Models
{
    public class Category : Aggregate<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
        public Category Create(string name, string description, Guid? id = null)
        {
            var newCategory = new Category
            {
                Id = id ?? Guid.NewGuid(),
                Name = name,
                Description = description,
                CreationDate = DateTime.UtcNow,
                CreatedBy = "System"
            };
            return newCategory;
        }
    }
}
