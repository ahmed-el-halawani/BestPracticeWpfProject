using SimpleTrader.WPF.Models;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.State.Navigators
{
	public interface INavigator : IObservableAction
	{
		ViewModelsBase CurrentViewModel { get; set; }
	}
}
