using Dogs.Test.Common;
using DogsService.Application.Common.Exceptions;
using DogsService.Application.Dogs.Commands.CreateDog;
using DogsService.Application.Dogs.Commands.DeleteCommand;

namespace Dogs.Test.Dogs.Commands
{
    public class DeleteDogCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteDogCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteDogCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteDogCommand
            {
                Id = DogsContextFactory.DogIdForDelete,
                UserId = DogsContextFactory.UserAId
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Dogs.SingleOrDefault(dog =>
                dog.Id == DogsContextFactory.DogIdForDelete));
        }

        [Fact]
        public async Task DeleteDogCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteDogCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteDogCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = DogsContextFactory.UserAId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task DeleteDogCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var deleteHandler = new DeleteDogCommandHandler(Context);
            var createHandler = new CreateDogCommandHandler(Context);
            var dogId = await createHandler.Handle(
                new CreateDogCommand
                {
                    Name = "DogName",
                    Color = "DogColor",
                    TailLength = 15,
                    Weight = 10,
                    UserId = DogsContextFactory.UserAId
                }, CancellationToken.None);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await deleteHandler.Handle(
                    new DeleteDogCommand
                    {
                        Id = dogId,
                        UserId = DogsContextFactory.UserBId
                    }, CancellationToken.None));
        }
    }
}
