using SimpleTrader.WPF.Commands.Customs;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;
using SimpleTrader.WPF.ViewModels.factories;

namespace SimpleTrader.WPF.Commands
{
	public class UpdateCurrentViewModelCommand : BaseCommand
	{
		public UpdateCurrentViewModelCommand(INavigator navigator, IViewModelSwitcher iViewModelAbstractFactory)
		{
			_navigator = navigator;
			_viewModelAbstractFactory = iViewModelAbstractFactory;
		}
		private readonly INavigator _navigator;
		private readonly IViewModelSwitcher _viewModelAbstractFactory;

		public override void Execute(object parameter)
		{
			if (parameter is ViewType v)
					_navigator.CurrentViewModel =  _viewModelAbstractFactory.GetViewModel(v);
		}
	}
}
