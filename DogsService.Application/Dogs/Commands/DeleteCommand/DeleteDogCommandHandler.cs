using MediatR;
using DogsService.Application.Common.Exceptions;
using DogsService.Application.Interfaces;
using DogsService.Domain;

namespace DogsService.Application.Dogs.Commands.DeleteCommand
{
    public class DeleteDogCommandHandler : IRequestHandler<DeleteDogCommand, Unit>
    {
        private readonly IDogsDbContext _dbContext;

        public DeleteDogCommandHandler(IDogsDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteDogCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Dogs
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Dog), request.Id);
            }

            _dbContext.Dogs.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
