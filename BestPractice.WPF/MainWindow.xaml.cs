using System.Windows;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow(MainViewModel mainViewModel)
		{
			InitializeComponent();
			DataContext = mainViewModel;
		}
	}
}
