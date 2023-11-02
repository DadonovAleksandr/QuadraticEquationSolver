using Microsoft.Extensions.DependencyInjection;
using QuadraticEquationSolver.ViewModels.MainWindowVm;

namespace QuadraticEquationSolver.ViewModels
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel => App.Host.Services.GetRequiredService<MainWindowViewModel>();
    }
}