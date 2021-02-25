using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SimpleTrader.WPF.State.AuthedState;

namespace SimpleTrader.WPF.ViewModels.AssetTransactionViewModels
{
	public class AllAssetViewModel : AssetViewModelListFactory
	{
		public AllAssetViewModel(IAuthedUser authedUser) : base(authedUser)
		{
			CurrentAccountChangeNotify();
		}

		public sealed override void CurrentAccountChangeNotify()
		{
			var assetViewModels = AuthedUser
				.AssetTransactions
				.GroupBy(a => a.Asset.Symbol)
				.OrderByDescending(i=>i.Sum
					(
						assetTransaction => 
							assetTransaction.IsPurchase 
								? assetTransaction.Shares 
								: -assetTransaction.Shares
					)
				)
				.Select
				(g => new AssetViewModel()
					{
						Symbol = g.Key,
						Shares = g.Sum(i => i.IsPurchase ? i.Shares : -i.Shares)
					}
				);

			UpdateList(assetViewModels);
		}
	}
}
