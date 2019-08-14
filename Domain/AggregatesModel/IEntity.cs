using System.Collections.Generic;
using MediatR;

namespace Domain.AggregatesModel
{
    public interface IEntity
    {
        long Id { get; }

        IReadOnlyCollection<INotification> DomainEvents { get; }

        void ClearDomainEvents();

        void AddDomainEvent(INotification domainEvent);
    }
}
