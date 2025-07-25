using System.Runtime.InteropServices;

namespace MessageLib
{
	public static class WindowsMessageSender
	{
		// Send as soon as the process has launched and is able to execute custom code
		public static readonly uint LaunchedMessageId = RegisterWindowMessage("WinAppLaunchCompare_WindowsMessageSender_LaunchedMessage");

		// Send when the app has loaded the window with text
		public static readonly uint LoadedMessageId = RegisterWindowMessage("WinAppLaunchCompare_WindowsMessageSender_LoadedMessage");

		// Broadcast the custom message to all top-level windows
		public static readonly IntPtr HWND_BROADCAST = new IntPtr(0xFFFF);

		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern uint RegisterWindowMessage(string lpString);

		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		// Send a custom message to a window handle
		public static bool SendMessage(IntPtr hWnd, uint messageId)
		{
			return PostMessage(hWnd, messageId, IntPtr.Zero, IntPtr.Zero);
		}

		public static bool BroadcastLoadedMessage()
		{
			return SendMessage(HWND_BROADCAST, LoadedMessageId);
		}

		public static bool BroadcastLaunchedMessage()
		{
			return SendMessage(HWND_BROADCAST, LaunchedMessageId);
		}
	}
}
