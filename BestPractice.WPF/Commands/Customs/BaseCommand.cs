using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SimpleTrader.WPF.Commands.Customs
{
	public abstract class BaseCommand : ICommand
	{
		public virtual bool CanExecute(object parameter)
		{
			return true;
		}

		public virtual void Execute(object parameter)
		{
		}

		public virtual event EventHandler CanExecuteChanged;
	}
}
