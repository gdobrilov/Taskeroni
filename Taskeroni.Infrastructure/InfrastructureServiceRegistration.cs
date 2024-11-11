using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Taskeroni.Core.Factories;
using Taskeroni.Core.Factories.Interfaces;
using Taskeroni.Core.Interfaces;
using Taskeroni.Infrastructure.Data;
using Taskeroni.Infrastructure.Repositories;

namespace Taskeroni.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TaskeroniDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddScoped<ITodoTaskRepository, TodoTaskRepository>();

            services.AddScoped<ITodoTaskFactory, TodoTaskFactory>();

            return services;
        }
    }
}
