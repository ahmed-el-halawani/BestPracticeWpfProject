using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.EntityFramework.Services.Common
{
	class NonQueryIDataService<T> where T : DomainObject
	{
		private readonly BestPracticeDbContextFactory _dbContextFactory;

		public NonQueryIDataService(BestPracticeDbContextFactory dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}

		public async Task<T> Create(T entity)
		{
			await using var db = _dbContextFactory.CreateDbContext();
			var newEntity = await db.Set<T>().AddAsync(entity);
			await db.SaveChangesAsync();
			return newEntity.Entity;
		}

		public async Task<bool> Delete(int id)
		{
			await using var db = _dbContextFactory.CreateDbContext();
			T targetEntity = await db.Set<T>().FirstOrDefaultAsync(i => i.Id == id);
			db.Remove(targetEntity);
			await db.SaveChangesAsync();
			return await db.Set<T>().AnyAsync(i => i.Id == id);
		}

		public async Task<bool> Update(int id, T entity)
		{
			await using var db = _dbContextFactory.CreateDbContext();
			if (!await db.Set<T>().AnyAsync(i => i.Id == id)) return false;
			entity.Id = id;
			db.Set<T>().Update(entity);
			await db.SaveChangesAsync();
			return true;
		}

	}
}
