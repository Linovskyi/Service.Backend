using AutoMapper;
using AutoMapper.QueryableExtensions;
using DogsService.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DogsService.Application.Dogs.Queries.GetDogList
{
    public class GetDogListQueryHandler : IRequestHandler<GetDogListQuery, DogListVm>
    {
        private readonly IDogsDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetDogListQueryHandler(IDogsDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<DogListVm> Handle(GetDogListQuery request, CancellationToken cancellationToken)
        {
            var dogsQuery = await _dbContext.Dogs
                .Where(dog => dog.UserId == request.UserId)
                .ProjectTo<DogLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new DogListVm { Dogs = dogsQuery };
        }
    }
}