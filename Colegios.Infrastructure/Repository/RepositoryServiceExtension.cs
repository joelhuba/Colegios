using Colegios.Core.Interfaces.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Colegios.Infrastructure.Repository
{
    public static class RepositoryServiceExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddSingleton(configuration);
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRolesRepository, RolesRepository>();
            services.AddTransient<IAuthUserRepository, AuthRepository>();
            return services;
        }
    }
}
