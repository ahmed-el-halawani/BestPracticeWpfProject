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

		public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType)
		{

			string uri = $"majors-indexes/{GetUriSuffix(indexType)}";

			using StockPriceHttpClient client = new StockPriceHttpClient();

			MajorIndex response =
				await client.GetAsync<MajorIndex>(uri);

			response.Type = indexType;

			return response;
		}


		public string GetUriSuffix(MajorIndexType indexType)
		{
			switch (indexType)
			{
				case MajorIndexType.DowJones:
					return ".DJI";
				case MajorIndexType.Nasdaq:
					return ".IXIC";
				case MajorIndexType.sp500:
					return ".INX";
				default:
					return ".DJI";
			}
		}


	}
}
