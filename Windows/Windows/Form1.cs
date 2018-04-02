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
		const int PlayPauseTopOffset = 10;              // How far should the Play/Pause button be from the top
		const int PlayPauseResize = 5;                  // How far the button will stretch on hover
		const int SkipBackButtonSize = 40;              // How big should the skip/back button be
		const int SkipBackOffset = 10;                  // How far should the skip and back button be from the play/pause button
		const int SkipBackResize = 5;					// How far the button will stretch on hover
		#endregion

		#region Control Rectangles
		// Rectangles that will resize or move the window (these are all invisible except for the top bar)
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
			PlayButton.Size = new Size(PlayPauseSize + PlayPauseResize, PlayPauseSize + PlayPauseResize);
			PlayButton.Location = new Point(this.ClientSize.Width / 2 - PlayButton.Width / 2, this.ClientSize.Height - MusicControlSize + PlayPauseTopOffset - (PlayPauseResize / 2));
			PlayButtonUnhovered.Size = new Size(PlayPauseSize, PlayPauseSize);
			PlayButtonUnhovered.Location = new Point(this.ClientSize.Width / 2 - PlayButtonUnhovered.Width / 2, this.ClientSize.Height - MusicControlSize + PlayPauseTopOffset);

			// Resize the pause button
			PauseButton.Size = new Size(PlayPauseSize + PlayPauseResize, PlayPauseSize + PlayPauseResize);
			PauseButton.Location = new Point(this.ClientSize.Width / 2 - PauseButton.Width / 2, this.ClientSize.Height - MusicControlSize + PlayPauseTopOffset - (PlayPauseResize / 2));
			PauseButtonUnhovered.Size = new Size(PlayPauseSize, PlayPauseSize);
			PauseButtonUnhovered.Location = new Point(this.ClientSize.Width / 2 - PauseButtonUnhovered.Width / 2, this.ClientSize.Height - MusicControlSize + PlayPauseTopOffset);

			// Resize the skip button
			SkipButton.Size = new Size(SkipBackButtonSize + SkipBackResize, SkipBackButtonSize + SkipBackResize);
			SkipButton.Location = new Point(PlayButton.Location.X + PlayButton.Width + SkipBackOffset - (SkipBackResize / 2), PlayButton.Location.Y + ((PlayButton.Height - SkipButton.Height) / 2));
			SkipButtonUnhovered.Size = new Size(SkipBackButtonSize, SkipBackButtonSize);
			SkipButtonUnhovered.Location = new Point(PlayButton.Location.X +PlayButton.Width + SkipBackOffset, PlayButton.Location.Y + ((PlayButton.Height - SkipButtonUnhovered.Height) / 2));

			// Resize the back button
			BackButton.Size = new Size(SkipBackButtonSize + SkipBackResize, SkipBackButtonSize + SkipBackResize);
			BackButton.Location = new Point(PlayButton.Location.X - BackButton.Width - SkipBackOffset + (SkipBackResize / 2), PlayButton.Location.Y + ((PlayButton.Height - BackButton.Height) / 2));
			BackButtonUnhovered.Size = new Size(SkipBackButtonSize, SkipBackButtonSize);
			BackButtonUnhovered.Location = new Point(PlayButton.Location.X - BackButtonUnhovered.Width - SkipBackOffset, PlayButton.Location.Y + ((PlayButton.Height - BackButtonUnhovered.Height) / 2));

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

		#region Hover events
		// Mouse enters the play button
		private void PlayMouseEnter(object sender, EventArgs e)
		{
			PlayButtonUnhovered.Visible = false;
			PlayButton.Visible = true;
		}

		// Mouse leaves the play button
		private void PlayMouseLeave(object sender, EventArgs e)
		{
			PlayButton.Visible = false;
			PlayButtonUnhovered.Visible = true;
		}
		
		// Mouse enters the play button
		private void PauseMouseEnter(object sender, EventArgs e)
		{
			PauseButtonUnhovered.Visible = false;
			PauseButton.Visible = true;
		}

		// Mouse leaves the play button
		private void PauseMouseLeave(object sender, EventArgs e)
		{
			PauseButton.Visible = false;
			PauseButtonUnhovered.Visible = true;
		}

		// Mouse enters skip button
		private void SkipMouseEnter(object sender, EventArgs e)
		{
			SkipButtonUnhovered.Visible = false;
			SkipButton.Visible = true;
		}

		// Mouse leaves skip button
		private void SkipMouseLeave(object sender, EventArgs e)
		{
			SkipButton.Visible = false;
			SkipButtonUnhovered.Visible = true;
		}

		// Mouse enters back button
		private void BackMouseEnter(object sender, EventArgs e)
		{
			BackButtonUnhovered.Visible = false;
			BackButton.Visible = true;
		}

		// Mouse leaves back button
		private void BackMouseLeave(object sender, EventArgs e)
		{
			BackButton.Visible = false;
			BackButtonUnhovered.Visible = true;
		}
		#endregion

		#region Buttons
		#region ControlButtons
		// Button to quit the application
		private void QuitButton_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		// Button to maximize the application
		private void MaximizeButton_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Maximized;
			MaximizeButton.Visible = false;
			NormalWindowButton.Visible = true;
		}

		// Button to return from maximized view of application
		private void NormalWindowButton_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Normal;
			NormalWindowButton.Visible = false;
			MaximizeButton.Visible = true;
		}

		// Button to minimize the application
		private void MinimizeButton_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}
		#endregion

		// Press on the skip button
		private void SkipButton_Click(object sender, EventArgs e)
		{
			Console.WriteLine("Skip");
		}

		// Press on the back button
		private void BackButton_Click(object sender, EventArgs e)
		{
			Console.WriteLine("Back");
		}

		// Press on the play button
		private void PlayButton_Click(object sender, EventArgs e)
		{
			PauseButtonUnhovered.BringToFront();
			PlayButton.BringToFront();
			PlayButton.Visible = false;
			PauseButton.Visible = true;
		}

		// Press on the pause button
		private void PauseButton_Click(object sender, EventArgs e)
		{
			PlayButtonUnhovered.BringToFront();
			PauseButton.BringToFront();
			PauseButton.Visible = false;
			PlayButton.Visible = true;
		}

		// Upload button
		private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }
		#endregion
	}
}
