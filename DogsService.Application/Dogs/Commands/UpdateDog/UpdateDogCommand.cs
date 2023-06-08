using MediatR;

namespace DogsService.Application.Dogs.Commands.UpdateDog
{
    public class UpdateDogCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int TailLength { get; set; }
        public int Weight { get; set; }
    }
}
