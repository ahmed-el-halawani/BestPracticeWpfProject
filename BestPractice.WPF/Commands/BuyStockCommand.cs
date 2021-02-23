using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.WPF.Commands.Customs;
using SimpleTrader.WPF.State.AuthedState;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands
{
	class BuyStockCommand : BaseCommand
	{
		private readonly BuyStockViewModel _buyStockViewModel;
		private readonly IDataService<Account> _accDataService;
		private readonly IAuthedUser _authedUser;
		private readonly IBuyStockService _buyStockService;

		public BuyStockCommand(IDataService<Account> accDataService,IAuthedUser authedUser, IBuyStockService buyStockService,BuyStockViewModel buyStockViewModel)
		{
			_buyStockViewModel = buyStockViewModel;
			_accDataService = accDataService;
			_authedUser = authedUser;
			_buyStockService = buyStockService;
		}

		public override async void Execute(object parameter)
		{
			string symbol = _buyStockViewModel.SearchedSymbol;
			int amountOfShares = _buyStockViewModel.AmountOfSharesInt;
			Account account = _authedUser.CurrentAccount;
			try
			{
				_authedUser.CurrentAccount = await _buyStockService.BuyStock(account,symbol,amountOfShares);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}
	}
}
