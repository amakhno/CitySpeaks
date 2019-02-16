using CitySpeaks.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CitySpeaks.Application.ProgramCategories.Queries
{
    public class GetCategoryByNameQueryHandler : IRequestHandler<GetCategoryByNameQuery, int>
    {
        private readonly CitySpeaksContext _citySpeaksContext;

        public GetCategoryByNameQueryHandler(CitySpeaksContext citySpeaksContext)
        {
            _citySpeaksContext = citySpeaksContext;
        }

        public async Task<int> Handle(GetCategoryByNameQuery request, CancellationToken cancellationToken)
        {
            var category = await _citySpeaksContext.ProgramCategories.Where(x => x.Name == request.CategoryName).FirstOrDefaultAsync();
            return category.CategoryId;
        }
    }
}
