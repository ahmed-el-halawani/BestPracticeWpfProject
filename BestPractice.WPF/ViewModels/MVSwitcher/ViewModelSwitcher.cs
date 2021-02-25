using System;

namespace SimpleTrader.WPF.ViewModels.MVSwitcher
{
	class ViewModelSwitcher : IViewModelSwitcher
	{

		public ViewModelsBase GetViewModel(ViewType viewType)
		{
			return viewType switch
			{
				ViewType.Home => _homeViewModel(),
				ViewType.About => _aboutViewModel(),
				ViewType.Login => _loginViewModel(),
				ViewType.Buy => _buyStockViewModel(),
				ViewType.Register => _registerViewModel(),
				_ => throw new Exception($"View Type Not Existing")
			};
		}

		public ViewModelSwitcher
		(
			ViewModelDelegate<HomeViewModel> homeViewModel, 
			ViewModelDelegate<AboutViewModel> aboutViewModel, 
			ViewModelDelegate<BuyStockViewModel> buyStockViewModel,
			ViewModelDelegate<LogInViewModel> loginViewModel,
			ViewModelDelegate<RegisterViewModel> registerViewModel
		){
			_homeViewModel = homeViewModel;
			_aboutViewModel = aboutViewModel;
			_buyStockViewModel = buyStockViewModel;
			_loginViewModel = loginViewModel;
			_registerViewModel = registerViewModel;
		}

		private readonly ViewModelDelegate<HomeViewModel> _homeViewModel;
		private readonly ViewModelDelegate<AboutViewModel> _aboutViewModel;
		private readonly ViewModelDelegate<BuyStockViewModel> _buyStockViewModel;
		private readonly ViewModelDelegate<LogInViewModel> _loginViewModel;
		private readonly ViewModelDelegate<RegisterViewModel> _registerViewModel;
	}
}
