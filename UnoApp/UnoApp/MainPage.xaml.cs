namespace UnoApp;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();
    }

    private void OnTextLoaded(object sender, RoutedEventArgs e)
    {
        MessageLib.WindowsMessageSender.BroadcastLoadedMessage();
    }
}
