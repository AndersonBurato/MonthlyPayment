using Microsoft.Extensions.DependencyInjection;
using TRex.MPS.Login.DataService;
using TRex.MPS.Login.Service;

namespace TRex.MPS.Login
{
    public static class Statup
    {
        public static IServiceCollection ConfigureLoginServices(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ILoginDataService, LoginDataService>();

            return services;
        }
    }
}