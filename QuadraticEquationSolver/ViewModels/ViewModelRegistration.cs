using Microsoft.Extensions.DependencyInjection;
using QuadraticEquationSolver.ViewModels.MainWindowVm;

namespace QuadraticEquationSolver.ViewModels
{
    public static class ViewModelRegistration
    {
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            return services;
        }
    }
}