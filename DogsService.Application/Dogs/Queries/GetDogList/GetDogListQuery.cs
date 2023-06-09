using MediatR;

namespace DogsService.Application.Dogs.Queries.GetDogList
{
    public class GetDogListQuery : IRequest<DogListVm>
    {
        public Guid UserId { get; set; }
        public string Attribute { get; set; }
        public string Order { get; set; }
        public int PageNumber { get; set; }
        public int PageSize {get; set; }
    }
}
