using Dogs.Test.Common;
using DogsService.Application.Common.Exceptions;
using DogsService.Application.Dogs.Commands.UpdateDog;
using Microsoft.EntityFrameworkCore;

namespace Dogs.Test.Dogs.Commands
{
    public class UpdateDogCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateDogCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateDogCommandHandler(Context);
            var updateColor = "new color";

            // Act
            await handler.Handle(new UpdateDogCommand
            {
                Id = DogsContextFactory.DogIdForUpdate,
                UserId = DogsContextFactory.UserBId,
                Color = updateColor
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Dogs.SingleOrDefaultAsync(dog =>
                dog.Id == DogsContextFactory.DogIdForUpdate &&
                dog.Color == updateColor));
        }

        [Fact]
        public async Task UpdateDogCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateDogCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateDogCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = DogsContextFactory.UserAId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task UpdateDogCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var handler = new UpdateDogCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new UpdateDogCommand
                    {
                        Id = DogsContextFactory.DogIdForUpdate,
                        UserId = DogsContextFactory.UserAId
                    },
                    CancellationToken.None);
            });
        }
    }
}