using MediatR;

namespace DogsService.Application.Dogs.Commands.CreateDog
{
    public class CreateDogCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int TailLength { get; set; }
        public int Weight { get; set; }
    }
}
