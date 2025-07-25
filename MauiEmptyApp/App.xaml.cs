namespace MauiEmptyApp
{
	public partial class App : Application
	{
		public App()
		{
				MessageLib.WindowsMessageSender.BroadcastLaunchedMessage();
				InitializeComponent();
		}

		protected override Window CreateWindow(IActivationState? activationState)
		{
			return new Window(new MainPage());
		}
	}
}