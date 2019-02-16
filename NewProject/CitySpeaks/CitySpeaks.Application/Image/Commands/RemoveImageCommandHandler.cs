using CitySpeaks.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CitySpeaks.Application.Image.Commands
{
    public class RemoveImageCommandHandler : IRequestHandler<RemoveImageCommand>
    {
        private readonly CitySpeaksContext _citySpeaksContext;

        public RemoveImageCommandHandler(CitySpeaksContext citySpeaksContext)
        {
            _citySpeaksContext = citySpeaksContext;
        }

        public async Task<Unit> Handle(RemoveImageCommand request, CancellationToken cancellationToken)
        {
            int imageId = request.ImageId;
            var imageToDelete = await _citySpeaksContext.Images.FindAsync(imageId).ConfigureAwait(false);
            _citySpeaksContext.Images.Remove(imageToDelete);
            await _citySpeaksContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
