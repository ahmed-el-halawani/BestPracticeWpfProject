using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SimpleTrader.Domain.Exceptioins
{
	public class PasswordNotCorrectException :Exception
	{
		private string _password;

		public PasswordNotCorrectException(string password)
		{
			_password = password;
		}

		public PasswordNotCorrectException(string? message, string password) : base(message)
		{
			_password = password;
		}

		public PasswordNotCorrectException(string? message, Exception? innerException, string password) : base(message, innerException)
		{
			_password = password;
		}
	}
}
