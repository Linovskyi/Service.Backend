using DogsService.Application.Common.Exceptions;
using DogsService.Application.Interfaces;
using DogsService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DogsService.Application.Dogs.Commands.UpdateDog
{
    public class UpdateDogCommandHandler : IRequestHandler<UpdateDogCommand, Unit>
    {
        private readonly IDogsDbContext _dbContext;

        public UpdateDogCommandHandler(IDogsDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateDogCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Dogs.FirstOrDefaultAsync(dog =>
                    dog.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Dog), request.Id);
            }

            entity.Name = request.Name;
            entity.Color = request.Color;
            entity.TailLength = request.TailLength;
            entity.Weight = request.Weight;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}