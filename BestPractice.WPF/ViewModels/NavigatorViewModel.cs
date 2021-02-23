using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.State.CustomNav;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels.factories;

namespace SimpleTrader.WPF.ViewModels
{
	public enum ViewType
	{
		Home,About,Buy,Login,Register
	}
	public class NavigatorViewModel : ViewModelsBase
	{
		public ICommand UpdateCurrentViewModelCommand { get; set; }
		public ViewModelsBase CurrentViewModel => _navigator.CurrentViewModel;

		public NavigatorViewModel(INavigator navigator,IViewModelSwitcher viewModelAbstractFactory,CustomNav customNav)
		{
			_navigator = navigator;
			_viewModelAbstractFactory = viewModelAbstractFactory;
			_customNav = customNav;

			Actions();

			Commands();
		}

		private void Actions()
		{
			_customNav.CurrentViewModelChanged += ChangeViewModel;
			_navigator.Observer += () => { OnPropertyChanged(nameof(CurrentViewModel));};
		}

		private readonly INavigator _navigator;
		private readonly IViewModelSwitcher _viewModelAbstractFactory;
		private readonly CustomNav _customNav;

		private void ChangeViewModel()
		{
			_navigator.CurrentViewModel =  _viewModelAbstractFactory.GetViewModel(_customNav.CurrentViewType);
		}

		private void Commands()
		{
			UpdateCurrentViewModelCommand = new NavigateCommand(_customNav);
		}
	}
}
