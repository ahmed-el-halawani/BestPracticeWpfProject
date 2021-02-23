using System;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Models.Navigator
{
	public class Navigator :ObservableAction,INavigator
	{
		public ViewType CurrentViewType
		{
			get => _currentViewType;
			set
			{
				_currentViewType = value;
				NotifyObserver();
			}
		}

		private ViewType _currentViewType;
	}

	public interface INavigator : IObservableAction
	{
		public ViewType CurrentViewType { get; set; }
	}
}
