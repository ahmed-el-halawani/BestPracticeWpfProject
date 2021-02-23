using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.EntityFramework.Services.Common;

namespace SimpleTrader.EntityFramework.Services
{
	public class GenericDataService <T> : IDataService<T> where T : DomainObject
	{
		private readonly BestPracticeDbContextFactory dbContext;
		private readonly NonQueryIDataService<T> _nonQueryIDataService;

		public GenericDataService(BestPracticeDbContextFactory dbContext)
		{
			this.dbContext = dbContext;
			_nonQueryIDataService = new NonQueryIDataService<T>(dbContext);
		}

		public async Task<IEnumerable<T>> GetAll()
		{
			await using var db = dbContext.CreateDbContext();
			return await db.Set<T>().ToListAsync();
		}

		public async Task<T> Get(int id)
		{
			await using var db = dbContext.CreateDbContext();
			return await db.Set<T>().FirstOrDefaultAsync(i => i.Id == id);
		}

		public async Task<T> Create(T entity)
		{
			return await _nonQueryIDataService.Create(entity);
		}

		public async Task<bool> Delete(int id)
		{
			return await  _nonQueryIDataService.Delete(id);
		}

		public async Task<bool> Update(int id, T entity)
		{
			return await  _nonQueryIDataService.Update(id,entity);
		}
	}
}
