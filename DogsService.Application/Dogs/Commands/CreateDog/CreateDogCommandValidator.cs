using FluentValidation;

namespace DogsService.Application.Dogs.Commands.CreateDog
{
    public class CreateDogCommandValidator : AbstractValidator<CreateDogCommand>
    {
        public CreateDogCommandValidator()
        {
            RuleFor(createDogCommand =>
                createDogCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(createDogCommand =>
                createDogCommand.Name).NotEmpty().MaximumLength(25);
            RuleFor(createDogCommand =>
                createDogCommand.Color).NotEmpty().MaximumLength(25);
            RuleFor(createDogCommand =>
                createDogCommand.TailLength).GreaterThan(0);
            RuleFor(createDogCommand =>
                createDogCommand.Weight).GreaterThan(0);
        }
    }
}