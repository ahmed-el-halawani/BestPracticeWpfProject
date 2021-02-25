using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SimpleTrader.Domain.Services.authentication;
using SimpleTrader.WPF.Commands.Customs;
using SimpleTrader.WPF.Models.Authenticator;
using SimpleTrader.WPF.Models.Navigator;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands
{
	class RegisterCommand : BaseCommand
	{
		private readonly RegisterViewModel _registerViewModel;
		private INavigator _navigator;
		private readonly IAuthenticator _authenticator;

		public RegisterCommand(INavigator navigator,IAuthenticator authenticator, RegisterViewModel registerViewModel)
		{
			this._navigator = navigator;
			_authenticator = authenticator;
			this._registerViewModel = registerViewModel;
		}

		public override async void Execute(object parameter)
		{
			var userName = _registerViewModel.UserName;
			var password = _registerViewModel.Password;
			var confirmPassword = _registerViewModel.ConfirmPassword;
			var email = _registerViewModel.Email;
			try
			{
				var result = await _authenticator.Register(userName, password, confirmPassword, email);

				switch (result)
				{
					case RegisterResult.Success:
						_navigator.CurrentViewType = ViewType.Login;
						MessageBox.Show("done");
						break;
					case (RegisterResult.EmailIsExist):
						MessageBox.Show("EmailIsExist");
						break;
					case (RegisterResult.PasswordMismatch):
						MessageBox.Show("PasswordMismatch");
						break;
					case (RegisterResult.UserIsExist):
						MessageBox.Show("UserIsExist");
						break;
					default:
						MessageBox.Show("faild");
						break;
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("faild error is : "+e.Message);
			}

		}
	}
}
