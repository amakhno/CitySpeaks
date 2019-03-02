using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CitySpeaks.Infrastructure.Interfaces.Dto.User;
using CitySpeaks.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CitySpeaks.Application.Users.Commands
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UsernameWithRolenameDto>
    {
        private readonly CitySpeaksContext _citySpeaksContext;

        public LoginUserCommandHandler(CitySpeaksContext citySpeaksContext)
        {
            _citySpeaksContext = citySpeaksContext;
        }

        public async Task<UsernameWithRolenameDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _citySpeaksContext.Users.Include(x => x.Role)
                .Where(x => x.UserName == request.UserName && x.Password == request.Password).FirstOrDefaultAsync();
            return new UsernameWithRolenameDto { UserName = result.UserName, RoleName = result.Role.Name };
        }
    }
}
