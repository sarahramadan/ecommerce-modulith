namespace Catalog.Products.Models
{
    public class Product : Aggregate<Guid>
    {
        public string ProductName { get; set; } = default!;
        public string ProductDescription { get; set; } = default!;
        public string ImageURL { get; set; } = default!;
        public decimal Price { get; set; }
        public Guid? CategoryId { get; set; }
        public Category Category { get; set; }

        public Product Create(string productName, string productDescription, string imageURL, decimal price,Guid? Id = null)
        {
            var newProduct = new Product
            {
                Id = Id??Guid.NewGuid(),
                ProductName = productName,
                ProductDescription = productDescription,
                ImageURL = imageURL,
                Price = price,
                CreationDate = DateTime.UtcNow,
                CreatedBy = "System" // This should be replaced with actual user context in a real application
            };

            AddDomainEvent(new ProductCreateEvent(newProduct));

            return newProduct;
        }
        public void Update(string productName, string productDescription, string imageURL, decimal price)
        {
            ProductName = productName;
            ProductDescription = productDescription;
            ImageURL = imageURL;
            ModificationDate = DateTime.UtcNow;
            ModifiedBy = "System"; // This should be replaced with actual user context in a real application

            if (Price != price)
            {
                Price = price;
                AddDomainEvent(new ProductChangePriceEvent(this));
            }
        }
    }
}
