using CitySpeaks.Infrastructure.Interfaces.Dto.User;
using MediatR;

namespace CitySpeaks.Application.Users.Commands
{
    public class LoginUserCommand : IRequest<UsernameWithRolenameDto>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
