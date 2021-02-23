using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.WPF.ViewModels.factories
{
	public class AboutViewModelFactory : IViewModelFactory<AboutViewModel>
	{
		public AboutViewModel CreateViewModel()
		{
			return new AboutViewModel();
		}
	}
}
