using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using MessageLib;

namespace Launcher
{
	public partial class MainWindow : Window
	{
		private HwndSource? hwndSource;
		private Stopwatch? launchStopwatch;
		private Stopwatch? loadedStopwatch;
		//private const string ExePath = @"C:\Users\matt\Documents\GitHub\mrlacey\WinAppLaunchCompare\UnoApp\UnoApp\bin\Release\net9.0-desktop\UnoApp.exe";
		private const string ExePath = @"..\..\..\..\UnoApp\UnoApp\bin\Release\net9.0-desktop\UnoApp.exe";
		
		public MainWindow()
		{
			InitializeComponent();
		}

		private void StartProcessButton_Click(object sender, RoutedEventArgs e)
		{
			string pathOfInterest = ExePath;

			if (SelectedFramework.SelectedItem is ComboBoxItem selectedItem)
			{
				var relPath = selectedItem.Tag.ToString();

				if (!string.IsNullOrWhiteSpace(relPath))
				{
					pathOfInterest = relPath;
				}

				OutputTextBox.Text += $"Selected framework: {selectedItem.Content}{Environment.NewLine}";
			}

			pathOfInterest = pathOfInterest.Replace("{CONFIG}", SelectedConfiguration.Text);
			pathOfInterest = pathOfInterest.Replace("{ARCH}", SelectedArchitecture.Text);

			if (!System.IO.File.Exists(pathOfInterest))
			{
				OutputTextBox.Text += $"The file does not exist: {pathOfInterest}";
				return;
			}

			launchStopwatch = new Stopwatch();
			loadedStopwatch = new Stopwatch();
			launchStopwatch.Start();
			loadedStopwatch.Start();

			try
			{
				Process.Start(pathOfInterest);
			}
			catch (Exception ex)
			{
				launchStopwatch?.Stop();
				loadedStopwatch?.Stop();
				MessageBox.Show($"Failed to start process: {ex.Message}");
			}
		}

		protected override void OnSourceInitialized(EventArgs e)
		{
			base.OnSourceInitialized(e);
			hwndSource = PresentationSource.FromVisual(this) as HwndSource;
			hwndSource?.AddHook(WndProc);
		}

		private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
		{
			if (msg == WindowsMessageSender.LoadedMessageId)
			{
				loadedStopwatch?.Stop();
				var elapsed = loadedStopwatch != null ? loadedStopwatch.Elapsed.TotalMilliseconds : 0;

				OutputTextBox.Text += $"Loaded: {elapsed} ms{Environment.NewLine}";

				//MessageBox.Show($"Message received! Stopwatch stopped. Elapsed: {elapsed} ms");
				handled = true;
			}
			if (msg == WindowsMessageSender.LaunchedMessageId)
			{
				launchStopwatch?.Stop();
				var elapsed = launchStopwatch != null ? launchStopwatch.Elapsed.TotalMilliseconds : 0;

				OutputTextBox.Text += $"Launched: {elapsed} ms{Environment.NewLine}";

				//MessageBox.Show($"Message received! Stopwatch stopped. Elapsed: {elapsed} ms");
				handled = true;
			}
			return IntPtr.Zero;
		}
	}
}