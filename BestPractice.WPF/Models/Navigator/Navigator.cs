using System;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Models.Navigator
{
	public class Navigator
	{
		public event Action CurrentViewModelChanged;

		public ViewType CurrentViewType
		{
			get => _currentViewType;
			set
			{
				_currentViewType = value;
				OnCurrentViewModelChanged();
			}
		}

		private ViewType _currentViewType;

		protected virtual void OnCurrentViewModelChanged()
		{
			CurrentViewModelChanged?.Invoke();
		}
	}
}
