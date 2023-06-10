using AutoMapper;
using Dogs.Test.Common;
using DogsService.Application.Dogs.Queries.GetDogList;
using DogsService.Persistence;
using Shouldly;

namespace Dogs.Test.Dogs.Queries
{
    [Collection("QueryCollection")]
    public class GetDogListQueryHandlerTests
    {
        private readonly DogsDbContext Context;
        private readonly IMapper Mapper;
        public GetDogListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetDogListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetDogListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetDogListQuery
                {
                    UserId = DogsContextFactory.UserBId
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<DogListVm>();
            result.Dogs.Count.ShouldBe(2);
        }
    }
}