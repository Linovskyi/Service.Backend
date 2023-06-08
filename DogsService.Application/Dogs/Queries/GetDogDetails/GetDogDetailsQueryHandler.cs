using AutoMapper;
using DogsService.Application.Common.Exceptions;
using DogsService.Application.Interfaces;
using DogsService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DogsService.Application.Dogs.Queries.GetDogDetails
{
    public class GetDogDetailsQueryHandler : IRequestHandler<GetDogDetailsQuery, DogDetailsVm>
    {
        private readonly IDogsDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetDogDetailsQueryHandler(IDogsDbContext dbContext, IMapper mapper) 
            => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<DogDetailsVm> Handle(GetDogDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Dogs
                .FirstOrDefaultAsync(dog =>
                    dog.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Dog), request.Id);
            }

            return _mapper.Map<DogDetailsVm>(entity);
        }
    }
}