using System.Threading.Tasks;
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
        private readonly IAuthorizationService _authorizationService;
        private readonly IAccountStoreService _accountStoreService;
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

   
        public LoginPageViewModel(INavigationService navigationService, INotificationService notificationService, IAuthorizationService authorizationService, IAccountStoreService accountStoreService) 
            : base (navigationService)
        {
            _notificationService = notificationService;
            _navigationService = navigationService;
            _authorizationService = authorizationService;
            _accountStoreService = accountStoreService;
            IsPlayServicesAvailable();
        }


        private async void Authenticate()
        {
            var accestoken = await _authorizationService.AuthenticateAsync(UserName, Password);

            if (!accestoken.IsNullOrEmpty)
            {
                _accountStoreService.SaveCredentials(UserName, accestoken.Token);
            }
            else
            {
                ErrorMessage = "Wrong username or password.";
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
