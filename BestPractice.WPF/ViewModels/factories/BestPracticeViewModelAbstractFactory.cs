using System;
using System.Collections.Generic;
using System.Text;
using SimpleTrader.FinancialModelingPrepApi.Services;
using SimpleTrader.WPF.State.Navigators;

namespace SimpleTrader.WPF.ViewModels.factories
{
	class BestPracticeViewModelAbstractFactory : IBestPracticeViewModelsAbstractFactory
	{
		public BestPracticeViewModelAbstractFactory(IViewModelFactory<HomeViewModel> homeViewModelFactory, IViewModelFactory<AboutViewModel> aboutViewModelFactory, BuyStockViewModel buyStockViewModel,IViewModelFactory<LogInViewModel> loginViewModel)
		{
			_homeViewModelFactory = homeViewModelFactory;
			_aboutViewModelFactory = aboutViewModelFactory;
			_buyStockViewModel = buyStockViewModel;
			_loginViewModel = loginViewModel;
		}

		private readonly IViewModelFactory<HomeViewModel> _homeViewModelFactory;
		private readonly IViewModelFactory<AboutViewModel> _aboutViewModelFactory;
		private readonly BuyStockViewModel _buyStockViewModel;
		private readonly IViewModelFactory<LogInViewModel> _loginViewModel;


		public ViewModelsBase GetViewModel(ViewType viewType)
		{
			switch (viewType)
			{
				case ViewType.Home:
					return _homeViewModelFactory.CreateViewModel();
				case ViewType.About:
					return _aboutViewModelFactory.CreateViewModel();
				case ViewType.Login:
					return _loginViewModel.CreateViewModel();
				case ViewType.Buy:
					return _buyStockViewModel;
				
				default:
					throw new Exception($"View Type Not Existing");
			}
		}
	}
}
