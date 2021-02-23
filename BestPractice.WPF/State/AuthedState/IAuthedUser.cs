using System.Collections.Generic;
using SimpleTrader.Domain.Models;
using SimpleTrader.WPF.Models;

namespace SimpleTrader.WPF.State.AuthedState
{
	public interface IAuthedUser : IObservableAction
	{
		public Account CurrentAccount { get; set; }
		public User CurrentUser { get; }
		public bool IsLoggedIn { get; }
		public decimal AccountBalance { get; }
		public IEnumerable<AssetTransaction> AssetTransactions { get; }
	}
}
