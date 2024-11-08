using Colegios.Infrastructure.BLL;
using Colegios.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portafolio.Infrastructure.Service;
namespace Colegios.Infrastructure.IOC
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddColegioDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddRepositories(configuration);
            services.AddBussinessLogicLayer(configuration);
            services.AddService();
            return services;
        }
    }
}
