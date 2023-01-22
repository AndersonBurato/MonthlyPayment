using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRex.MPS.Payment.DataService;
using TRex.MPS.Payment.Service;

namespace TRex.MPS.Payment
{
    public static class Startup
    {
        public static IServiceCollection ConfigurePaymentServices(this IServiceCollection services)
        {
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentDataService, PaymentDataService>();

            return services;
        }
    }
}
