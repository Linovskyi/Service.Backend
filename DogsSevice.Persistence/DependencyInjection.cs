using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DogsService.Application.Interfaces;

namespace DogsService.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<DogsDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IDogsDbContext>(provider =>
                provider.GetService<DogsDbContext>());
            return services;
        }
    }
}