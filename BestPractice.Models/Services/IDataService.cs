using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Services
{
	public interface IDataService<T> where T : class
	{
		Task<IEnumerable<T>> GetAll();
		Task<T> Get(int id);
		Task<T> Create(T entity);
		Task<bool> Delete(int id);
		Task<bool> Update(int id,T entity);
	}
}
