using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SimpleTrader.WPF.Views
{
	/// <summary>
	/// Interaction logic for LogInView.xaml
	/// </summary>
	public partial class LogInView : UserControl
	{
		public static readonly DependencyProperty LogInCommandProperty =
			DependencyProperty.Register("LogInCommand", typeof(ICommand), typeof(LogInView), new PropertyMetadata(null));

		public ICommand LogInCommand
		{
			get => (ICommand)GetValue(LogInCommandProperty);
			set => SetValue(LogInCommandProperty, value);
		}

		public LogInView()
		{
			InitializeComponent();
		}

		private void LogIn_Click(object sender, RoutedEventArgs e)
		{
			if (LogInCommand != null)
			{
				string password = Password.Password;
				LogInCommand.Execute(password);
			}
		}
	}
}
