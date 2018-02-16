using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Windows.Input;
using Chat.Services;
using Plugin.Toasts;
using Xamarin.Forms;

namespace Chat.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly INotificationService _notificationService;
        private readonly INavigationService _navigationService;
                private string _userName;
        private string _password;
        private string _errorMessage;

        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        public ICommand AuthenticateCommand => new DelegateCommand(Authenticate);
        public ICommand NavigateToRegisterCommand => new DelegateCommand(Register);

   
        public LoginPageViewModel(INavigationService navigationService, INotificationService notificationService) 
            : base (navigationService)
        {
            _notificationService = notificationService;
            _navigationService = navigationService;
            IsPlayServicesAvailable();
        }


        private void Authenticate()
        {
            //Todo add real validation
            if (UserName == "123" && Password == "1234")
            {
              
            }
            else
            {
                ErrorMessage = "Wrong user name or password.";
            }
        }


        private void Register()
        {
            _navigationService.NavigateAsync("RegisterPage");
        }

    
        private void IsPlayServicesAvailable()
        {
            _notificationService.IsPlayServicesAvailable();
        }
    }
}
