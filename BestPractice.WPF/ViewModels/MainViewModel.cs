using System.Windows.Input;
using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.Models;
using SimpleTrader.WPF.Models.Navigator;
using SimpleTrader.WPF.State.AuthedState;
using SimpleTrader.WPF.State.NavigatorState;
using SimpleTrader.WPF.ViewModels.MVSwitcher;

namespace SimpleTrader.WPF.ViewModels
{
	public class MainViewModel : NavigatorViewModel
	{
		public bool IsLoggedIn => _authedUser.IsLoggedIn;

		public MainViewModel(INavigatorState navigatorState,IViewModelSwitcher viewModelAbstractFactory,Navigator navigator,IAuthedUser authedUser):base(navigatorState,viewModelAbstractFactory,navigator)
		{
			_authedUser = authedUser;

			Actions();

			navigator.CurrentViewType = ViewType.Login;
		}

		private readonly IAuthedUser _authedUser;

		private void Actions()
		{
			_authedUser.Observer += () => { OnPropertyChanged(nameof(IsLoggedIn));};
		}

	}
}
