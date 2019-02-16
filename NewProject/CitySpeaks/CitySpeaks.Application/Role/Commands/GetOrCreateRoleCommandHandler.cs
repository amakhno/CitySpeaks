using CitySpeaks.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CitySpeaks.Application.Role.Commands
{
    public class GetOrCreateRoleCommandHandler : IRequestHandler<GetOrCreateRoleCommand, Domain.Models.Role>
    {
        private readonly CitySpeaksContext _citySpeaksContext;

        public GetOrCreateRoleCommandHandler(CitySpeaksContext citySpeaksContext,
            IMediator mediator)
        {
            _citySpeaksContext = citySpeaksContext;
        }

        public async Task<Domain.Models.Role> Handle(GetOrCreateRoleCommand request, CancellationToken cancellationToken)
        {
            Domain.Models.Role roleInDb = await _citySpeaksContext.Roles
                .Where(x => x.Name == request.RoleName).FirstOrDefaultAsync();
            if (roleInDb != null)
            {
                return roleInDb;
            }
            var newRole = new Domain.Models.Role()
            {
                Name = request.RoleName
            };
            _citySpeaksContext.Roles.Add(newRole);
            await _citySpeaksContext.SaveChangesAsync();
            return newRole;
        }
    }
}
