using SimpleTrader.WPF.ViewModels.AssetTransactionViewModels;

namespace SimpleTrader.WPF.ViewModels
{
	public class HomeViewModel : ViewModelsBase
	{
		public MajorIndexViewModel MajorIndexViewModel { get; set; }

		public AssetSummaryViewModel AssetSummaryViewModel { get; set; }

		public HomeViewModel(MajorIndexViewModel majorIndexViewModel,AssetSummaryViewModel assetSummaryViewModel)
		{
			MajorIndexViewModel = majorIndexViewModel;
			AssetSummaryViewModel = assetSummaryViewModel;
		}
	}
}
