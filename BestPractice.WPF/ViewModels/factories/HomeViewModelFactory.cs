using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.WPF.ViewModels.factories
{
	public class HomeViewModelFactory : IViewModelFactory<HomeViewModel>
	{
		private readonly IViewModelFactory<MajorIndexViewModel> _majorIndexViewModelFactory;

		public HomeViewModelFactory(IViewModelFactory<MajorIndexViewModel> majorIndexViewModelFactory)
		{
			_majorIndexViewModelFactory = majorIndexViewModelFactory;
		}


		public HomeViewModel CreateViewModel()
		{
			return new HomeViewModel(_majorIndexViewModelFactory.CreateViewModel());
		}
	}
}
