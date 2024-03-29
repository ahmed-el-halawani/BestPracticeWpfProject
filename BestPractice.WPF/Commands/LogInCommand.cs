﻿using System.Threading.Tasks;
using System.Windows;
using SimpleTrader.Domain.Models;
using SimpleTrader.WPF.Commands.Customs;
using SimpleTrader.WPF.Models;
using SimpleTrader.WPF.Models.Authenticator;
using SimpleTrader.WPF.Models.Navigator;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands
{
	public class LogInCommand : NavigateCommand
	{
		private readonly LogInViewModel _logInViewModel;
		private readonly IAuthenticator _authenticator;

		public LogInCommand(LogInViewModel logInViewModel, IAuthenticator authenticator,
			INavigator navigator):base(navigator)
		{
			_logInViewModel = logInViewModel;
			_authenticator = authenticator;
		}

		public override async void Execute(object parameter)
		{
			string userName = _logInViewModel.UserName;
			string password = _logInViewModel.Password;
			await _authenticator.Login(userName, password);
			base.Execute(ViewType.Home);
		}
	}
}
