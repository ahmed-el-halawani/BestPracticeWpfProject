using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services.authentication;

namespace SimpleTrader.WPF.State.Authenticator
{
	public interface IAuthenticator
	{
		Task<bool> Login(string userName, string password);
		Task<RegisterResult> Register(string userName,string password,string confirmPassword,string email);
		void LogOut();

		Account AuthedAccount { get; }

		bool IsLoggedIn { get; }
	}
}
