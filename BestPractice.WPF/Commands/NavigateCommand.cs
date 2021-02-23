using SimpleTrader.WPF.Commands.Customs;
using SimpleTrader.WPF.Models.Navigator;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands
{
	public class NavigateCommand : BaseCommand
	{
		private readonly Navigator _navigator;

		public NavigateCommand(Navigator navigator)
		{
			_navigator = navigator;
		}

		public  override  void Execute(object parameter)
		{
			_navigator.CurrentViewType = (ViewType)parameter;
		}
	}
}
