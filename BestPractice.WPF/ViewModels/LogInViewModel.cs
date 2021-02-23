using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.Models;
using SimpleTrader.WPF.Models.Authenticator;
using SimpleTrader.WPF.State.CustomNav;
using SimpleTrader.WPF.State.Navigators;

namespace SimpleTrader.WPF.ViewModels
{
	public class LogInViewModel : ViewModelsBase
	{
		public LogInViewModel(IAuthenticator authenticator, CustomNav customNav) => 
			LogInCommand = new LogInCommand(this, authenticator, customNav);

		private string _userName;
		public string UserName
		{
			get => _userName;
			set
			{
				_userName = value;
				OnPropertyChanged(nameof(UserName));
			}
		}

		public ICommand LogInCommand { get; set; }
	}
}
