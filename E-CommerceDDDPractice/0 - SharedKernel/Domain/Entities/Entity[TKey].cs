using _0___SharedKernel.Domain.Events;

namespace _0___SharedKernel.Domain.Entities
{
    public abstract class Entity<TKey> : IEntity<TKey>, IHaveDomainEvents
    {  
        private readonly List<DomainEvent> _domainEvents = new List<DomainEvent>();
        
        IReadOnlyCollection<DomainEvent> IHaveDomainEvents.DomainEvents => _domainEvents;

        public TKey Id { get; protected set; }
        
        public DateTime? CreationDate { get; protected set; }

        public DateTime? ModificationDate { get; protected set; }

        public string? CreatedBy { get; protected set; }

        public string? ModifiedBy { get; protected set; }
        
        public bool Equals(Entity<TKey> other)
        {
            return ReferenceEquals(this, other) || Id.Equals(other.Id);
        }

        public override bool Equals(object other)
        {
            if (!(other is Entity<TKey> otherEntity))
            {
                return false;
            }
            return Equals(otherEntity);
        }

        public static bool operator ==(Entity<TKey> a, Entity<TKey> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return true;
            return a.Equals(b);
        }

        public static bool operator !=(Entity<TKey> a, Entity<TKey> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }

        protected virtual void AddDomainEvent(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        void IHaveDomainEvents.ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
