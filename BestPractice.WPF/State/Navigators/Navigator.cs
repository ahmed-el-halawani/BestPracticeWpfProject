using SimpleTrader.WPF.Models;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.State.Navigators
{
	public class Navigator : ObservableObject,INavigator
	{
		private ViewModelsBase _currentViewModel;

		public ViewModelsBase CurrentViewModel
		{
			get => _currentViewModel;
			set
			{
				_currentViewModel = value;
				OnPropertyChanged(nameof(CurrentViewModel));
			}
		}

	}
}
