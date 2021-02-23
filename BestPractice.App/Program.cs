using System;
using SimpleTrader.Domain.Models;
using SimpleTrader.EntityFramework;
using SimpleTrader.EntityFramework.Services;
using SimpleTrader.FinancialModelingPrepApi.Services;

namespace SimpleTrader.App
{
	class Program
	{
		static void Main(string[] args)
		{
			GenericDataService<User> x = new GenericDataService<User>(new BestPracticeDbContextFactory());
			MajorIndexService major = new MajorIndexService();
			//major.GetMajorIndex().ContinueWith(i =>
			//{
			//	Console.WriteLine(i);
			//});

			Console.ReadLine();




		}
	}
}
