using System;
using System.Collections.Generic;
using System.Text;
using SimpleTrader.WPF.ViewModels.factories;

namespace SimpleTrader.WPF.ViewModels
{
	public class HomeViewModel : ViewModelsBase
	{
		public MajorIndexViewModel MajorIndexViewModel { get; set; }


		public HomeViewModel(MajorIndexViewModel majorIndexViewModel)
		{
			MajorIndexViewModel = majorIndexViewModel;
			Title = "mohamed";
		}



	}
}
