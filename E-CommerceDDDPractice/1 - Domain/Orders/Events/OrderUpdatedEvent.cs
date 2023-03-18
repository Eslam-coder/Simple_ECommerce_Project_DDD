using _0___SharedKernel.Domain.Events;
using _1___Domain.Orders.Entities;

namespace _1___Domain.Orders.Events
{
    public class OrderUpdatedEvent : DomainEvent
    {
        public Order ExistOrder { get; set; }
        
        public int NewRequiredQunatity { get; set; }

        public OrderUpdatedEvent(Order existOrder, int newRequiredQunatity)
        {
            NewRequiredQunatity = newRequiredQunatity;
            ExistOrder = existOrder;
        }
    }
}
