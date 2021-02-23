using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Services
{
	public interface IAccountDataService : IDataService<Account>
	{
		Task<Account> GetByEmail(string email);
		Task<Account> GetByUserName(string userName);
	}
}
