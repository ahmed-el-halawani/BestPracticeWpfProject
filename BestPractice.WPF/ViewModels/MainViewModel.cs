using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.State.Authenticator;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels.factories;

namespace SimpleTrader.WPF.ViewModels
{
	public class MainViewModel : ViewModelsBase
	{
		public  IAuthenticator Authenticator { get; set; }

		public INavigator Navigator { get; set; }

		public ICommand UpdateCurrentViewModelCommand { get; set; }


		public MainViewModel()
		{
			
		}

		public MainViewModel(INavigator navigator,IAuthenticator authenticator, IBestPracticeViewModelsAbstractFactory bestPracticeViewModelsAbstractFactory)
		{
			Authenticator = authenticator;
			Navigator = navigator;

			UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator,bestPracticeViewModelsAbstractFactory);

			UpdateCurrentViewModelCommand.Execute(ViewType.Login);
		}

		event Action nav;

		protected virtual void OnNav()
		{
			nav?.Invoke();
		}
	}
}
