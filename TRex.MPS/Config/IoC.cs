using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using TRex.MPS.Model.Configuration;
using TRex.MPS.Payment;
using TRex.MPS.Login;
using TRex.MPS.Employee;

namespace TRex.MPS.Config
{
    public static class IoC
    {
        private const string DataBaseConnectionString = "DataBaseConnectionString";
        private static ServiceProvider ServiceProvider = null;

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
                    ConnectionString = ConfigurationManager.AppSettings[DataBaseConnectionString] ?? throw new ConfigurationErrorsException($"Missing {DataBaseConnectionString}")
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
        }
    }
}