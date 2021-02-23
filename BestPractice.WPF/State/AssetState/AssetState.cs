using System.Collections.Generic;
using SimpleTrader.Domain.Models;
using SimpleTrader.WPF.Models;
using SimpleTrader.WPF.State.AuthedState;

namespace SimpleTrader.WPF.State.AssetState
{
	class AssetState : ObservableAction
	{


		public AssetState(IAuthedUser authedUser)
		{
			_authedUser = authedUser;
		}

		private readonly IAuthedUser _authedUser;

	}
}
