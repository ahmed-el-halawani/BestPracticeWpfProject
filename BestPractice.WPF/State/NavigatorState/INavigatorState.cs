using SimpleTrader.WPF.Models;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.State.NavigatorState
{
	public interface INavigatorState : IObservableAction
	{
		ViewModelsBase CurrentViewModel { get; set; }
	}
}
