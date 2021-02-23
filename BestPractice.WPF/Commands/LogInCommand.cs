using System.Threading.Tasks;
using System.Windows;
using SimpleTrader.Domain.Models;
using SimpleTrader.WPF.Commands.Customs;
using SimpleTrader.WPF.Models;
using SimpleTrader.WPF.Models.Authenticator;
using SimpleTrader.WPF.State.CustomNav;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands
{
	public class LogInCommand : NavigateCommand
	{
		private readonly LogInViewModel _logInViewModel;
		private readonly IAuthenticator _authenticator;

		public LogInCommand(LogInViewModel logInViewModel, IAuthenticator authenticator,
			CustomNav customNav):base(customNav)
		{
			_logInViewModel = logInViewModel;
			_authenticator = authenticator;
		}

		public override async void Execute(object parameter)
		{
			string userName = _logInViewModel.UserName;
			await _authenticator.Login(userName, parameter.ToString());
			base.Execute(ViewType.Home);
		}
	}
}
