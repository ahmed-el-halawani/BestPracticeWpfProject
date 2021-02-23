using System;
using SimpleTrader.WPF.Commands.Customs;
using SimpleTrader.WPF.State.Authenticator;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels.factories;

namespace SimpleTrader.WPF.Commands
{
	public class UpdateCurrentViewModelCommand : CustomCommand
	{
		public UpdateCurrentViewModelCommand(INavigator navigator, IBestPracticeViewModelsAbstractFactory iBestPracticeViewModelAbstractFactory)
		{
			_navigator = navigator;
			_bestPracticeViewModelAbstractFactory = iBestPracticeViewModelAbstractFactory;
		}
		private readonly INavigator _navigator;
		private readonly IBestPracticeViewModelsAbstractFactory _bestPracticeViewModelAbstractFactory;

		public override void Execute(object parameter)
		{
			if (parameter is ViewType v)
					_navigator.CurrentViewModel =  _bestPracticeViewModelAbstractFactory.GetViewModel(v);
		}
	}
}
