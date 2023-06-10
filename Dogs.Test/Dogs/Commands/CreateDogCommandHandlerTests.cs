using Dogs.Test.Common;
using DogsService.Application.Dogs.Commands.CreateDog;
using Microsoft.EntityFrameworkCore;

namespace Dogs.Test.Dogs.Commands
{
    public class CreateDogCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateDogCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateDogCommandHandler(Context);
            var dogName = "dog name";
            var dogColor = " dog color";
            var dogTailLength = 10;
            var dogWeight = 5;

            // Act
            var dogId = await handler.Handle(
                new CreateDogCommand
                {
                    Name = dogName,
                    Color = dogColor,
                    TailLength = dogTailLength,
                    Weight = dogWeight,
                    UserId = DogsContextFactory.UserAId
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Dogs.SingleOrDefaultAsync(dog =>
                    dog.Id == dogId && dog.Name == dogName &&
                    dog.Color == dogColor &&
                    dog.TailLength == dogTailLength &&
                    dog.Weight == dogWeight));
        }
    }
}
