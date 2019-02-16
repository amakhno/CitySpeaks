using MediatR;

namespace CitySpeaks.Application.ProgramCategories.Queries
{
    public class GetListOfCategoriesQuery : IRequest<string[]>
    {
    }
}
