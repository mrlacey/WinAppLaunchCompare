namespace MauiEmptyApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private void OnTextLoaded(object? sender, EventArgs e)
		{
			MessageLib.WindowsMessageSender.BroadcastLoadedMessage();
		}
	}
}
