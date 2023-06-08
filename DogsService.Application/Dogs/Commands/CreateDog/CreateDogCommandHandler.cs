using DogsService.Application.Interfaces;
using DogsService.Domain;
using MediatR;

namespace DogsService.Application.Dogs.Commands.CreateDog
{
    public class CreateDogCommandHandler : IRequestHandler<CreateDogCommand, Guid>
    {
        private readonly IDogsDbContext _dbContext;

        public CreateDogCommandHandler(IDogsDbContext dbContext) => _dbContext = dbContext;


        public async Task<Guid> Handle(CreateDogCommand request, CancellationToken cancellationToken)
        {
            var dog = new Dog
            {
                UserId = request.UserId,
                Id = Guid.NewGuid(),
                Name = request.Name,
                Color = request.Color,
                TailLength = request.TailLength,
                Weight = request.Weight,
            };

            await _dbContext.Dogs.AddAsync(dog, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return dog.Id;
        }
    }
}

   
