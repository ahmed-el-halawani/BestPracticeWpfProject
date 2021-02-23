using SimpleTrader.WPF.Models;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.State.NavigatorState
{
	public class NavigatorState : ObservableAction,INavigatorState
	{

		public ViewModelsBase CurrentViewModel
		{
			get => _currentViewModel;
			set
			{
				_currentViewModel = value;
				NotifyObserver();
			}
		}

		private ViewModelsBase _currentViewModel;

	}
}
