using AutoMapper;
using DogsService.Application.Common.Mappings;
using DogsService.Application.Interfaces;
using DogsService.Persistence;

namespace Dogs.Test.Common
{
    public class QueryTestFixture : IDisposable
    {
        public DogsDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = DogsContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IDogsDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            DogsContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}