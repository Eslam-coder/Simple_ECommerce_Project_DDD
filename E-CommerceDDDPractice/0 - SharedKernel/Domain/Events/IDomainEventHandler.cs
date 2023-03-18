using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0___SharedKernel.Domain.Events
{
    public interface IDomainEventHandler<in TNotification> :
        INotificationHandler<TNotification> where TNotification : INotification
    {
    }
}
