using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModelingPrepApi.Customs;
using SimpleTrader.FinancialModelingPrepApi.Models;

namespace SimpleTrader.FinancialModelingPrepApi.Services
{
	public class StockPriceService :IStockPriceService
	{
		public async Task<decimal> GetPrice(string symbol)
		{
			string uri = $"stock/real-time-price/{symbol}";

			using StockPriceHttpClient client = new StockPriceHttpClient();
			StockPrice response = await client.GetAsync<StockPrice>(uri);

			if(response.Price == default)
			{
				throw new Exception($"symbol {symbol} are not correct");
			}

			return response.Price;
		}
	}
}
