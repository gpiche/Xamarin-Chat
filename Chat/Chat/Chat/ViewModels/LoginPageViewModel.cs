using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Chat.Services;
using Xamarin.Forms;

namespace Chat.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly INotificationService _notificationService;

   
        public LoginPageViewModel(INavigationService navigationService, INotificationService notificationService) 
            : base (navigationService)
        {
            Title = "Main Page";
            _notificationService = notificationService;
            IsPlayServicesAvailable();
        }

    
        private void IsPlayServicesAvailable()
        {
            _notificationService.IsPlayServicesAvailable();
        }
    }
}
