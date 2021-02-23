using System.Threading.Tasks;
using System.Windows;
using SimpleTrader.Domain.Models;
using SimpleTrader.WPF.Commands.Customs;
using SimpleTrader.WPF.State.Authenticator;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands
{
	public class LogInCommand :CustomCommand
	{
		private LogInViewModel _logInViewModel;
		private IAuthenticator _authenticator;
		private readonly IReNavigator _reNavigator;

		public LogInCommand(LogInViewModel logInViewModel, IAuthenticator authenticator,
			IReNavigator reNavigator)
		{
			_logInViewModel = logInViewModel;
			_authenticator = authenticator;
			_reNavigator = reNavigator;
		}


		public override async void Execute(object parameter)
		{
			string userName = _logInViewModel.UserName;
			if (await _authenticator.Login(userName, parameter.ToString()))
			{
				_reNavigator.ReNavigate(ViewType.About);
			}

		}
	}
}
