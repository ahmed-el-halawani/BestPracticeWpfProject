using System;
using System.Collections.Generic;
using System.Windows;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.Commands.Customs;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands
{
	class GetSymbolPriceCommand : BaseCommand
	{
		private readonly IStockPriceService _stuckPriceService;
		private readonly BuyStockViewModel _buyStockViewModel;

		public GetSymbolPriceCommand(IStockPriceService stuckPriceService, BuyStockViewModel buyStockViewModel)
		{
			_stuckPriceService = stuckPriceService;
			_buyStockViewModel = buyStockViewModel;
		}

		public override async void Execute(object parameter)
		{
			string symbol = _buyStockViewModel.Symbol;

			if (symbol == string.Empty)
			{
				_buyStockViewModel.SearchedSymbol = string.Empty;
				return;
			}

			try
			{
				_buyStockViewModel.StockPrice = await _stuckPriceService.GetPrice(symbol);
				_buyStockViewModel.SearchedSymbol = symbol;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}
	}
}
