using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.FinancialModelingPrepApi.Customs
{
	public class StockPriceHttpClientFactory
	{
		private readonly string _apiKey;

		public StockPriceHttpClientFactory(string apiKey)
		{
			_apiKey = apiKey;
		}

		public  StockPriceHttpClient createStockPriceHttpClient()
		{
			return new StockPriceHttpClient(_apiKey);
		}
	}
}
