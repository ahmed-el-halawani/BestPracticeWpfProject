using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.State.Authenticator;
using SimpleTrader.WPF.State.Navigators;

namespace SimpleTrader.WPF.ViewModels
{
	public class LogInViewModel : ViewModelsBase
	{
		private readonly IAuthenticator _authenticator;
		private readonly IReNavigator _reNavigator;

		public LogInViewModel(IAuthenticator authenticator, IReNavigator reNavigator)
		{
			_authenticator = authenticator;
			_reNavigator = reNavigator;
			LogInCommand = new LogInCommand(this, authenticator,reNavigator);
		}


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
