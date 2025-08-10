namespace Catalog.Products.Events
{
    public record ProductChangePriceEvent(Product updated) : IDomainEvent;
}
