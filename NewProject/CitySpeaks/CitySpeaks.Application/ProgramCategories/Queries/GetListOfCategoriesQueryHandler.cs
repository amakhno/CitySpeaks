using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CitySpeaks.Infrastructure;
using CitySpeaks.Persistence;
using MediatR;

namespace CitySpeaks.Application.ProgramCategories.Queries
{
    public class GetListOfCategoriesQueryHandler : IRequestHandler<GetListOfCategoriesQuery, string[]>
    {
        private readonly CitySpeaksContext _citySpeaksContext;

        public GetListOfCategoriesQueryHandler(CitySpeaksContext citySpeaksContext)
        {
            _citySpeaksContext = citySpeaksContext;
        }

        public Task<string[]> Handle(GetListOfCategoriesQuery request, CancellationToken cancellationToken)
        {
            List<string> model = new List<string>();
            foreach (var category in _citySpeaksContext.ProgramCategories)
            {
                model.Add(category.Name);
            }
            return Task.FromResult(model.ToArray());
        }
    }
}
