using MediatR;

namespace CitySpeaks.Application.Image.Commands
{
    public class RemoveImageCommand : IRequest
    {
        public int ImageId { get; set; }
    }
}
