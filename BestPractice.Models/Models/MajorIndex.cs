using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.Domain.Models
{
	public enum MajorIndexType
	{
		DowJones,
		Nasdaq,
		sp500
	}
	public class MajorIndex
	{
		public MajorIndexType  Type { get; set; }
		public decimal Price { get;set; }
		public decimal Changes { get;set; }
		public string indexName { get;set; }
	}
}
