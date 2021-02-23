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
using SimpleTrader.WPF.State.Authenticator;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;
using SimpleTrader.WPF.ViewModels.factories;
using SimpleTrader.WPF.Views;

namespace SimpleTrader.WPF
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			IServiceProvider services = createServiceProvider();
			services.GetRequiredService<MainWindow>().Show();
			base.OnStartup(e);
		}


		private IServiceProvider createServiceProvider()
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
			services.AddSingleton<ReNavigator<HomeViewModel>>();

			services.AddSingleton<IBestPracticeViewModelsAbstractFactory,BestPracticeViewModelAbstractFactory>();
			services.AddSingleton<IViewModelFactory<HomeViewModel>,HomeViewModelFactory>();
			services.AddSingleton<IViewModelFactory<AboutViewModel>,AboutViewModelFactory>();
			services.AddSingleton<IViewModelFactory<MajorIndexViewModel>,MajorIndexViewModelFactory>();
			services.AddSingleton<IViewModelFactory<LogInViewModel>,LoginViewModelFactory>(
				e=> new LoginViewModelFactory
				(e.GetRequiredService<IAuthenticator>(),
				e.GetRequiredService<ReNavigator<HomeViewModel>>()
				)
			);

			services.AddScoped<INavigator,Navigator>();
			services.AddScoped<MainViewModel>();
			services.AddScoped<BuyStockViewModel>();
			services.AddScoped<MainWindow>();

			return services.BuildServiceProvider();

		}
	}
}
