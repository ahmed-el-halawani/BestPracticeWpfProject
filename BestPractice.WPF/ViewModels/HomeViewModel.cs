using SimpleTrader.WPF.ViewModels.AssetTransactionViewModels;

namespace SimpleTrader.WPF.ViewModels
{
	public class HomeViewModel : ViewModelsBase
	{
		public MajorIndexViewModel MajorIndexViewModel { get; set; }

		public AssetTransactionViewModel AssetTransactionViewModel { get; set; }

		public HomeViewModel(MajorIndexViewModel majorIndexViewModel,AssetTransactionViewModel assetTransactionViewModel)
		{
			MajorIndexViewModel = majorIndexViewModel;
			AssetTransactionViewModel = assetTransactionViewModel;
		}
	}
}
