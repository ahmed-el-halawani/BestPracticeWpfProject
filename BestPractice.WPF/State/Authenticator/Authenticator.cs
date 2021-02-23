using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.authentication;
using SimpleTrader.WPF.Models;
using SimpleTrader.WPF.State.Navigators;

namespace SimpleTrader.WPF.State.Authenticator
{
	class Authenticator : ObservableObject,IAuthenticator
	{

		private readonly IAuthenticationService _authenticationService;

		public Authenticator(IAuthenticationService authenticationService)
		{
			_authenticationService = authenticationService;
		}


		public async Task<bool> Login(string userName, string password)
		{
			bool success = true;
			try
			{
				AuthedAccount = await _authenticationService.LogIn(userName, password);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				success = false;
			}
			return success;
		}

		public Task<RegisterResult> Register(string userName, string password, string confirmPassword, string email)
		{
			return _authenticationService.Register(userName,password,confirmPassword,email);
		}

		public void LogOut()
		{
			AuthedAccount = null;
		}

		private Account _authedAccount;
		public Account AuthedAccount
		{
			get => _authedAccount;
			set
			{
				_authedAccount = value;
				
				OnPropertyChanged(nameof(AuthedAccount));
				OnPropertyChanged(nameof(IsLoggedIn));
			}
		}

		public bool IsLoggedIn => AuthedAccount != null;
	}
}
