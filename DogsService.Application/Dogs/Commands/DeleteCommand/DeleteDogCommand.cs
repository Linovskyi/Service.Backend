using MediatR;

namespace DogsService.Application.Dogs.Commands.DeleteCommand
{
    public class DeleteDogCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
