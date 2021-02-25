using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SimpleTrader.EntityFramework
{
	public class BestPracticeDbContextFactory 
	{
		private string _connectionString;

		public BestPracticeDbContextFactory(string connectionString)
		{
			_connectionString = connectionString;
		}

		public BestPracticeDbContext CreateDbContext()
		{
			var optinos = new DbContextOptionsBuilder<BestPracticeDbContext>();
			string connectionString = @"server=desktop-h2le4iq\sql2020;Database=BestPracticeDatabase;integrated security=True";
			optinos.UseSqlServer(_connectionString);
			return new BestPracticeDbContext(optinos.Options);
		}
	}
}


