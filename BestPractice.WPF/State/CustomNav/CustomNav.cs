using System;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.State.CustomNav
{
	public class CustomNav
	{
		public event Action CurrentViewModelChanged;


		private ViewType _currentViewType;
		public ViewType CurrentViewType
		{
			get => _currentViewType;
			set
			{
				_currentViewType = value;
				OnCurrentViewModelChanged();
			}
		}


		protected virtual void OnCurrentViewModelChanged()
		{
			CurrentViewModelChanged?.Invoke();
		}
	}


}
