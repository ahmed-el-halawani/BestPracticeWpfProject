using System;
using System.Collections.Generic;
using System.Text;
using SimpleTrader.WPF.ViewModels;
using SimpleTrader.WPF.ViewModels.factories;

namespace SimpleTrader.WPF.State.Navigators
{
	class ReNavigator<TVm> : IReNavigator   where TVm : ViewModelsBase
	{
		private readonly INavigator _navigator;
		private readonly IViewModelFactory<TVm> _viewModelFactory;

		public ReNavigator(INavigator navigator,IViewModelFactory<TVm> viewModelFactory)
		{
			_navigator = navigator;
			_viewModelFactory = viewModelFactory;
		}

		public void ReNavigate(ViewType viewType)
		{
			_navigator.CurrentViewModel = _viewModelFactory.CreateViewModel();
		}
	}
}
