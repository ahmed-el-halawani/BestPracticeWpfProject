using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.WPF.Commands;

namespace SimpleTrader.WPF.ViewModels
{
	public class BuyStockViewModel : ViewModelsBase
	{
		private IStockPriceService _stuckPriceService;
		IBuyStockService _buyStockService;
		private IDataService<Account> _accountDataService;

		public BuyStockViewModel(IStockPriceService stuckPriceService, IBuyStockService buyStockService, IDataService<Account> accountDataService)
		{
			_stuckPriceService = stuckPriceService;
			_buyStockService = buyStockService;
			_accountDataService = accountDataService;

			GetSymbolPriceCommand = new GetSymbolPriceCommand(stuckPriceService, this);
			BuyStockCommand = new BuyStockCommand(_accountDataService,_buyStockService,this);
		}

		public ICommand GetSymbolPriceCommand { get; set; }

		public ICommand BuyStockCommand { get; set; }

		private string _symbol;

		public string Symbol
		{
			get => _symbol;
			set
			{
				_symbol = value;
				OnPropertyChanged(nameof(Symbol));
			}
		}

		private string _searchedSymbol = String.Empty;

		public string SearchedSymbol
		{
			get => _searchedSymbol;
			set
			{
				_searchedSymbol = value.ToUpper();
				OnPropertyChanged(nameof(SearchedSymbol));
			}
		}


		private decimal _stockPrice;

		public decimal StockPrice
		{
			get => _stockPrice;
			set
			{
				_stockPrice = value;
				OnPropertyChanged(nameof(StockPrice));
				OnPropertyChanged(nameof(TotalStockPrice));
			}
		}

		private string _amountOfShares;

		public string AmountOfShares
		{
			get => _amountOfShares;
			set
			{
				try
				{
					_amountOfShares = value;
					AmountOfSharesInt = Convert.ToInt32(value);
				}
				catch (Exception)
				{
					AmountOfSharesInt = 0;
				}

				OnPropertyChanged(nameof(AmountOfShares));
				OnPropertyChanged(nameof(TotalStockPrice));
			}
		}

		public int AmountOfSharesInt { get; set; }

		

		public decimal TotalStockPrice => StockPrice * AmountOfSharesInt;



	}
}
