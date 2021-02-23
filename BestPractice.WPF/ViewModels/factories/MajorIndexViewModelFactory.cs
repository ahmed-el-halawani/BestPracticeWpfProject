using System;
using System.Collections.Generic;
using System.Text;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.WPF.ViewModels.factories
{
	public class MajorIndexViewModelFactory : IViewModelFactory<MajorIndexViewModel>
	{

		private readonly IMajorIndexService _majorIndexService;

		public MajorIndexViewModelFactory(IMajorIndexService majorIndexService)
		{
			_majorIndexService = majorIndexService;
		}

		public MajorIndexViewModel CreateViewModel()
		{
			return MajorIndexViewModel.LoadMajorIndexViewModel(_majorIndexService);
		}
	}
}
