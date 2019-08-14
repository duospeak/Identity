using System.Collections.Generic;
using MediatR;

namespace Domain.SeedWork
{
    /// <summary>
    /// 表示领域实体
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// 实体的唯一标识
        /// </summary>
        public virtual long Id { get; protected set; }

        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();

        private readonly List<INotification> _domainEvents = new List<INotification>();

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        public void AddDomainEvent(INotification domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
