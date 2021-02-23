using System;
using System.Collections.Generic;
using System.Text;
using SimpleTrader.WPF.Models;

namespace SimpleTrader.WPF.ViewModels
{
	public class ViewModelsBase : ObservableObject
	{


		private string _title = "ahmed";

		public string Title
		{
			get => _title;
			set
			{
				_title = value;
				OnPropertyChanged(nameof(Title));
			}
		}

	}
}
