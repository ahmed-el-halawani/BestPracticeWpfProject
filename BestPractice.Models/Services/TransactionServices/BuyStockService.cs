using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Services.TransactionServices
{
	public class BuyStockService : IBuyStockService
	{
		private IStockPriceService _stockPriceService;
		private IDataService<Account> _dataService;

		public BuyStockService(IStockPriceService stockPriceService, IDataService<Account> dataService)
		{
			_stockPriceService = stockPriceService;
			_dataService = dataService;
		}

		public async Task<Account> BuyStock(Account buyer, string symbol, int shares)
		{

			decimal stockPrice =await _stockPriceService.GetPrice(symbol);

			decimal transactionPrice = stockPrice * shares;

			if (transactionPrice > buyer.Balance) throw new Exception("no enough money");

			AssetTransaction transaction = new AssetTransaction()
				{
					Account = buyer,
					Asset = new Asset
					{
						PricePerShare = stockPrice,
						Symbol = symbol
					},
					IsPurchase = true,
					Shares = shares,
					DateProcessed = DateTime.Now,
				};

			buyer.AssetTransactions.Add(transaction);

			buyer.Balance -= transactionPrice;

			await _dataService.Update(buyer.Id,buyer);

			return buyer;
		}
	}
}
