using _0___SharedKernel.Domain.Repositories.Specification;
using _1___Domain.Orders.Entities;

namespace _1___Domain.Orders.Services
{
    public class OrderSpecification : Specification<Order>
    {
        public OrderSpecification() 
        {
            Include(order => order.Product);
            Include(order => order.User);
        }

        public static ISpecification<Order> ById(Guid productId, string userId)
        {
            var orderSpecification = new OrderSpecification();
            var result = orderSpecification
                        .Where(order => order.Product.Id == productId && 
                                        order.User.Id == userId);
            return result;
        }
    }
}
