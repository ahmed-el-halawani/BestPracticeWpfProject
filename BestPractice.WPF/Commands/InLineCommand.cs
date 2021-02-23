using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using SimpleTrader.WPF.Commands.Customs;

namespace SimpleTrader.WPF.Commands
{

	public delegate void ExecuteIt(object parameter);
	public delegate bool CanExecuteIt(object parameter);

	public class InLineCommand : CustomCommand
	{
		private readonly CanExecuteIt _canExecuteIt;
		private readonly ExecuteIt _executeIt;

		public InLineCommand(ExecuteIt executeIt, CanExecuteIt canExecuteIt = null)
		{
			_canExecuteIt = canExecuteIt;
			_executeIt = executeIt;
		}

		public override bool CanExecute(object parameter) =>_canExecuteIt?.Invoke(parameter) ?? true;

		public override void Execute(object parameter) => _executeIt(parameter);
	}
}
