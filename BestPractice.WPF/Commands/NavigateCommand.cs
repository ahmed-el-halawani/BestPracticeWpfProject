using SimpleTrader.WPF.Commands.Customs;
using SimpleTrader.WPF.Models.Navigator;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands
{
	public class NavigateCommand : BaseCommand
	{
		private readonly INavigator _navigator;

		public NavigateCommand(INavigator navigator)
		{
			_navigator = navigator;
		}

		public  override  void Execute(object parameter)
		{
			_navigator.CurrentViewType = (ViewType)parameter;
		}
	}
}
