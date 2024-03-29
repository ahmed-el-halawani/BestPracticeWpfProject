﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModelingPrepApi.Customs;

namespace SimpleTrader.FinancialModelingPrepApi.Services
{
	public class MajorIndexService : IMajorIndexService
	{
		private readonly StockPriceHttpClientFactory _stockPriceHttpClientFactory;

		public MajorIndexService(StockPriceHttpClientFactory stockPriceHttpClientFactory)
		{
			_stockPriceHttpClientFactory = stockPriceHttpClientFactory;
		}


		public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType)
		{


			string uri = $"majors-indexes/{GetUriSuffix(indexType)}";

			using StockPriceHttpClient client = _stockPriceHttpClientFactory.createStockPriceHttpClient();

			MajorIndex response =
				await client.GetAsync<MajorIndex>(uri);

			response.Type = indexType;

			return response;
		}


		public string GetUriSuffix(MajorIndexType indexType)
		{
			return indexType switch
			{
				MajorIndexType.DowJones => ".DJI",
				MajorIndexType.Nasdaq => ".IXIC",
				MajorIndexType.sp500 => ".INX",
				_ => ".DJI"
			};
		}
	}
}
