using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.Models;

namespace SimpleTrader.WPF.ViewModels
{

	public class MajorIndexViewModel : ViewModelsBase
	{
		private readonly IMajorIndexService _majorIndexService;

		private MajorIndex _sp500;

		public MajorIndex Sp500
		{
			get => _sp500;
			set
			{
				_sp500 = value;
				OnPropertyChanged(nameof(Sp500));
			}
		}

		private MajorIndex _dowJones;

		public MajorIndex DowJones
		{
			get => _dowJones;
			set
			{
				_dowJones = value; 
				OnPropertyChanged(nameof(_dowJones));

			}
		}

		private MajorIndex _nasdaq;

		public MajorIndex Nasdaq
		{
			get => _nasdaq;
			set
			{
				_nasdaq = value; 
				OnPropertyChanged(nameof(Nasdaq));

			}
		}


		public MajorIndexViewModel(IMajorIndexService majorIndexService)
		{
			_majorIndexService = majorIndexService;
		}

		public static MajorIndexViewModel LoadMajorIndexViewModel(IMajorIndexService majorIndexService)
		{
			MajorIndexViewModel majorIndexViewModel = new MajorIndexViewModel(majorIndexService);
			majorIndexViewModel.LoadMajorIndexes();
			return majorIndexViewModel;
		}

		private void LoadMajorIndexes()
		{
			 _majorIndexService.GetMajorIndex(MajorIndexType.sp500).ContinueWith(i =>
			 {
				 if (i.Exception != null) return;
				 Sp500 = i.Result;
				 OnPropertyChanged(nameof(Sp500));
			 });
			_majorIndexService.GetMajorIndex(MajorIndexType.DowJones).ContinueWith(i =>
			{
				if (i.Exception != null) return;
				DowJones = i.Result;
				OnPropertyChanged(nameof(DowJones));


			});
			_majorIndexService.GetMajorIndex(MajorIndexType.Nasdaq).ContinueWith(i =>
			{
				if (i.Exception != null) return;
				Nasdaq = i.Result;
				OnPropertyChanged(nameof(Sp500));

			});
		}
	}
}
