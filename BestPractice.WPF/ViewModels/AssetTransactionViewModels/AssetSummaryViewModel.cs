using System.Collections.ObjectModel;
using System.Linq;
using SimpleTrader.WPF.State.AuthedState;

namespace SimpleTrader.WPF.ViewModels.AssetTransactionViewModels
{
	public class AssetSummaryViewModel : ViewModelsBase
	{
		public decimal AccountBalance => _authedUser.AccountBalance;

		public ObservableCollection<AssetViewModel> Assets { get;}

		public AssetSummaryViewModel(IAuthedUser authedUser)
		{
			_authedUser = authedUser;

			Assets = new ObservableCollection<AssetViewModel>();

			CurrentAccountChangeNotify();

			_authedUser.Observer += CurrentAccountChangeNotify;
		}

		private void CurrentAccountChangeNotify()
		{
			var assetViewModels = _authedUser
				.AssetTransactions
				.GroupBy(a => a.Asset.Symbol)
				.OrderBy(i=>i.Sum
						(
						i => 
							i.IsPurchase 
								? i.Shares 
								: -i.Shares
						)
					)
				.Take(3)
				.Select
				(g => new AssetViewModel()
					{
						Symbol = g.Key,
						Shares = g.Sum(i => i.IsPurchase ? i.Shares : -i.Shares)
					}
				);

			Assets.Clear();
			foreach (var assetViewModel in assetViewModels)
			{
				Assets.Add(assetViewModel);
			}
		}
		
		private readonly IAuthedUser _authedUser;

	}
}
