using System;
using System.Collections.Generic;
using System.Text;
using SimpleTrader.WPF.State.Navigators;

namespace SimpleTrader.WPF.ViewModels.factories
{
	public interface IViewModelSwitcher
	{
		ViewModelsBase GetViewModel(ViewType viewType);
	}
}
