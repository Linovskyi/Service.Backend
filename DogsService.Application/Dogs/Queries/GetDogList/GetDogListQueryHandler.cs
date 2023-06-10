using AutoMapper;
using AutoMapper.QueryableExtensions;
using DogsService.Application.Interfaces;
using DogsService.Domain;
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
            if (!string.IsNullOrEmpty(request.Attribute))
            {
                IQueryable<Dog> query = _dbContext.Dogs;

                switch (request.Attribute.ToLower())
                {
                    case "name":
                        query = request.Order.ToLower() == "desc" ? query.OrderByDescending(d => d.Name) : query.OrderBy(d => d.Name);
                        break;
                    case "color":
                        query = request.Order.ToLower() == "desc" ? query.OrderByDescending(d => d.Color) : query.OrderBy(d => d.Color);
                        break;
                    case "tail_length":
                        query = request.Order.ToLower() == "desc" ? query.OrderByDescending(d => d.TailLength) : query.OrderBy(d => d.TailLength);
                        break;
                    case "weight":
                        query = request.Order.ToLower() == "desc" ? query.OrderByDescending(d => d.Weight) : query.OrderBy(d => d.Weight);
                        break;
                    default:
                        break;
                }

                query = query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize);

                var dogs = await query.ToListAsync(cancellationToken);

                return new DogListVm { Dogs = (IList<DogLookupDto>)dogs };
            }
            else
            {
                var dogsQuery = await _dbContext.Dogs
                    .Where(dog => dog.UserId == request.UserId)
                    .ProjectTo<DogLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

                return new DogListVm { Dogs = dogsQuery };
            }
        }
    }
}