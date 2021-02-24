using SimpleTrader.WPF.ViewModels.AssetTransactionViewModels;

namespace SimpleTrader.WPF.ViewModels
{
	public class HomeViewModel : ViewModelsBase
	{
		public MajorIndexViewModel MajorIndexViewModel { get; set; }

		public AssetSummaryViewModel AssetTransactionViewModel { get; set; }

		public HomeViewModel(MajorIndexViewModel majorIndexViewModel,AssetSummaryViewModel assetTransactionViewModel)
		{
			MajorIndexViewModel = majorIndexViewModel;
			AssetTransactionViewModel = assetTransactionViewModel;
		}
	}
}
