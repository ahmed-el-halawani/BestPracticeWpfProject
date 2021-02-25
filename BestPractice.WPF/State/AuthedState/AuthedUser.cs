using System.Collections.Generic;
using SimpleTrader.Domain.Models;
using SimpleTrader.WPF.Models;

namespace SimpleTrader.WPF.State.AuthedState
{
	public class AuthedUser :ObservableAction,IAuthedUser
	{
		public User CurrentUser => CurrentAccount?.AccountHolder;

		public bool IsLoggedIn => CurrentAccount != null;

		public decimal AccountBalance => CurrentAccount?.Balance??0;

		public IEnumerable<AssetTransaction> AssetTransactions => CurrentAccount?.AssetTransactions ?? new List<AssetTransaction>();

		public Account CurrentAccount
		{
			get => _currentAccount;
			set
			{
				_currentAccount = value;
				NotifyObserver();
			}
		}

		private Account _currentAccount;

	}
}
