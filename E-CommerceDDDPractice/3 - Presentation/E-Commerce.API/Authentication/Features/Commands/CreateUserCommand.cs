using _0___SharedKernel.CQRS;
using _1___Domain.Authentication.Entities;

namespace E_Commerce.API.Authentication.Features.Commands
{
    public class CreateUserCommand : ICommand<string>
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public byte[]? ProfilePicture { get; private set; }

        public string Gender { get; private set; }

        public Address? Address { get; set; }
    }
}
