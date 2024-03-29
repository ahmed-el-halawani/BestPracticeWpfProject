﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.Domain.Models
{
	public class Account : DomainObject
	{
		public User AccountHolder { get; set; }
		public decimal Balance { get; set; }
		public ICollection<AssetTransaction> AssetTransactions { get; set; }
	}
}
