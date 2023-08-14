using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Services;

namespace Persistence
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServer");
            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(connectionString));

            services.AddScoped<IApplicationDbContext, DataContext>();
            services.AddScoped<ICSVService, CSVService>();
        }
    }
}