using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DogsService.Domain;

namespace DogsService.Application.Interfaces
{
    public interface IDogsDbContext
    {
        DbSet<Dog> Dogs { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}



