using QuadraticEquationSolver.Infrastructure.Commands;
using QuadraticEquationSolver.Model;
using QuadraticEquationSolver.Model.AppSettings.AppConfig;
using QuadraticEquationSolver.Service.UserDialogService;
using QuadraticEquationSolver.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace QuadraticEquationSolver.ViewModels.MainWindowVm
{
    internal class MainWindowViewModel : BaseViewModel
    {
        private readonly IAppConfig _appConfig;
        private readonly IUserDialogService _userDialogService;
        private QuadraticEquation _quadraticEquation = new();

        /* ------------------------------------------------------------------------------------------------------------ */
        public MainWindowViewModel(IUserDialogService userDialogService)
        {
            _log.Debug($"Вызов конструктора {GetType().Name}");
            _appConfig = AppConfig.GetConfigFromDefaultPath();
            _userDialogService = userDialogService;

            #region Commands
            Exit = new RelayCommand(OnExitExecuted, CanExitExecute);
            #endregion

        }

        /// <summary>
        /// Действия выполняемые при закрытии основной формы
        /// </summary>
        public void OnExit()
        {
            //_projectConfigurationRepository?.Save();
        }
        /* ------------------------------------------------------------------------------------------------------------ */
        #region Commands

        #region Exit
        public ICommand Exit { get; }
        private void OnExitExecuted(object p) => Application.Current.Shutdown();
        private bool CanExitExecute(object p) => true;
        #endregion

        #endregion

        /* ------------------------------------------------------------------------------------------------------------ */
        #region Window title

        private string _title = $"{AppConst.Get().AppDesciption} {ProjectVersion.Get()}";
        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string Title
        {
            get => _title;
            set
            {
                if(Set(ref _title, value, title => !string.IsNullOrWhiteSpace(title)))
                    OnPropertyChanged(nameof(TitleLength));
            }
        }

        public int TitleLength => Title.Length;
        #endregion


        #region User name

        public string UserName
        {
            get => Get<string>();
            set => Set(value);
        }

        #endregion

        public double A
        {
            get => _quadraticEquation.A;
            set
            {
                if(!Set(value, _quadraticEquation.A, v => _quadraticEquation.A = v)) 
                     return;
                OnPropertyChanged(nameof(X1));
                OnPropertyChanged(nameof(X2));
            }
        }
        public double B 
        { 
            get => _quadraticEquation.B;
            set
            {
                if (!Set(value, _quadraticEquation.B, v => _quadraticEquation.B = v)) 
                    return;
                OnPropertyChanged(nameof(X1));
                OnPropertyChanged(nameof(X2));
            }
        }
        
        public double C 
        { 
            get => _quadraticEquation.C;
            set
            {
                if (!Set(value, _quadraticEquation.C, v => _quadraticEquation.C = v))
                    return;
                OnPropertyChanged(nameof(X1));
                OnPropertyChanged(nameof(X2));
            }
        
        }


        public double X1 => _quadraticEquation.X1;
        public double X2 => _quadraticEquation.X2;


    }
}