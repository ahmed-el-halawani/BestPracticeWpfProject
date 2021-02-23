using System;
using System.Collections.Generic;
using System.Text;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.State.Navigators
{
	public interface IReNavigator
	{
		void ReNavigate(ViewType viewType);
	}
}
