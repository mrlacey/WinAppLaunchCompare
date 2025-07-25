using Uno.UI.Hosting;

namespace UnoApp;
internal class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        MessageLib.WindowsMessageSender.BroadcastLaunchedMessage();

        App.InitializeLogging();

        var host = UnoPlatformHostBuilder.Create()
            .App(() => new App())
            //.UseX11()
            //.UseLinuxFrameBuffer()
            //.UseMacOS()
            .UseWin32()
            .Build();

        host.Run();
    }
}
