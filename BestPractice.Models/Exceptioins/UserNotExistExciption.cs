using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SimpleTrader.Domain.Exceptioins
{
	public class UserNotExistExciption : Exception
	{
		private string userName;

		public UserNotExistExciption(string userName)
		{
			this.userName = userName;
		}

		public UserNotExistExciption(string? message, string userName) : base(message)
		{
			this.userName = userName;
		}

		public UserNotExistExciption(string? message, Exception? innerException, string userName) : base(message, innerException)
		{
			this.userName = userName;
		}
	}
}
