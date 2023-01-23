using Microsoft.Extensions.DependencyInjection;
using TRex.MPS.Payment.DataService;
using TRex.MPS.Payment.Service;

namespace TRex.MPS.Payment;

public static class Startup
{
    public static IServiceCollection ConfigurePaymentServices(this IServiceCollection services)
    {
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<IPaymentDataService, PaymentDataService>();

        return services;
    }
}