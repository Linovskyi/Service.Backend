using FluentValidation;

namespace DogsService.Application.Dogs.Commands.DeleteCommand
{
    public class DeleteDogCommandValidator : AbstractValidator<DeleteDogCommand>
    {
        public DeleteDogCommandValidator()
        {
            RuleFor(deleteDogCommand => deleteDogCommand.Id).NotEqual(Guid.Empty);
            RuleFor(deleteDogCommand => deleteDogCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}