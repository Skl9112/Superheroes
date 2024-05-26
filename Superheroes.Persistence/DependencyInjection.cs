using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Superheroes.Persistence.Data;
using Superheroes.Domain.Abstractions;
using Superheroes.Persistence.Repositories;

namespace Superheroes.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, FakeUnitOfWork>();
            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services, DbContextOptions options)
        {
            services.AddPersistence()
                    .AddSingleton(new AppDbContext((DbContextOptions<AppDbContext>)options));
            return services;
        }
    }
}
