using CitySpeaks.Infrastructure.Interfaces.Dto.User;
using MediatR;

namespace CitySpeaks.Application.Users.Commands
{
    public class CreateUserCommand : IRequest<UsernameWithRolenameDto>
    {
        public LoginDto RegisterDto { get; set; }
    }
}
