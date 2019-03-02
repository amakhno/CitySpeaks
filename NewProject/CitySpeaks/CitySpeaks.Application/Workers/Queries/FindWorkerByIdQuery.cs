using CitySpeaks.Domain.Models;
using MediatR;

namespace CitySpeaks.Application.Workers.Queries
{
    public class FindWorkerByIdQuery : IRequest<Worker>
    {
        public int Id { get; set; }
    }
}
