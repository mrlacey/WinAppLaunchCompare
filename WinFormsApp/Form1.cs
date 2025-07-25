namespace WinFormsApp
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		// Using this as no equivalent of TextBlock.Loaded in WinForms
		private void Form1_Shown(object sender, EventArgs e)
		{
			MessageLib.WindowsMessageSender.BroadcastLoadedMessage();
		}
	}
}
