using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Domain.Common
{
    public abstract class Entity<T> : IBaseEntity, IHasDomainEvents, IEquatable<Entity<T>> where T : ValueObject
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        public T Id { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime LastModifiedDate { get; private set; }
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
        public Entity(T id)
        {
            Id = id;

        }
        protected Entity()
        {

        }
        public override bool Equals(object? obj)
        {
            return obj is Entity<T> entity && Id.Equals(entity.Id);
        }

        public bool Equals(Entity<T>? other)
        {
            return Equals((object?)other);
        }

        public static bool operator ==(Entity<T> left, Entity<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Entity<T> left, Entity<T> right)
        {
            return !Equals(left, right);
        }
        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public void SetCreatedDate(DateTime createdDate)
        {
            CreatedDate = createdDate;
        }
        public void SetLastModifiedDate(DateTime lastModifiedDate)
        {
            LastModifiedDate = lastModifiedDate;
        }
    }
}
