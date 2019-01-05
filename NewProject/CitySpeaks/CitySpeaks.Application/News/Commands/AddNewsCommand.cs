using MediatR;

namespace CitySpeaks.Application.News.Commands
{
    public class AddNewsCommand : IRequest<string>
    {
        public string Name { get; set; }
    }
}
