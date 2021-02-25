using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SimpleTrader.WPF.CustomComponent
{
	/// <summary>
	/// Interaction logic for BindablePasswordBox.xaml
	/// </summary>
	public partial class BindablePasswordBox : UserControl
	{
		public static readonly DependencyProperty PasswordProperty =
			DependencyProperty.Register("Password",
				typeof(string),
				typeof(BindablePasswordBox),
				new FrameworkPropertyMetadata(string.Empty,
					FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
					(d,e)=>{},
					null,
					false,
					UpdateSourceTrigger.PropertyChanged
					)
				);

		public string Password
		{
			get => (string)GetValue(PasswordProperty);
			set => SetValue(PasswordProperty, value);
		}

		public BindablePasswordBox()
		{
			InitializeComponent();
		}

		private void Pb_PasswordChanged(object sender, RoutedEventArgs e)
		{
			Password = Pb.Password;
		}
	}
}
