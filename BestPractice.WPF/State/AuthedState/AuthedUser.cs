using SimpleTrader.Domain.Models;
using SimpleTrader.WPF.Models;

namespace SimpleTrader.WPF.State.AuthedState
{
	class AuthedUser :ObservableAction,IAuthedUser
	{
		public User CurrentUser => CurrentAccount?.AccountHolder;

		public bool IsLoggedIn => CurrentAccount != null;

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
