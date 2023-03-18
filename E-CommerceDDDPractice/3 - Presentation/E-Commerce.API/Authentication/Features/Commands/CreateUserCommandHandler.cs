using _0___SharedKernel.CQRS;
using _0___SharedKernel.Domain.Repositories;
using _0___SharedKernel.Domain.UnitOfWork;
using _1___Domain.Authentication.Entities;

namespace E_Commerce.API.Authentication.Features.Commands
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, string>
    {
        private readonly IRepository<User, string> _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserCommandHandler(
            IRepository<User, string> userRepository,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var newUser = new User
            (
                firstName: command.FirstName,
                lastName: command.LastName,
                profilePicture: null,
                gender: command.Gender,
                address: command.Address
            );
            _userRepository.Add(newUser);
            await _unitOfWork.CompleteAsync();
            return newUser.Id;
        }
    }
}
