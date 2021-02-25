using System;
using System.Windows;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.authentication;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.EntityFramework;
using SimpleTrader.EntityFramework.Services;
using SimpleTrader.FinancialModelingPrepApi.Customs;
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
	public partial class App
	{
		public App()
		{
			_host = HostBuilder().Build();
		}

		public static IHostBuilder HostBuilder(string[] args = null)
		{
			return Host.CreateDefaultBuilder(args)
				.ConfigureAppConfiguration(c =>
				{
					c.AddJsonFile("appsettings.json");
				})
				.ConfigureServices(ServiceCollection);
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			_host.Start();
			_host.Services.GetRequiredService<MainWindow>().Show();
			base.OnStartup(e);
		}

		protected override async void OnExit(ExitEventArgs e)
		{
			await _host.StopAsync();
			_host.Dispose();
		
			base.OnExit(e);
		}

		private readonly IHost _host;

		public static void ServiceCollection(HostBuilderContext context,IServiceCollection services)
		{
			services.AddSingleton<IStockPriceService, StockPriceService>();
			services.AddSingleton<IDataService<Account>,AccountDataService>();
			services.AddSingleton<IDataService<User>,GenericDataService<User>>();
			services.AddSingleton<IBuyStockService,BuyStockService>();

			string apiKey = context.Configuration.GetValue<string>("Financial_Api_Key");
			services.AddSingleton(s=>new StockPriceHttpClientFactory(apiKey));

			string connectionString = context.Configuration.GetConnectionString("default");
			services.AddSingleton(new BestPracticeDbContextFactory(connectionString));


			services.AddDbContext<BestPracticeDbContext>(s => s.UseSqlServer(connectionString));

			services.AddSingleton<IMajorIndexService,MajorIndexService>();
			services.AddSingleton<IAccountDataService, AccountDataService>();
			services.AddSingleton<IAuthenticationService, AuthenticationService>();
			services.AddSingleton<IPasswordHasher,PasswordHasher>();
			services.AddSingleton<IAuthenticator,Authenticator>();
			services.AddSingleton<INavigator,Navigator>();
			services.AddSingleton<IAuthedUser,AuthedUser>();
			services.AddSingleton<AssetState>();

			services.AddSingleton<BuyStockViewModel>();
			services.AddSingleton<HomeViewModel>();
			services.AddTransient<AboutViewModel>();
			services.AddTransient<LogInViewModel>();
			services.AddTransient<AssetSummaryViewModel>();
			services.AddTransient<AllAssetViewModel>();
			services.AddTransient<RegisterViewModel>();
			services.AddSingleton<ProtofilioViewModel>();

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
			services.AddSingleton<ViewModelDelegate<RegisterViewModel>>(s=> s.GetRequiredService<RegisterViewModel>);
			services.AddSingleton<ViewModelDelegate<ProtofilioViewModel>>(s=> s.GetRequiredService<ProtofilioViewModel>);

			services.AddSingleton<INavigatorState,NavigatorState>();
			services.AddSingleton<MainViewModel>();
			services.AddScoped<MainWindow>();
		}
	}
}
