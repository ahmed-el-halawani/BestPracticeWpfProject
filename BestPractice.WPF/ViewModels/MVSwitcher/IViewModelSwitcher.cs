namespace SimpleTrader.WPF.ViewModels.MVSwitcher
{
	public interface IViewModelSwitcher
	{
		ViewModelsBase GetViewModel(ViewType viewType);
	}
}
