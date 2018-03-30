using AudioStreamer;
using System;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Windows
{
	public partial class Form1 : Form
	{
		public const int WM_NCLBUTTONDOWN = 0xA1;
		public const int HT_CAPTION = 0x2;

		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		int start_x = 0;
		int start_y = 0;

		public Form1()
		{
			InitializeComponent();
		}

		private void Mover(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
			}
		}

		private void Resizer_Mouse_Down(object sender, MouseEventArgs e)
		{
			start_x = e.X;
			start_y = e.Y;
		}

		private void Resizer_Up(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ActiveForm.Height += start_y - e.Y;
				ActiveForm.Location = new System.Drawing.Point(ActiveForm.Location.X, ActiveForm.Location.Y - (start_y - e.Y));
			}
		}

		private void Resizer_Down(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ActiveForm.Height += e.Y - start_y;
			}
		}

		private void Resizer_Right(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ActiveForm.Width += e.X - start_x;
			}
		}

		private void Resizer_Left(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ActiveForm.Width += start_x - e.X;
				ActiveForm.Location = new System.Drawing.Point(ActiveForm.Location.X - (start_x - e.X), ActiveForm.Location.Y);
			}
		}

		private void UpdateDownloadState(YoutubeAudioDownloader.State state)
		{
			Console.WriteLine("Working");
			switch (state)
			{
				case YoutubeAudioDownloader.State.VALIDATING_URL:
					//label2.Text = "Validating URL...";
					break;
				case YoutubeAudioDownloader.State.VALIDATING_PATH:
					//label2.Text = "Validating path...";
					break;
				case YoutubeAudioDownloader.State.COLLECTING_URL:
					//label2.Text = "Collecting URL...";
					break;
				case YoutubeAudioDownloader.State.CREATING_DIR:
					//label2.Text = "Creating directory...";
					break;
				case YoutubeAudioDownloader.State.DOWNLOADING_VIDEO:
					//label2.Text = "Downloading video...";
					break;
				case YoutubeAudioDownloader.State.CREATING_LOW:
					//label2.Text = "Creating low quality MP3...";
					break;
				case YoutubeAudioDownloader.State.CREATING_HIGH:
					//label2.Text = "Creating high quality MP3...";
					break;
				case YoutubeAudioDownloader.State.CLEANING:
					//label2.Text = "Cleaning up...";
					break;
				case YoutubeAudioDownloader.State.DONE:
					//label2.Text = "DONE!";
					break;
				default:
					//label2.Text = "Invactive";
					break;
			}
		}

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }
	}
}
