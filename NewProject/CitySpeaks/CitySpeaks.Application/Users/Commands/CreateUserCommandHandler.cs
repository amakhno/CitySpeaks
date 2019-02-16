using CitySpeaks.Application.Role.Commands;
using CitySpeaks.Domain.Models;
using CitySpeaks.Infrastructure.Interfaces.Dto.User;
using CitySpeaks.Persistence;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace CitySpeaks.Application.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UsernameWithRolenameDto>
    {
        private const string DefaultRoleName = "admin";
        private readonly CitySpeaksContext _citySpeaksContext;
        private readonly IMediator _mediator;

        public CreateUserCommandHandler(CitySpeaksContext citySpeaksContext,
            IMediator mediator)
        {
            _citySpeaksContext = citySpeaksContext;
            _mediator = mediator;
        }

        public async Task<UsernameWithRolenameDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = new UsernameWithRolenameDto();
            RegisterDto registerDto = request.RegisterDto;            
            using (var transaction = new CommittableTransaction(
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                var anotherUser = _citySpeaksContext.Users.Where(x => x.UserName == registerDto.Email).FirstOrDefault();
                if (anotherUser != null)
                {
                    throw new ArgumentException($"The user with email {registerDto.Email} is already exist!");
                }
                var role = await _mediator.Send(new GetOrCreateRoleCommand { RoleName = DefaultRoleName }).ConfigureAwait(false);
                var user = new User()
                {
                    UserName = registerDto.Email,
                    RoleId = role.Id,
                    Password = registerDto.Password
                };
                await _citySpeaksContext.AddAsync(user).ConfigureAwait(false);
                await _citySpeaksContext.SaveChangesAsync().ConfigureAwait(false);
                result.UserName = user.UserName;
                result.RoleName = role.Name;
                transaction.Commit();
            }

            return result;
        }
    }
}
