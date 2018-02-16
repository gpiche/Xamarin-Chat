using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Prism.Navigation;

namespace Chat.ViewModels
{
	public class RegisterPageViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;

		public ICommand NavigateToLoginCommand => new DelegateCommand(Login);

		public RegisterPageViewModel(INavigationService navigationService) 
			: base(navigationService)
		{
			_navigationService = navigationService;
		}

		private void Login()
		{
			_navigationService.NavigateAsync("LoginPage");
		}
	}
}
