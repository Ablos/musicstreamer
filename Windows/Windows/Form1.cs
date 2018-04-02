using System;
using System.Drawing;
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
			this.FormBorderStyle = FormBorderStyle.None;
			this.DoubleBuffered = true;
			this.SetStyle(ControlStyles.ResizeRedraw, true);
		}

		#region Controls
		private const int
			HTLEFT = 10,
			HTRIGHT = 11,
			HTTOP = 12,
			HTTOPLEFT = 13,
			HTTOPRIGHT = 14,
			HTBOTTOM = 15,
			HTBOTTOMLEFT = 16,
			HTBOTTOMRIGHT = 17,
			HTTOPBARMOVE = 2;
		#endregion

		#region Sizes and offsets
		const int TopSize = 20;                         // Size of the top bar
		const int ControlButtonsOffset = 2;             // Offset of controlbuttons
		const int ControlButtonsResize = 4;				// How much pixels the control buttons should be smaller
		const int BorderSize = 5;						// Size of the border, witch is used to resize
		const int TitleOffset = 3;                      // How far the title should be off the top of the window
		const int MusicControlSize = 100;               // How big the MusicControl background should be
		const int PlayPauseSize = 50;                   // How big should the Play/Pause button be
		const int PlayPauseTopOffset = 5;				// How far should the Play/Pause button be from the top
		#endregion

		#region Control Rectangles
		Rectangle _Top { get { return new Rectangle(0, 0, this.ClientSize.Width, BorderSize); } }
		Rectangle _Left { get { return new Rectangle(0, 0, BorderSize, this.ClientSize.Height); } }
		Rectangle _Bottom { get { return new Rectangle(0, this.ClientSize.Height - BorderSize, this.ClientSize.Width, BorderSize); } }
		Rectangle _Right { get { return new Rectangle(this.ClientSize.Width - BorderSize, 0, BorderSize, this.ClientSize.Height); } }

		Rectangle TopLeft { get { return new Rectangle(0, 0, BorderSize, BorderSize); } }
		Rectangle TopRight { get { return new Rectangle(this.ClientSize.Width - BorderSize, 0, BorderSize, BorderSize); } }
		Rectangle BottomLeft { get { return new Rectangle(0, this.ClientSize.Height - BorderSize, BorderSize, BorderSize); } }
		Rectangle BottomRight { get { return new Rectangle(this.ClientSize.Width - BorderSize, this.ClientSize.Height - BorderSize, BorderSize, BorderSize); } }

		Rectangle TopBar { get { return new Rectangle(0, 0, this.ClientSize.Width, TopSize); } }
		#endregion

		#region Rectangles
		Rectangle MusicControl { get { return new Rectangle(0, this.ClientSize.Height - MusicControlSize, this.ClientSize.Width, MusicControlSize); } }
		#endregion

		#region Colors
		Color cTopBar = Color.FromArgb(22, 22, 22);
		Color cMusicControl = Color.FromArgb(53, 53, 53);
		#endregion

		// Draw graphics
		protected override void OnPaint(PaintEventArgs e)
		{
			// Draw the top bar
			e.Graphics.FillRectangle(new SolidBrush(cTopBar), TopBar);

			// Draw the music control background
			e.Graphics.FillRectangle(new SolidBrush(cMusicControl), MusicControl);

			// Resize the quit button to fit the top bar
			QuitButton.Size = new Size(TopSize - ControlButtonsResize, TopSize - ControlButtonsResize);
			QuitButton.Location = new Point(this.ClientSize.Width - QuitButton.Width - ControlButtonsOffset, ControlButtonsOffset);

			// Update title location, to keep it in the center
			Title.Location = new Point(this.ClientSize.Width / 2 - Title.Width / 2, TitleOffset);

			// Resize the maximize button to fit the top bar
			MaximizeButton.Size = new Size(TopSize - ControlButtonsResize, TopSize - ControlButtonsResize);
			MaximizeButton.Location = new Point(this.ClientSize.Width - QuitButton.Width - ControlButtonsOffset - QuitButton.Width, ControlButtonsOffset);

			// Resize the normal window button to fit the top bar
			NormalWindowButton.Size = new Size(TopSize - ControlButtonsResize, TopSize - ControlButtonsResize);
			NormalWindowButton.Location = new Point(this.ClientSize.Width - QuitButton.Width - ControlButtonsOffset - QuitButton.Width, ControlButtonsOffset);

			// Resize the minimize button to fit the top bar
			MinimizeButton.Size = new Size(TopSize - ControlButtonsResize, TopSize - ControlButtonsResize);
			MinimizeButton.Location = new Point(this.ClientSize.Width - QuitButton.Width - MaximizeButton.Width - ControlButtonsOffset - MinimizeButton.Width, ControlButtonsOffset);

			// Resize the play button
			PlayButton.Size = new Size(50, 50);
			PlayButton.Location = new Point(this.ClientSize.Width / 2 - PlayButton.Width / 2, this.ClientSize.Height - MusicControlSize + PlayPauseTopOffset);

			// Fill rectangles for resizing (DEBUG ONLY)
			//e.Graphics.FillRectangle(Brushes.Green, _Top);
			//e.Graphics.FillRectangle(Brushes.Green, _Left);
			//e.Graphics.FillRectangle(Brushes.Green, _Right);
			//e.Graphics.FillRectangle(Brushes.Green, _Bottom);
		}

		// Window control
		protected override void WndProc(ref Message message)
		{
			base.WndProc(ref message);

			// Process controls
			if (message.Msg == 0x84)
			{
				Point cursor = this.PointToClient(Cursor.Position);

				if (TopLeft.Contains(cursor)) message.Result = (IntPtr)HTTOPLEFT;
				else if (TopRight.Contains(cursor)) message.Result = (IntPtr)HTTOPRIGHT;
				else if (BottomLeft.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMLEFT;
				else if (BottomRight.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMRIGHT;

				else if (_Top.Contains(cursor)) message.Result = (IntPtr)HTTOP;
				else if (_Left.Contains(cursor)) message.Result = (IntPtr)HTLEFT;
				else if (_Right.Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
				else if (_Bottom.Contains(cursor)) message.Result = (IntPtr)HTBOTTOM;

				else if (TopBar.Contains(cursor)) message.Result = (IntPtr)HTTOPBARMOVE;

				// Update title location, to keep it in the center
				Title.Location = new Point(this.ClientSize.Width / 2 - Title.Width / 2, TitleOffset);

				// Update control buttons locations
				QuitButton.Location = new Point(this.ClientSize.Width - QuitButton.Width - ControlButtonsOffset, ControlButtonsOffset);
				MaximizeButton.Location = new Point(this.ClientSize.Width - QuitButton.Width - ControlButtonsOffset - QuitButton.Width, ControlButtonsOffset);
				NormalWindowButton.Location = new Point(this.ClientSize.Width - QuitButton.Width - ControlButtonsOffset - QuitButton.Width, ControlButtonsOffset);
				MinimizeButton.Location = new Point(this.ClientSize.Width - QuitButton.Width - MaximizeButton.Width - ControlButtonsOffset - MinimizeButton.Width, ControlButtonsOffset);
			}
		}

		// Event when window gets resized
		protected override void OnResizeBegin(EventArgs e)
		{
			this.WindowState = FormWindowState.Normal;
			NormalWindowButton.Visible = false;
			MaximizeButton.Visible = true;
			base.OnResizeBegin(e);
		}

		// Move the window
		private void Mover(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
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

		#region Hover events
		private void PlayPauseMouseEnter(object sender, EventArgs e)
		{
			
		}
		#endregion

		#region Buttons
		#region ControlButtons
		private void QuitButton_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void MaximizeButton_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Maximized;
			MaximizeButton.Visible = false;
			NormalWindowButton.Visible = true;
		}

		private void NormalWindowButton_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Normal;
			NormalWindowButton.Visible = false;
			MaximizeButton.Visible = true;
		}

		private void MinimizeButton_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}
		#endregion
		private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }
		#endregion
	}
}
