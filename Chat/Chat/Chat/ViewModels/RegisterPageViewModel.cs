using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Chat.Validations;
using Prism.Navigation;

namespace Chat.ViewModels
{
	public class RegisterPageViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;
		private ValidatableObject<string> _userName;
		private ValidatableObject<string> _password;
		private ValidatableObject<string> _passwordConfirmation;

		public ValidatableObject<string> UserName
		{
			get => _userName;
			set => SetProperty(ref _userName, value);
		}

		public ValidatableObject<string> Password
		{
			get => _password;
			set => SetProperty(ref _password, value);
		}

		public ValidatableObject<string> PasswordConfirmation
		{
			get => _passwordConfirmation;
			set => SetProperty(ref _passwordConfirmation, value);
		}

		public ICommand ValidateUserNameCommand => new DelegateCommand(ValidateUsername);
		public ICommand ValidatePasswordCommand => new DelegateCommand(ValidatePassword);
		public ICommand ValidatePasswordConfirmationCommand => new DelegateCommand(ValidatePasswordConfirmation);
		public ICommand NavigateToLoginCommand => new DelegateCommand(Login);

		public RegisterPageViewModel(INavigationService navigationService) 
			: base(navigationService)
		{
			_navigationService = navigationService;

			_userName = new ValidatableObject<string>();
			AddEmailValidations();

			_password = new ValidatableObject<string>();
			AddPasswordValidations();

			_passwordConfirmation = new ValidatableObject<string>();
			AddPasswordConfrimationValidations();
		}

		private void ValidatePassword()
		{
			_password.Validate();
		}

		private void ValidateUsername()
		{
			_userName.Validate();
		}

		private void ValidatePasswordConfirmation()
		{
			_passwordConfirmation.Validate(_password.Value);
		}


		private void AddEmailValidations()
		{
			_userName.Validations.Add(new EmailValidation<string>());
		}

		private void AddPasswordValidations()
		{
			_password.Validations.Add(new PasswordValidation<string>());
		}

		private void AddPasswordConfrimationValidations()
		{
			_passwordConfirmation.Validations.Add(new PasswordConfirmationValidation<string>());
		}


		private void Login()
		{
			_navigationService.GoBackAsync();
		}
	}
}
