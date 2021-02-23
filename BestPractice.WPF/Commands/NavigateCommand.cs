using SimpleTrader.WPF.Commands.Customs;
using SimpleTrader.WPF.State.CustomNav;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands
{
	public class NavigateCommand : BaseCommand
	{
		private readonly CustomNav _customNav;

		public NavigateCommand(CustomNav customNav)
		{
			_customNav = customNav;
		}

		public  override  void Execute(object parameter)
		{
			_customNav.CurrentViewType = (ViewType)parameter;
		}
	}
}
