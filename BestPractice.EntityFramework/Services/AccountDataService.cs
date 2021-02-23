using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.EntityFramework.Services.Common;

namespace SimpleTrader.EntityFramework.Services
{
	public class AccountDataService : IAccountDataService
	{
		private readonly BestPracticeDbContextFactory _dbContext;
		private readonly NonQueryIDataService<Account> _nonQueryIDataService;

		public AccountDataService(BestPracticeDbContextFactory dbContext)
		{
			_dbContext = dbContext;
			_nonQueryIDataService = new NonQueryIDataService<Account>(dbContext);
		}

		public async Task<IEnumerable<Account>> GetAll()
		{
			await using var db = _dbContext.CreateDbContext();
			return await db.Accounts
				.Include(i=>i.AccountHolder)
				.Include(i=>i.AssetTransactions).ToListAsync();
		}

		public async Task<Account> Get(int id)
		{
			await using var db = _dbContext.CreateDbContext();
			return await db.Accounts
				.Include(i=>i.AccountHolder)
				.Include(i=>i.AssetTransactions).FirstOrDefaultAsync(i => i.Id == id);
		}

		public async Task<Account> Create(Account entity)
		{
			return await _nonQueryIDataService.Create(entity);
		}

		public async Task<bool> Delete(int id)
		{
			return await  _nonQueryIDataService.Delete(id);
		}

		public async Task<bool> Update(int id, Account entity)
		{
			return await  _nonQueryIDataService.Update(id,entity);
		}

		public async Task<Account> GetByEmail(string email)
		{
			await using var db = _dbContext.CreateDbContext();
			return await db.Accounts
				.Include(i=>i.AssetTransactions)
				.Include(i=>i.AccountHolder)
				.FirstOrDefaultAsync(i => i.AccountHolder.Email == email);
		}

		public async Task<Account> GetByUserName(string userName)
		{
			await using var db = _dbContext.CreateDbContext();
			return await db.Accounts
				.Include(i=>i.AccountHolder)
				.Include(i=>i.AssetTransactions)
				.FirstOrDefaultAsync(i => i.AccountHolder.Username == userName);
		}
	}
}
