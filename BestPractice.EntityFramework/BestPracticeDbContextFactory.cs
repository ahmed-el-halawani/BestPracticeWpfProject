using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SimpleTrader.EntityFramework
{
	public class BestPracticeDbContextFactory : IDesignTimeDbContextFactory<BestPracticeDbContext>
	{

		public BestPracticeDbContext CreateDbContext(string[] args = null)
		{
			var optinos = new DbContextOptionsBuilder<BestPracticeDbContext>();
			string connectionString = @"server=desktop-h2le4iq\sql2020;Database=BestPracticeDatabase;integrated security=True";
			optinos.UseSqlServer(connectionString);
			return new BestPracticeDbContext(optinos.Options);
		}
	}
}


