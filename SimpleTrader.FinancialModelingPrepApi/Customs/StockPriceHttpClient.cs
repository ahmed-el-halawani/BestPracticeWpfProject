using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SimpleTrader.FinancialModelingPrepApi.Models;

namespace SimpleTrader.FinancialModelingPrepApi.Customs
{
	public class StockPriceHttpClient : HttpClient
	{
		private string apiKey = "?apikey=fbf300a1773a0a6688f5e2e1d3a75774";

		public StockPriceHttpClient()
		{
			base.BaseAddress = new Uri("https://financialmodelingprep.com/api/v3/");
		}

		public async  Task<T> GetAsync<T>(string uri)
		{
			try
			{
				HttpResponseMessage response = await GetAsync(uri+apiKey);
				string responseValue = await response.Content.ReadAsStringAsync();

				T deserializeObject = JsonConvert.DeserializeObject<T>(responseValue);

				return deserializeObject;
			}
			catch (Exception e)
			{
				throw new Exception("no internet connection");
			}
			
		}
	}
}
