using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
