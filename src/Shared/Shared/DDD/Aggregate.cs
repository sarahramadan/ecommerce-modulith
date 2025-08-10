namespace Shared.DDD
{
    public class Aggregate<T> : Entity<T>, IAggregate<T>
    {
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

        private readonly List<IDomainEvent> _domainEvents;

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
        public IDomainEvent[] ClearDomainEvents()
        {
            throw new NotImplementedException();
        }
    }
}
