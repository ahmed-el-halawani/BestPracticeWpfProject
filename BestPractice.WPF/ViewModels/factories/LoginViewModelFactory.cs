using System;
using System.Collections.Generic;
using System.Text;
using SimpleTrader.WPF.State.Authenticator;
using SimpleTrader.WPF.State.Navigators;

namespace SimpleTrader.WPF.ViewModels.factories
{
	public class LoginViewModelFactory : IViewModelFactory<LogInViewModel>
	{

		private readonly IAuthenticator _authenticator;
		private readonly IReNavigator _reNavigator;

		public LoginViewModelFactory(IAuthenticator authenticator,IReNavigator reNavigator)
		{
			_authenticator = authenticator;
			_reNavigator = reNavigator;
		}

		public LogInViewModel CreateViewModel()
		{
			return new LogInViewModel(_authenticator,_reNavigator);
		}
	}
}
