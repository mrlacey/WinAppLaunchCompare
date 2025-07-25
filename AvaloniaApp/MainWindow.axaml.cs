using Avalonia.Controls;

namespace AvaloniaApp
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void OnTextLoaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
		{
			MessageLib.WindowsMessageSender.BroadcastLoadedMessage();
		}
	}
}
