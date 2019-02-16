using MediatR;

namespace CitySpeaks.Application.Role.Commands
{
    public class GetOrCreateRoleCommand : IRequest<Domain.Models.Role>
    {
        public string RoleName { get; set; }
    }
}
