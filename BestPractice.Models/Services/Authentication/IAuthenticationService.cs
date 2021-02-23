using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Services.authentication
{

	public enum RegisterResult
	{
		Success,
		PasswordMismatch,
		UserIsExist,
		EmailIsExist
	}


	public interface IAuthenticationService
	{
		Task<Account> LogIn(string userName,string password);
		Task<RegisterResult> Register(string userName,string password,string confirmPassword,string email);
	}
}
