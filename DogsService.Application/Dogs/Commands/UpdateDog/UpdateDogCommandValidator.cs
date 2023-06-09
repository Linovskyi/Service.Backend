using FluentValidation;

namespace DogsService.Application.Dogs.Commands.UpdateDog
{
    public class UpdateDogCommandValidator : AbstractValidator<UpdateDogCommand>
    {
        public UpdateDogCommandValidator()
        {
            RuleFor(updateDogCommand => updateDogCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateDogCommand => updateDogCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateDogCommand => updateDogCommand.Name).NotEmpty().MaximumLength(25);
            RuleFor(updateDogCommand => updateDogCommand.Color).NotEmpty().MaximumLength(25);
            RuleFor(updateDogCommand => updateDogCommand.TailLength).GreaterThan(0);
            RuleFor(updateDogCommand => updateDogCommand.Weight).GreaterThan(0);
        }
    }
}