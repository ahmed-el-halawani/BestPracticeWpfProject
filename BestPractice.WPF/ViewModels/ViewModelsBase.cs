using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using SimpleTrader.WPF.Annotations;
using SimpleTrader.WPF.Models;

namespace SimpleTrader.WPF.ViewModels
{
	public delegate TVm ViewModelDelegate<out TVm>() where TVm : ViewModelsBase;

	public class ViewModelsBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
