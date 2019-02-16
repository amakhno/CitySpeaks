using MediatR;

namespace CitySpeaks.Application.ProgramCategories.Queries
{
    public class GetCategoryByNameQuery : IRequest<int>
    {
        public string CategoryName { get; set; }

        public GetCategoryByNameQuery(string categoryName)
        {
            CategoryName = categoryName;
        }
    }
}
