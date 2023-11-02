using Microsoft.Extensions.DependencyInjection;
using QuadraticEquationSolver.Service.UserDialogService;

namespace QuadraticEquationSolver.Service
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IUserDialogService, WindowsUserDialogService>();
            return services;
        }
    }
}