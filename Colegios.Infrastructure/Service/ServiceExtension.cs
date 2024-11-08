using Colegios.Core.Interfaces.DataContext;
using Colegios.Core.Interfaces.Services;
using Colegios.Infrastructure.DataContext;
using Colegios.Infrastructure.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Portafolio.Infrastructure.Service
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddService(this IServiceCollection services) 
        {
            services.AddTransient<IExecuteStoredProcedureService, ExecuteStoredProcedureService>();
            services.AddTransient<IlogService, LogService>();
            services.AddTransient<ISqlCommandService,SqlCommandServices>();
            services.AddTransient<IDataContext, DataContext>();

            return services;


        }
    }
}
