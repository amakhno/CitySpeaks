using FluentValidation;

namespace CitySpeaks.Application.News.Commands
{
    public class AddNewsCommandValidator : AbstractValidator<AddNewsCommand>
    {
        public AddNewsCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name shouldn't be empty");
        }
    }
}
