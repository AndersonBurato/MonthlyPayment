using Microsoft.Extensions.DependencyInjection;
using TRex.MPS.Employee;
using TRex.MPS.Login;
using TRex.MPS.Model.Configuration;
using TRex.MPS.Payment;

namespace TRex.MPS.Config;

public static class IoC
{
    private const string DataBaseConnectionString = "DataBaseConnectionString";
    private static ServiceProvider ServiceProvider;

    public static T GetForm<T>() where T : Form
    {
        return ServiceProvider.GetRequiredService<T>();
    }

    public static void Init()
    {
        var services = new ServiceCollection();
        RegisterForms(services);

        var appSettings = new AppSettings
        {
            DataBaseSettings = new DataBaseSettings
            {
                ConnectionString =
                    "Data Source=DESKTOP-634HNEN;Initial Catalog=TRex;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"
            }
        };

        services.AddSingleton(appSettings);

        services
            .ConfigurePaymentServices()
            .ConfigureLoginServices()
            .ConfigureEmployeeServices();

        ServiceProvider = services.BuildServiceProvider();
    }

    private static void RegisterForms(IServiceCollection services)
    {
        services.AddSingleton<MainForm>();
        services.AddTransient<LoginForm>();
        services.AddTransient<PaymentsForm>();
        services.AddTransient<ClaimSalaryForm>();
        services.AddTransient<ClaimedPaymentForm>();
    }
}