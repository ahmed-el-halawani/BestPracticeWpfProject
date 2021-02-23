using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.Models.Navigator;
using SimpleTrader.WPF.State.NavigatorState;
using SimpleTrader.WPF.ViewModels.MVSwitcher;

namespace SimpleTrader.WPF.ViewModels
{
	public enum ViewType
	{
		Home,About,Buy,Login,Register
	}
	public class NavigatorViewModel : ViewModelsBase
	{
		public ICommand UpdateCurrentViewModelCommand { get; set; }
		public ViewModelsBase CurrentViewModel => _navigatorState.CurrentViewModel;

		public NavigatorViewModel(INavigatorState navigatorState,IViewModelSwitcher viewModelAbstractFactory,Navigator navigator)
		{
			_navigatorState = navigatorState;
			_viewModelAbstractFactory = viewModelAbstractFactory;
			_navigator = navigator;

			Actions();

			Commands();
		}

		private void Actions()
		{
			_navigator.CurrentViewModelChanged += ChangeViewModel;
			_navigatorState.Observer += () => { OnPropertyChanged(nameof(CurrentViewModel));};
		}

		private readonly INavigatorState _navigatorState;
		private readonly IViewModelSwitcher _viewModelAbstractFactory;
		private readonly Navigator _navigator;

		private void ChangeViewModel()
		{
			_navigatorState.CurrentViewModel =  _viewModelAbstractFactory.GetViewModel(_navigator.CurrentViewType);
		}

		private void Commands()
		{
			UpdateCurrentViewModelCommand = new NavigateCommand(_navigator);
		}
	}
}
