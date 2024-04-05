using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Domain.Abstractions;
using Project.Infrastructure.DataContext;
using Project.Infrastructure.Implementation;

namespace Project.Infrastructiure
{
    public static class Infrastructiure
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("dbcs"));
            });
            services.AddScoped<IUnitOfWorkDb, UnitOfWorkDb>();
            return services;
        }
    }
}
