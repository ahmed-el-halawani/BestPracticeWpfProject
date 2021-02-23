using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.EntityFramework
{
	public class BestPracticeDbContext : DbContext
	{

		public DbSet<User> Users { get; set; }
		public DbSet<Account> Accounts{ get; set; }
		public DbSet<Asset> Assets{ get; set; }
		public DbSet<AssetTransaction> AssetTransactions{ get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AssetTransaction>().OwnsOne(i => i.Asset);

			base.OnModelCreating(modelBuilder);
		}

		public BestPracticeDbContext(DbContextOptions options) : base(options){ }
	}
}
