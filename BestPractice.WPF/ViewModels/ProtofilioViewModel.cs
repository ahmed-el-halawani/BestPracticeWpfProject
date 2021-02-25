using System;
using System.Collections.Generic;
using System.Text;
using SimpleTrader.WPF.ViewModels.AssetTransactionViewModels;

namespace SimpleTrader.WPF.ViewModels
{
	public class ProtofilioViewModel : ViewModelsBase
	{
		public AllAssetViewModel AllAssetViewModel{get;set;}

		public ProtofilioViewModel(AllAssetViewModel allAssetViewModel)
		{
			AllAssetViewModel = allAssetViewModel;
		}
	}
}
