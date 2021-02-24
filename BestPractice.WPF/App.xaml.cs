using System;
using System.Windows;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.authentication;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.EntityFramework;
using SimpleTrader.EntityFramework.Services;
using SimpleTrader.FinancialModelingPrepApi.Services;
using SimpleTrader.WPF.Models.Authenticator;
using SimpleTrader.WPF.Models.Navigator;
using SimpleTrader.WPF.State.AssetState;
using SimpleTrader.WPF.State.AuthedState;
using SimpleTrader.WPF.State.NavigatorState;
using SimpleTrader.WPF.ViewModels;
using SimpleTrader.WPF.ViewModels.AssetTransactionViewModels;
using SimpleTrader.WPF.ViewModels.MVSwitcher;

namespace SimpleTrader.WPF
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			IServiceProvider services = CreateServiceProvider();
			services.GetRequiredService<MainWindow>().Show();
			base.OnStartup(e);
		}



		private IServiceProvider CreateServiceProvider()
		{
			IServiceCollection services = new ServiceCollection();

			services.AddSingleton<IStockPriceService, StockPriceService>();
			services.AddSingleton<IDataService<Account>,AccountDataService>();
			services.AddSingleton<IDataService<User>,GenericDataService<User>>();
			services.AddSingleton<IBuyStockService,BuyStockService>();
			services.AddSingleton<BestPracticeDbContextFactory>();
			services.AddSingleton<IMajorIndexService,MajorIndexService>();
			services.AddSingleton<IAccountDataService, AccountDataService>();
			services.AddSingleton<IAuthenticationService, AuthenticationService>();
			services.AddSingleton<IPasswordHasher,PasswordHasher>();
			services.AddSingleton<IAuthenticator,Authenticator>();
			services.AddSingleton<INavigator,Navigator>();
			services.AddSingleton<IAuthedUser,AuthedUser>();
			services.AddSingleton<AssetState>();

			services.AddTransient<BuyStockViewModel>();
			services.AddSingleton<HomeViewModel>();
			services.AddTransient<AboutViewModel>();
			services.AddTransient<LogInViewModel>();
			services.AddTransient<AssetSummaryViewModel>();

			services.AddSingleton(s=>MajorIndexViewModel.LoadMajorIndexViewModel
				(
					s.GetRequiredService<IMajorIndexService>()
				)
			);

			services.AddSingleton<IViewModelSwitcher,ViewModelSwitcher>();
			services.AddSingleton<ViewModelDelegate<HomeViewModel>>(s=> s.GetRequiredService<HomeViewModel>);
			services.AddSingleton<ViewModelDelegate<AboutViewModel>>(s=> s.GetRequiredService<AboutViewModel>);
			services.AddSingleton<ViewModelDelegate<LogInViewModel>>(s=> s.GetRequiredService<LogInViewModel>);
			services.AddSingleton<ViewModelDelegate<BuyStockViewModel>>(s=> s.GetRequiredService<BuyStockViewModel>);

			services.AddSingleton<INavigatorState,NavigatorState>();
			services.AddSingleton<MainViewModel>();
			services.AddScoped<MainWindow>();

			return services.BuildServiceProvider();

		}
	}
}
