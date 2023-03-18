using _0___SharedKernel.Domain.Events;
using _1___Domain.Orders.Entities;

namespace _1___Domain.Orders.Events
{
    public class OrderCreatedEvent : DomainEvent
    {
        public Order Order { get; set; }
        
        public OrderCreatedEvent(Order order) 
        { 
            Order = order;
        }
    }
}
