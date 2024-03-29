﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.Models;
using SimpleTrader.WPF.Models.Authenticator;
using SimpleTrader.WPF.Models.Navigator;

namespace SimpleTrader.WPF.ViewModels
{
	public class LogInViewModel : ViewModelsBase
	{
		public ICommand LogInCommand { get; set; }

		public ICommand GoToRegister { get; }

		public string UserName
		{
			get => _userName;
			set
			{
				_userName = value;
				OnPropertyChanged(nameof(UserName));
			}
		}

		private string _password;

		public string Password
		{
			get => _password;
			set
			{
				_password = value;
				OnPropertyChanged(nameof(Password));
			}
		}

		public LogInViewModel(IAuthenticator authenticator, INavigator navigator)
		{
			LogInCommand = new LogInCommand(this, authenticator, navigator);

			GoToRegister = new NavigateCommand(navigator);
		}

		private string _userName;
		
	}
}
