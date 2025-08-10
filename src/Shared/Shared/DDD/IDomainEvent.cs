using MediatR;

namespace Shared.DDD
{
    public interface IDomainEvent : INotification
    {
        public DateTime OccurredOn => DateTime.UtcNow;
        public string EventType => GetType().AssemblyQualifiedName!;
        public Guid EventId => Guid.NewGuid();
    }
}
