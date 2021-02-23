using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.WPF.Models
{
	public class ObservableAction
	{
		public virtual event Action Observer;

		protected virtual void NotifyObserver()
		{
			Observer?.Invoke();
		}
	}

	public interface IObservableAction
	{
		public event Action Observer;
	}

}
