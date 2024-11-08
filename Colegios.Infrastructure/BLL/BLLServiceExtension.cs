using Colegios.Core.Interfaces;
using Colegios.Core.Interfaces.BLL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Colegios.Infrastructure.BLL
{
    public static class BLLServiceExtension
    {
        public static IServiceCollection AddBussinessLogicLayer(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddTransient<IRolesBLL, RolesBLL>();
            services.AddTransient<IUserBLL, UserBLL>();
            services.AddTransient<IAuthBLL, AuthBLL>();
            return services;
        }
    }
}
