namespace Shared.DDD
{
    public class Entity<T> : IEntity<T>
    {
        public T Id { get; set; } = default!;
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string CreatedBy { get; set; } = default!;
        public string? ModifiedBy { get; set; } = default!;
    }
}
