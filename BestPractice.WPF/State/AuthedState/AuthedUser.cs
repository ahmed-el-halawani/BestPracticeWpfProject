using SimpleTrader.Domain.Models;
using SimpleTrader.WPF.Models;

namespace SimpleTrader.WPF.State.AuthedState
{
	class AuthedUser :ObservableAction,IAuthedUser
	{
		private Account _currentAccount;
		public Account CurrentAccount
		{
			get => _currentAccount;
			set
			{
				_currentAccount = value;
				NotifyObserver();
			}
		}

		public User CurrentUser => CurrentAccount?.AccountHolder;

		public bool IsLoggedIn => CurrentAccount != null;
	}
}
