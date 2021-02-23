using System.Windows.Input;
using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.Models;
using SimpleTrader.WPF.State.AuthedState;
using SimpleTrader.WPF.State.CustomNav;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels.factories;

namespace SimpleTrader.WPF.ViewModels
{
	public class MainViewModel : NavigatorViewModel
	{
		public bool IsLoggedIn => _authedUser.IsLoggedIn;

		public MainViewModel(INavigator navigator,IViewModelSwitcher viewModelAbstractFactory,CustomNav customNav,IAuthedUser authedUser):base(navigator,viewModelAbstractFactory,customNav)
		{
			_authedUser = authedUser;

			Actions();

			customNav.CurrentViewType = ViewType.Login;
		}

		private readonly IAuthedUser _authedUser;

		private void Actions()
		{
			_authedUser.Observer += () => { OnPropertyChanged(nameof(IsLoggedIn));};
		}

	}
}
