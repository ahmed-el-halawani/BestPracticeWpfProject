﻿using System.Threading.Tasks;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Services.TransactionServices
{
	public interface IBuyStockService
	{
		public Task<Account> BuyStock(Account buyer,string symbol, int shares);
	}
}
