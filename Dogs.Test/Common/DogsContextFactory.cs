using Microsoft.EntityFrameworkCore;
using DogsService.Domain;
using DogsService.Persistence;

namespace Dogs.Test.Common
{
    public class DogsContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid DogIdForDelete = Guid.NewGuid();
        public static Guid DogIdForUpdate = Guid.NewGuid();

        public static DogsDbContext Create()
        {
            var options = new DbContextOptionsBuilder<DogsDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new DogsDbContext(options);
            context.Database.EnsureCreated();

            context.Dogs.AddRange(
                new Dog
                {
                    Id = Guid.Parse("A6BB65BB-5AC2-4AFA-8A28-2616F675B825"),
                    UserId = UserAId,
                    Name = "Neo",
                    Color = "red & amber",
                    TailLength = 22,
                    Weight = 32
                },
                new Dog
                {
                    Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084"),
                    UserId = UserBId,
                    Name = "Jessy",
                    Color = "black & white",
                    TailLength = 7,
                    Weight = 14
                },
                new Dog
                {
                    Id = DogIdForDelete,
                    UserId = UserAId,
                    Name = "Archibald",
                    Color = "pink",
                    TailLength = 20,
                    Weight = 28
                },
                new Dog
                {
                    Id = DogIdForUpdate,
                    UserId = UserBId,
                    Name = "Frodo",
                    Color = "yellow",
                    TailLength = 12,
                    Weight = 32
                }
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(DogsDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}