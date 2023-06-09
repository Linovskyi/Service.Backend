namespace DogsService.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(DogsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
