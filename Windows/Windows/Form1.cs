using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

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

			// Timebar settings
			timeBarProgress.Size = new Size(0, TimeBar_BG.Height);                      // Set scale for panel
			SliderHandle.Size = new Size(SliderHandleRadius, SliderHandleRadius);       // Resize handle for all sliders
			timeBarProgress.BackColor = cSliderUnselected;                              // Color the timeBarProgress panel
			timeBarProgress.Location = TimeBar_BG.Location;                             // Set location of panel
			Controls.Add(timeBarProgress);                                              // Instantiate the time bar progress
			SliderHandle.BringToFront();                                                // Bring slider handle forward

			// Event for when hovered over the time progress
			timeBarProgress.MouseEnter += new EventHandler(new Action<object, EventArgs>((object sender, EventArgs args) =>
			{
				PlaybackSettings.timeSelected = true;
				timeBarProgress.BackColor = cSliderSelected;
				Update();

				if (!PlaybackSettings.edittingTime)
				{
					SliderHandle.Location = new Point(timeBarProgress.Location.X + timeBarProgress.Width - (SliderHandle.Width / 2), timeBarProgress.Location.Y - (SliderHandle.Height / 2) + (timeBarProgress.Height / 2));
					SliderHandle.Visible = true;
					SliderHandle.BringToFront();
				}
			}));

			// Event for when clicked on time progress
			timeBarProgress.MouseClick += new MouseEventHandler(new Action<object, MouseEventArgs>((object sender, MouseEventArgs args) =>
			{
				timeBarProgress.Size = new Size(args.Location.X, timeBarProgress.Height);
				SliderHandle.Location = new Point(timeBarProgress.Location.X + timeBarProgress.Width - (SliderHandle.Width / 2), timeBarProgress.Location.Y - (SliderHandle.Height / 2) + (timeBarProgress.Height / 2));
				OnTimeBarValueChanged?.Invoke();
			}));
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
		const int PlayPauseResize = 5;                  // How far the Play/Pause button will stretch on hover

		const int SkipBackButtonSize = 40;              // How big should the skip/back button be
		const int SkipBackOffset = 10;                  // How far should the skip and back button be from the play/pause button
		const int SkipBackResize = 5;                   // How far the Skip/Back button will stretch on hover

		const int ShuffleRepeatButtonSize = 35;         // How big the shuffle and repeat button should be
		const int ShuffleRepeatOffset = 10;             // How far should the shuffle and repeat button be from the skip and back button
		const int ShuffleRepeatResize = 5;              // How far should the shuffle and repeat button stretch on hover

		const int TimeBarPercentage = 35;               // How much percentage the time bar should take from the whole width of the window
		const int TimeBarOffset = 27;                   // How far the timebar should be off the bottom

		const int SliderHeight = 5;						// How high a slider should be
		const int SliderHandleRadius = 12;				// Radius of slider handle
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

		#region Shapes
		// Background of the music control
		Rectangle MusicControl { get { return new Rectangle(0, this.ClientSize.Height - MusicControlSize, this.ClientSize.Width, MusicControlSize); } }
		
		// Timebar of where the music is currently
		Rectangle TimeBar_BG { get { return new Rectangle((this.ClientSize.Width / 2) - (int)((this.ClientSize.Width * ((float)TimeBarPercentage / 100)) / 2), this.ClientSize.Height - TimeBarOffset, (int)(this.ClientSize.Width * ((float)TimeBarPercentage / 100)), SliderHeight); } }
		#endregion

		#region Colors
		Color cTopBar = Color.FromArgb(22, 22, 22);
		Color cMusicControl = Color.FromArgb(53, 53, 53);
		Color cSliderBG = Color.FromArgb(90, 90, 90);
		Color cSliderUnselected = Color.FromArgb(153, 0, 0);
		Color cSliderSelected = Color.FromArgb(204, 0, 0);
		#endregion

		#region Panels
		Panel timeBarBounds = new Panel();
		Panel timeBarProgress = new Panel();
		#endregion

		#region Variables
		public delegate void _OnTimeBarValueChanged();
		public _OnTimeBarValueChanged OnTimeBarValueChanged;
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

			// Resize and position the maximize button to fit the top bar
			MaximizeButton.Size = new Size(TopSize - ControlButtonsResize, TopSize - ControlButtonsResize);
			MaximizeButton.Location = new Point(this.ClientSize.Width - QuitButton.Width - ControlButtonsOffset - QuitButton.Width, ControlButtonsOffset);

			// Resize and position the normal window button to fit the top bar
			NormalWindowButton.Size = new Size(TopSize - ControlButtonsResize, TopSize - ControlButtonsResize);
			NormalWindowButton.Location = new Point(this.ClientSize.Width - QuitButton.Width - ControlButtonsOffset - QuitButton.Width, ControlButtonsOffset);

			// Resize and position the minimize button to fit the top bar
			MinimizeButton.Size = new Size(TopSize - ControlButtonsResize, TopSize - ControlButtonsResize);
			MinimizeButton.Location = new Point(this.ClientSize.Width - QuitButton.Width - MaximizeButton.Width - ControlButtonsOffset - MinimizeButton.Width, ControlButtonsOffset);

			// Resize and position the play button
			PlayButton.Size = new Size(PlayPauseSize + PlayPauseResize, PlayPauseSize + PlayPauseResize);
			PlayButton.Location = new Point(this.ClientSize.Width / 2 - PlayButton.Width / 2, this.ClientSize.Height - MusicControlSize + PlayPauseTopOffset - (PlayPauseResize / 2));
			PlayButtonUnhovered.Size = new Size(PlayPauseSize, PlayPauseSize);
			PlayButtonUnhovered.Location = new Point(this.ClientSize.Width / 2 - PlayButtonUnhovered.Width / 2, this.ClientSize.Height - MusicControlSize + PlayPauseTopOffset);

			// Resize and position the pause button
			PauseButton.Size = new Size(PlayPauseSize + PlayPauseResize, PlayPauseSize + PlayPauseResize);
			PauseButton.Location = new Point(this.ClientSize.Width / 2 - PauseButton.Width / 2, this.ClientSize.Height - MusicControlSize + PlayPauseTopOffset - (PlayPauseResize / 2));
			PauseButtonUnhovered.Size = new Size(PlayPauseSize, PlayPauseSize);
			PauseButtonUnhovered.Location = new Point(this.ClientSize.Width / 2 - PauseButtonUnhovered.Width / 2, this.ClientSize.Height - MusicControlSize + PlayPauseTopOffset);

			// Resize and position the skip button
			SkipButton.Size = new Size(SkipBackButtonSize + SkipBackResize, SkipBackButtonSize + SkipBackResize);
			SkipButton.Location = new Point(PlayButton.Location.X + PlayButton.Width + SkipBackOffset - (SkipBackResize / 2), PlayButton.Location.Y + ((PlayButton.Height - SkipButton.Height) / 2));
			SkipButtonUnhovered.Size = new Size(SkipBackButtonSize, SkipBackButtonSize);
			SkipButtonUnhovered.Location = new Point(PlayButton.Location.X +PlayButton.Width + SkipBackOffset, PlayButton.Location.Y + ((PlayButton.Height - SkipButtonUnhovered.Height) / 2));

			// Resize and position the back button
			BackButton.Size = new Size(SkipBackButtonSize + SkipBackResize, SkipBackButtonSize + SkipBackResize);
			BackButton.Location = new Point(PlayButton.Location.X - BackButton.Width - SkipBackOffset + (SkipBackResize / 2), PlayButton.Location.Y + ((PlayButton.Height - BackButton.Height) / 2));
			BackButtonUnhovered.Size = new Size(SkipBackButtonSize, SkipBackButtonSize);
			BackButtonUnhovered.Location = new Point(PlayButton.Location.X - BackButtonUnhovered.Width - SkipBackOffset, PlayButton.Location.Y + ((PlayButton.Height - BackButtonUnhovered.Height) / 2));

			// Resize and position the shuffle button
			ShuffleButton.Size = new Size(ShuffleRepeatButtonSize + ShuffleRepeatResize, ShuffleRepeatButtonSize + ShuffleRepeatResize);
			ShuffleButton.Location = new Point(BackButton.Location.X - ShuffleButton.Width - ShuffleRepeatOffset + (ShuffleRepeatResize / 2), PlayButton.Location.Y + ((PlayButton.Height - ShuffleButton.Height) / 2));
			ShuffleButtonUnhovered.Size = new Size(ShuffleRepeatButtonSize, ShuffleRepeatButtonSize);
			ShuffleButtonUnhovered.Location = new Point(BackButton.Location.X - ShuffleButtonUnhovered.Width - ShuffleRepeatOffset, PlayButton.Location.Y + ((PlayButton.Height - ShuffleButtonUnhovered.Height) / 2));

			// Resize and position the enabled shuffle button
			EnabledShuffleButton.Size = new Size(ShuffleRepeatButtonSize + ShuffleRepeatResize, ShuffleRepeatButtonSize + ShuffleRepeatResize);
			EnabledShuffleButton.Location = new Point(BackButton.Location.X - ShuffleButton.Width - ShuffleRepeatOffset + (ShuffleRepeatResize / 2), PlayButton.Location.Y + ((PlayButton.Height - ShuffleButton.Height) / 2));
			EnabledShuffleButtonUnhovered.Size = new Size(ShuffleRepeatButtonSize, ShuffleRepeatButtonSize);
			EnabledShuffleButtonUnhovered.Location = new Point(BackButton.Location.X - ShuffleButtonUnhovered.Width - ShuffleRepeatOffset, PlayButton.Location.Y + ((PlayButton.Height - ShuffleButtonUnhovered.Height) / 2));

			// Resize and position the unenabled repeat button
			RepeatButton.Size = new Size(ShuffleRepeatButtonSize + ShuffleRepeatResize, ShuffleRepeatButtonSize + ShuffleRepeatResize);
			RepeatButton.Location = new Point(SkipButton.Location.X + SkipButton.Width + ShuffleRepeatOffset - (ShuffleRepeatResize / 2), PlayButton.Location.Y + ((PlayButton.Height - RepeatButton.Height) / 2));
			RepeatButtonUnhovered.Size = new Size(ShuffleRepeatButtonSize, ShuffleRepeatButtonSize);
			RepeatButtonUnhovered.Location = new Point(SkipButton.Location.X + SkipButton.Width + ShuffleRepeatOffset, PlayButton.Location.Y + ((PlayButton.Height - RepeatButtonUnhovered.Height) / 2));

			// Resize and position the enabled repeat button
			EnabledRepeatButton.Size = new Size(ShuffleRepeatButtonSize + ShuffleRepeatResize, ShuffleRepeatButtonSize + ShuffleRepeatResize);
			EnabledRepeatButton.Location = new Point(SkipButton.Location.X + SkipButton.Width + ShuffleRepeatOffset - (ShuffleRepeatResize / 2), PlayButton.Location.Y + ((PlayButton.Height - RepeatButton.Height) / 2));
			EnabledRepeatButtonUnhovered.Size = new Size(ShuffleRepeatButtonSize, ShuffleRepeatButtonSize);
			EnabledRepeatButtonUnhovered.Location = new Point(SkipButton.Location.X + SkipButton.Width + ShuffleRepeatOffset, PlayButton.Location.Y + ((PlayButton.Height - RepeatButtonUnhovered.Height) / 2));

			// Resize and position the enabled repeat one button
			EnabledRepeatOneButton.Size = new Size(ShuffleRepeatButtonSize + ShuffleRepeatResize, ShuffleRepeatButtonSize + ShuffleRepeatResize);
			EnabledRepeatOneButton.Location = new Point(SkipButton.Location.X + SkipButton.Width + ShuffleRepeatOffset - (ShuffleRepeatResize / 2), PlayButton.Location.Y + ((PlayButton.Height - RepeatButton.Height) / 2));
			EnabledRepeatOneButtonUnhovered.Size = new Size(ShuffleRepeatButtonSize, ShuffleRepeatButtonSize);
			EnabledRepeatOneButtonUnhovered.Location = new Point(SkipButton.Location.X + SkipButton.Width + ShuffleRepeatOffset, PlayButton.Location.Y + ((PlayButton.Height - RepeatButtonUnhovered.Height) / 2));

			// Draw the timebar
			e.Graphics.FillRectangle(new SolidBrush(cSliderBG), TimeBar_BG);            // Draw background

			// Middle line through play/pause button (DEBUG ONLY)
			//Rectangle middle = new Rectangle(0, PlayButton.Location.Y + (PlayButton.Height / 2) - 1, this.ClientSize.Width, 2);
			//e.Graphics.FillRectangle(Brushes.Green, middle);

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
				
				// hover event for when hovered over background
				else if (TimeBar_BG.Contains(cursor))
				{
					PlaybackSettings.timeSelected = true;
					timeBarProgress.BackColor = cSliderSelected;
					if (!PlaybackSettings.edittingTime)
					{
						SliderHandle.Location = new Point(timeBarProgress.Location.X + timeBarProgress.Width - (SliderHandle.Width / 2), timeBarProgress.Location.Y - (SliderHandle.Height / 2) + (timeBarProgress.Height / 2));
						SliderHandle.Visible = true;
						SliderHandle.BringToFront();
					}
				}
				else if (!TimeBar_BG.Contains(cursor) && !PlaybackSettings.edittingTime)
				{
					PlaybackSettings.timeSelected = false;
					timeBarProgress.BackColor = cSliderUnselected;
					SliderHandle.Visible = false;
				}
			}
		}

		float timebarvalue;

		// Event when window gets resized
		protected override void OnResizeBegin(EventArgs e)
		{
			this.WindowState = FormWindowState.Normal;
			NormalWindowButton.Visible = false;
			MaximizeButton.Visible = true;

			timebarvalue = GetTimeBarValue();

			base.OnResizeBegin(e);
		}

		// Event when window is resizing
		protected override void OnResize(EventArgs e)
		{
			timeBarProgress.Location = TimeBar_BG.Location;
			timeBarProgress.Size = new Size((int)((float)TimeBar_BG.Width * (float)((float)timebarvalue / (float)100f)), timeBarProgress.Height);
			base.OnResize(e);
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

		#region Events
		#region Hover events
		// Mouse enters the play button
		private void PlayMouseEnter(object sender, EventArgs e)
		{
			PlayButtonUnhovered.Size = new Size(5, 5);
			Update();
			//PlayButtonUnhovered.Visible = false;
			//PlayButton.Visible = true;
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

		// Mouse enters the unenabled shuffle button
		private void ShuffleMouseEnter(object sender, EventArgs e)
		{
			ShuffleButtonUnhovered.Visible = false;
			ShuffleButton.Visible = true;
		}

		// Mouse leaves the unenabled shuffle button
		private void ShuffleMouseLeave(object sender, EventArgs e)
		{
			ShuffleButton.Visible = false;
			ShuffleButtonUnhovered.Visible = true;
		}

		// Mouse enters the enabled shuffle button
		private void EnabledShuffleMouseEnter(object sender, EventArgs e)
		{
			EnabledShuffleButtonUnhovered.Visible = false;
			EnabledShuffleButton.Visible = true;
		}

		// Mouse leaves the enabled shuffle button
		private void EnabledShuffleMouseLeave(object sender, EventArgs e)
		{
			EnabledShuffleButton.Visible = false;
			EnabledShuffleButtonUnhovered.Visible = true;
		}

		// Mouse enters the unenabled repeat button
		private void RepeatMouseEnter(object sender, EventArgs e)
		{
			RepeatButtonUnhovered.Visible = false;
			RepeatButton.Visible = true;
		}

		// Mouse leaves the unenabled repeat button
		private void RepeatMouseLeave(object sender, EventArgs e)
		{
			RepeatButton.Visible = false;
			RepeatButtonUnhovered.Visible = true;
			//RepeatButtonUnhovered.BringToFront();
		}

		// Mouse enters enabled repeat button
		private void EnabledRepeatMouseEnter(object sender, EventArgs e)
		{
			EnabledRepeatButtonUnhovered.Visible = false;
			EnabledRepeatButton.Visible = true;
		}

		// Mouse leaves enabled repeat button
		private void EnabledRepeatMouseLeave(object sender, EventArgs e)
		{
			EnabledRepeatButton.Visible = false;
			EnabledRepeatButtonUnhovered.Visible = true;
			//EnabledRepeatButtonUnhovered.BringToFront();
		}

		// Mouse enters enabled repeat one button
		private void EnabledRepeatOneMouseEnter(object sender, EventArgs e)
		{
			EnabledRepeatOneButtonUnhovered.Visible = false;
			EnabledRepeatOneButton.Visible = true;
		}

		// Mouse leaves enabled repeat one button
		private void EnabledRepeatOneMouseLeave(object sender, EventArgs e)
		{
			EnabledRepeatOneButton.Visible = false;
			EnabledRepeatOneButtonUnhovered.Visible = true;
			//EnabledRepeatOneButtonUnhovered.BringToFront();
		}
		#endregion

		#region Slider events
		bool checkUpSlider = false;

		// Mouse down on slider handle
		private void SliderHandleMouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (PlaybackSettings.timeSelected)
				{
					PlaybackSettings.edittingTime = true;
				}
			}
		}

		// Mouse up on slider handle
		private void SliderHandleMouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (PlaybackSettings.edittingTime)
				{
					PlaybackSettings.edittingTime = false;
					OnTimeBarValueChanged?.Invoke();
				}
			}
		}

		// Mouse enters slider
		private void SliderHandleMouseEnter(object sender, EventArgs e)
		{
			timeBarProgress.BackColor = cSliderSelected;
		}

		// Mouse exits slider
		private void SliderHandleMouseLeave(object sender, EventArgs e)
		{
			if (PlaybackSettings.edittingTime)
			{
				checkUpSlider = true;
			}
		}

		// Slider drag
		private void SliderHandleMouseMove(object sender, MouseEventArgs e)
		{
			if (PlaybackSettings.edittingTime)
			{
				SliderHandle.Location = new Point((int)Clamp(SliderHandle.Location.X + e.Location.X - (SliderHandle.Width / 2), TimeBar_BG.X - (SliderHandle.Width / 2), TimeBar_BG.X + TimeBar_BG.Width - (SliderHandle.Width / 2)), SliderHandle.Location.Y);
				timeBarProgress.Size = new Size((SliderHandle.Location.X + (SliderHandle.Width / 2)) - TimeBar_BG.X, timeBarProgress.Height);
			}
		}
		#endregion

		#region Form events
		// Mouse up event
		private void FormMouseUp(object sender, MouseEventArgs e)
		{
			if (checkUpSlider && PlaybackSettings.edittingTime)
			{
				PlaybackSettings.edittingTime = false;
				checkUpSlider = false;
				OnTimeBarValueChanged?.Invoke();
			}
		}

		// Mouse move event
		private void FormMouseMove(object sender, MouseEventArgs e)
		{
			
		}

		// Mouse click event
		private void FormMouseClick(object sender, MouseEventArgs e)
		{
			if (PlaybackSettings.timeSelected)
			{
				SliderHandle.Location = new Point((int)Clamp(e.Location.X - (SliderHandle.Width / 2), TimeBar_BG.X - (SliderHandle.Width / 2), TimeBar_BG.X + TimeBar_BG.Width - (SliderHandle.Width / 2)), SliderHandle.Location.Y);
				timeBarProgress.Size = new Size((SliderHandle.Location.X + (SliderHandle.Width / 2)) - TimeBar_BG.X, timeBarProgress.Height);
				OnTimeBarValueChanged?.Invoke();
			}
		}
		#endregion

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

		#region MusicControlButtons
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
			PlaybackSettings.isPaused = false;
			PauseButtonUnhovered.BringToFront();
			PlayButton.BringToFront();
			PlayButton.Visible = false;
			PauseButton.Visible = true;
		}

		// Press on the pause button
		private void PauseButton_Click(object sender, EventArgs e)
		{
			PlaybackSettings.isPaused = true;
			PlayButtonUnhovered.BringToFront();
			PauseButton.BringToFront();
			PauseButton.Visible = false;
			PlayButton.Visible = true;
		}

		// Press on the unenabled shuffle button
		private void ShuffleButton_Click(object sender, EventArgs e)
		{
			PlaybackSettings.shuffle = true;
			EnabledShuffleButtonUnhovered.BringToFront();
			ShuffleButton.BringToFront();
			ShuffleButton.Visible = false;
			EnabledShuffleButton.Visible = true;
		}

        // Press on the enabled shuffle button
        private void EnabledShuffleButton_Click(object sender, EventArgs e)
		{
			PlaybackSettings.shuffle = false;
			ShuffleButtonUnhovered.BringToFront();
			EnabledShuffleButton.BringToFront();
			EnabledShuffleButton.Visible = false;
			ShuffleButton.Visible = true;
		}

		// Press on the unenabled repeat button
		private void RepeatButton_Click(object sender, EventArgs e)
		{
			PlaybackSettings.repeatState = PlaybackSettings.RepeatState.REPEAT_ALL;
			EnabledRepeatButton.BringToFront();
			EnabledRepeatButtonUnhovered.BringToFront();
			RepeatButton.BringToFront();
			RepeatButton.Visible = false;
			EnabledRepeatButton.Visible = true;
		}

		// Press on the enabled repeat button
		private void EnabledRepeatButton_Click(object sender, EventArgs e)
		{
			PlaybackSettings.repeatState = PlaybackSettings.RepeatState.REPEAT_ONE;
			EnabledRepeatOneButton.BringToFront();
			EnabledRepeatOneButtonUnhovered.BringToFront();
			EnabledRepeatButton.BringToFront();
			EnabledRepeatButton.Visible = false;
			EnabledRepeatOneButton.Visible = true;
		}

		// Press on the enabled repeat one button
		private void EnabledRepeatOneButton_Click(object sender, EventArgs e)
		{
			PlaybackSettings.repeatState = PlaybackSettings.RepeatState.NONE;
			RepeatButton.BringToFront();
			RepeatButtonUnhovered.BringToFront();
			EnabledRepeatOneButton.BringToFront();
			EnabledRepeatOneButton.Visible = false;
			RepeatButton.Visible = true;
		}
        #endregion

        // Upload button
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }
        #endregion

        #region Functions
        private float Clamp(float value, float min, float max)
		{
			if (value < min)
				return min;
			else if (value > max)
				return max;
			else
				return value;
		}

		private float GetTimeBarValue()
		{
			return (float)timeBarProgress.Width / (float)TimeBar_BG.Width * (float)100f;
		}

		private void SetTimeBarProcessPercentage(float percentage)
		{
			timeBarProgress.Size = new Size((int)((float)TimeBar_BG.Width * (float)((float)percentage / (float)100f)), timeBarProgress.Height);
			if (PlaybackSettings.timeSelected)
			{
				SliderHandle.Location = new Point(timeBarProgress.Location.X + timeBarProgress.Width - (SliderHandle.Width / 2), timeBarProgress.Location.Y - (SliderHandle.Height / 2) + (timeBarProgress.Height / 2));
			}
		}
		#endregion
	}
}
