using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CitySpeaks.Domain.Models;
using CitySpeaks.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CitySpeaks.Application.Workers.Queries
{
    public class FindWorkerByIdCommandHandler : IRequestHandler<FindWorkerByIdQuery, Worker>
    {
        private readonly CitySpeaksContext _citySpeaksContext;

        public FindWorkerByIdCommandHandler(CitySpeaksContext citySpeaksContext)
        {
            _citySpeaksContext = citySpeaksContext;
        }

        public Task<Worker> Handle(FindWorkerByIdQuery request, CancellationToken cancellationToken)
        {
            return _citySpeaksContext.Workers
                .Include(x=>x.SmallImage).Include(x=>x.BigImage)
                .Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
