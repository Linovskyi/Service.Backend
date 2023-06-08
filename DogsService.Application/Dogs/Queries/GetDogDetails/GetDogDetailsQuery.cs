using MediatR;

namespace DogsService.Application.Dogs.Queries.GetDogDetails
{
    public class GetDogDetailsQuery : IRequest<DogDetailsVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
