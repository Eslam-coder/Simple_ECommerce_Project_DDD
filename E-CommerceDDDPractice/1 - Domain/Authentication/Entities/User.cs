using _0___SharedKernel.Domain.Entities;
using _1___Domain.Orders.Entities;
using Microsoft.AspNetCore.Identity;

namespace _1___Domain.Authentication.Entities
{
    public class User : IdentityUser, IAggregateRoot, IEntity<string>
    {
        private readonly List<Order> _orders = new List<Order>();

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public byte[]? ProfilePicture { get; private set; }
        
        public string Gender { get; private set; }
        
        public Address Address { get; set; }

        public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();
        
        private User()
        {
        }

        public User(
            string firstName, 
            string lastName, 
            byte[]? profilePicture, 
            string gender, 
            Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfilePicture = profilePicture;
            Gender = gender;
            Address = address;
        }
    }
}
