using System.Threading;
using System.Threading.Tasks;
using CitySpeaks.Infrastructure;
using MediatR;

namespace CitySpeaks.Application.News.Commands
{
    public class AddNewsCommandHandler : IRequestHandler<AddNewsCommand, string>
    {
        private readonly CitySpeaksContext _citySpeaksContext;

        public AddNewsCommandHandler(CitySpeaksContext citySpeaksContext)
        {
            _citySpeaksContext = citySpeaksContext;
        }

        public Task<string> Handle(AddNewsCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult("Success");
        }
    }
}
