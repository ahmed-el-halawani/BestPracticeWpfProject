﻿using System.Collections.ObjectModel;
using System.Linq;
using SimpleTrader.WPF.State.AuthedState;

namespace SimpleTrader.WPF.ViewModels.AssetTransactionViewModels
{
	public class AssetSummaryViewModel : AssetViewModelListFactory
	{
		public AssetSummaryViewModel(IAuthedUser authedUser) : base(authedUser)
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

			UpdateList(assetViewModels);
		}

	}
}
