using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using SimpleTrader.Domain.Exceptioins;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Services.authentication
{
	public class AuthenticationService : IAuthenticationService
	{
		private readonly IAccountDataService _accountDataService;
		private readonly IPasswordHasher _passwordHasher;

		public AuthenticationService(IAccountDataService accountDataService, IPasswordHasher passwordHasher)
		{
			_passwordHasher = passwordHasher;
			_accountDataService = accountDataService;
		}

		public async Task<Account> LogIn(string userName, string password)
		{
			Account account = await _accountDataService.GetByUserName(userName);

			if (account == null)
			{
				throw new UserNotExistExciption(userName);
			}

			PasswordVerificationResult passwordVerification = _passwordHasher.VerifyHashedPassword(account.AccountHolder.PasswordHash, password);

			if (passwordVerification == PasswordVerificationResult.Failed)
			{
				throw new PasswordNotCorrectException(password);
			}

			return account;
		}

		public async Task<RegisterResult> Register(string userName, string password, string confirmPassword, string email)
		{
			Account accountByEmail = await _accountDataService.GetByEmail(email);
			Account accountByUserName = await _accountDataService.GetByUserName(userName);


			if (accountByUserName != null)
			{
				return RegisterResult.UserIsExist;
			}

			if (accountByEmail != null)
			{
				return RegisterResult.EmailIsExist;
			}

			if (password != confirmPassword)
			{
				return RegisterResult.PasswordMismatch;
			}


			var hashPassword = _passwordHasher.HashPassword(password);


			User newUser = new User()
			{
				Email = email,
				PasswordHash = hashPassword,
				DatedJoined = DateTime.Now,
				Username = userName,
			};

			await _accountDataService.Create(new Account()
			{
				AccountHolder = newUser,
			});

			return RegisterResult.Success;
		}
	}
}
