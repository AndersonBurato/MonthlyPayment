using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRex.MPS.Employee.DataService;
using TRex.MPS.Employee.Service;

namespace TRex.MPS.Employee
{
    public static class Startup
    {
        public static IServiceCollection ConfigureEmployeeServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeDataService, EmployeeDataService>();

            return services;
        }
    }
}
