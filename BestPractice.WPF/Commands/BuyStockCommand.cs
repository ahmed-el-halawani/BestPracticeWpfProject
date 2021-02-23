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
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands
{
	class BuyStockCommand : CustomCommand
	{
		private readonly BuyStockViewModel _buyStockViewModel;
		private readonly IDataService<Account> _accDataService;
		private readonly IBuyStockService _buyStockService;

		public BuyStockCommand(IDataService<Account> accDataService, IBuyStockService buyStockService,BuyStockViewModel buyStockViewModel)
		{
			_buyStockViewModel = buyStockViewModel;
			_accDataService = accDataService;
			_buyStockService = buyStockService;
		}

		public override async void Execute(object parameter)
		{
			string symbol = _buyStockViewModel.SearchedSymbol;
			int amountOfShares = _buyStockViewModel.AmountOfSharesInt;
			Account account = await _accDataService.Get(3);
			try
			{
				await _buyStockService.BuyStock(account,symbol,amountOfShares);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}
	}
}
