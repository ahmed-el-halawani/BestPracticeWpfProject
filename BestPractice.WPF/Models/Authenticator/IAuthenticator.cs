using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services.authentication;

namespace SimpleTrader.WPF.Models.Authenticator
{
	public interface IAuthenticator
	{
		Task<bool> Login(string userName, string password);
		Task<RegisterResult> Register(string userName,string password,string confirmPassword,string email);
		void LogOut();

		Account AuthedAccount { get; }
	}
}
