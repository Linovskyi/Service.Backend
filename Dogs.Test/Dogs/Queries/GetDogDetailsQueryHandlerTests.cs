using AutoMapper;
using Dogs.Test.Common;
using DogsService.Application.Dogs.Queries.GetDogDetails;
using DogsService.Persistence;
using Shouldly;

namespace Dogs.Test.Dogs.Queries
{
    [Collection("QueryCollection")]
    public class GetDogDetailsQueryHandlerTests
    {
        private readonly DogsDbContext Context;
        private readonly IMapper Mapper;

        public GetDogDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetNoteDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetDogDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetDogDetailsQuery
                {
                    UserId = DogsContextFactory.UserBId,
                    Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084")
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<DogDetailsVm>();
            result.Name.ShouldBe("Jessy");
            result.Color.ShouldBe("black & white");
            result.TailLength.ShouldBe(7);
            result.Weight.ShouldBe(14);

        }
    }
}