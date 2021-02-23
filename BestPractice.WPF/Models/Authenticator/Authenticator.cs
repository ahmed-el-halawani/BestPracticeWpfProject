using System;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services.authentication;
using SimpleTrader.WPF.State.AuthedState;

namespace SimpleTrader.WPF.Models.Authenticator
{
	public class Authenticator : IAuthenticator
	{

		private readonly IAuthenticationService _authenticationService;
		private readonly IAuthedUser _authedUser;

		public Authenticator(IAuthenticationService authenticationService,IAuthedUser authedUser)
		{
			_authenticationService = authenticationService;
			_authedUser = authedUser;
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

		public Account AuthedAccount
		{
			get => _authedUser.CurrentAccount;
			private set => _authedUser.CurrentAccount = value;
		}

	}
}
