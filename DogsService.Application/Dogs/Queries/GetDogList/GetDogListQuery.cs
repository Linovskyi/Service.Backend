using MediatR;

namespace DogsService.Application.Dogs.Queries.GetDogList
{
    public class GetDogListQuery : IRequest<DogListVm>
    {
        public Guid UserId { get; set; }
    }
}
