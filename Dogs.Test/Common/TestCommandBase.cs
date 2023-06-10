using DogsService.Persistence;

namespace Dogs.Test.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly DogsDbContext Context;

        public TestCommandBase()
        {
            Context = DogsContextFactory.Create();
        }

        public void Dispose()
        {
            DogsContextFactory.Destroy(Context);
        }
    }
}
