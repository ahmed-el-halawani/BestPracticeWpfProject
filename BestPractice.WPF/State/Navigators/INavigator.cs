using System.Windows.Input;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.State.Navigators
{

	public enum ViewType
	{
		Home,About,Buy,Login,Register
	}

	public interface INavigator
	{
		ViewModelsBase CurrentViewModel { get; set; }

	}
}
