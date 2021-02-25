using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore.Metadata;
using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.Models.Authenticator;
using SimpleTrader.WPF.Models.Navigator;

namespace SimpleTrader.WPF.ViewModels
{
	class RegisterViewModel : ViewModelsBase
	{

		public string Email
		{
			get => _email;
			set
			{
				_email = value;
				OnPropertyChanged(nameof(Email));
			}
		}

		public string UserName
		{
			get => _userName;
			set
			{
				_userName = value;
				OnPropertyChanged(nameof(UserName));
			}
		}

		public string Password
		{
			get => _password;
			set
			{
				_password = value; 
				OnPropertyChanged(nameof(Password));
			}
		}

		public string ConfirmPassword
		{
			get => _confirmPassword;
			set
			{
				_confirmPassword = value; 
				OnPropertyChanged(nameof(ConfirmPassword));
			}
		}

		public ICommand RegisterCommand { get;}

		public ICommand GoToLogin { get; }

		private string _email;
		private string _userName;
		private string _password;
		private string _confirmPassword;

		public RegisterViewModel(INavigator navigator, IAuthenticator authenticator)
		{
			RegisterCommand = new RegisterCommand(navigator,authenticator,this);
			GoToLogin = new NavigateCommand(navigator);
		}
	}
}
