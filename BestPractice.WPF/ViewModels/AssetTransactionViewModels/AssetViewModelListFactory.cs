using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SimpleTrader.WPF.State.AuthedState;

namespace SimpleTrader.WPF.ViewModels.AssetTransactionViewModels
{
	public class AssetViewModelListFactory : ViewModelsBase
	{
		public decimal AccountBalance => AuthedUser.AccountBalance;

		public ObservableCollection<AssetViewModel> Assets { get;}

		public AssetViewModelListFactory(IAuthedUser authedUser)
		{
			AuthedUser = authedUser;

			Assets = new ObservableCollection<AssetViewModel>();

			AuthedUser.Observer += CurrentAccountChangeNotify;
		}

		public virtual void CurrentAccountChangeNotify(){}

		public void UpdateList(IEnumerable<AssetViewModel> assetViewModels)
		{
			Assets.Clear();
			foreach (var assetViewModel in assetViewModels)
			{
				Assets.Add(assetViewModel);
			}
		}
		public readonly IAuthedUser AuthedUser;
	}
}
