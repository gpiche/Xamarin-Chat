using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;
using System.Windows.Input;
using Chat.DTO;
using Chat.Services;
using Chat.Validations;
using Prism.Navigation;

namespace Chat.ViewModels
{
	public class RegisterPageViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;
		private readonly IRessourceService _ressourceService;
		private ValidatableObject<string> _userName;
		private ValidatableObject<string> _password;
		private ValidatableObject<string> _passwordConfirmation;
		private ValidatableObject<string> _firstName;
		private ValidatableObject<string> _lastName;

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

		public ValidatableObject<string> FirstName
		{
			get => _firstName;
			set => SetProperty(ref _firstName, value);
		}

		public ValidatableObject<string> LastName
		{
			get => _lastName;
			set => SetProperty(ref _lastName, value);
		}

		public ICommand ValidateUserNameCommand => new DelegateCommand(ValidateUsername);
		public ICommand ValidatePasswordCommand => new DelegateCommand(ValidatePassword);
		public ICommand ValidatePasswordConfirmationCommand => new DelegateCommand(ValidatePasswordConfirmation);
		public ICommand ValidateFirstNameCommand => new DelegateCommand(ValidateFirstName);
		public ICommand ValidateLastNameCommand => new DelegateCommand(ValidateLastName);
		public ICommand NavigateToLoginCommand => new DelegateCommand(Login);
		public ICommand RegisterCommand { get; set; }
	

		public RegisterPageViewModel(INavigationService navigationService, IRessourceService ressourceService) 
			: base(navigationService)
		{
			_navigationService = navigationService;
			_ressourceService = ressourceService;

			_userName = new ValidatableObject<string>();
			_password = new ValidatableObject<string>();
			_passwordConfirmation = new ValidatableObject<string>();
			_firstName = new ValidatableObject<string>();
			_lastName  = new ValidatableObject<string>();

			RegisterCommand = new Command(
				execute: Register,
				canExecute: CanExecuteRegisterCommand
			);

			AddValidations();
	
		}

		private void Register()
		{
	
				var registrationInformation = new RegistrationInformationDTO
				{
					Email = _userName.Value,
					Password = _password.Value,
					FirstName = FirstName.Value,
					LastName = LastName.Value
				};
				_ressourceService.Register(registrationInformation);
			
		}

		public bool CanExecuteRegisterCommand()
		{
		    if (_userName.IsValid && _password.IsValid && _passwordConfirmation.IsValid && _firstName.IsValid &&
		        _lastName.IsValid)
		    {
		        return true;
		    }

		    return false;
		}


		private void ValidatePassword()
		{
			_password.Validate();
			RefreshCanExecutes();

		}

		private void ValidateUsername()
		{
			_userName.Validate();
			RefreshCanExecutes();

		}

		private void ValidatePasswordConfirmation()
		{
			_passwordConfirmation.Validate(_password.Value);
			RefreshCanExecutes();

		}

		private void ValidateFirstName()
		{
			_firstName.Validate(_firstName.Value);
			RefreshCanExecutes();
		}

		private void ValidateLastName()
		{
			_lastName.Validate(_lastName.Value);
			RefreshCanExecutes();
		}

		private void AddValidations()
		{
			_userName.Validations.Add(new EmailValidation<string>());
			_password.Validations.Add(new PasswordValidation<string>());
			_passwordConfirmation.Validations.Add(new PasswordConfirmationValidation<string>());
			_firstName.Validations.Add(new RegularTextFieldValidation<string>());
			_lastName.Validations.Add(new RegularTextFieldValidation<string>());
		}

		private void Login()
		{
			_navigationService.GoBackAsync();
		}


		private void RefreshCanExecutes()
		{
			((Command)RegisterCommand).ChangeCanExecute();
		}
	}
}
