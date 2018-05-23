/*
 * (c) Abel Dieterich - HotkeyCode Inc.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using System.IO;
using NAudio.Wave;
using WebDav;
using System.Net;

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

		// Constructor
		public Form1()
		{
			InitializeComponent();
			this.FormBorderStyle = FormBorderStyle.None;
			this.DoubleBuffered = true;
			this.SetStyle(ControlStyles.ResizeRedraw, true);
			this.BackgroundImage = ResourceLoader.loadImage(rWindowBackground);
			this.MinimumSize = new Size(800, 500);
			this.FormClosed += new FormClosedEventHandler(onFormClosed);
			this.FormClosing += new FormClosingEventHandler(onFormClosing);
			this.Shown += new EventHandler(onFormShow);

			#region Instantiate top bar contents
			// Instatiate topbar title
			lTopBarTitle.Anchor = AnchorStyles.Top;
			lTopBarTitle.AutoSize = true;
			lTopBarTitle.BackColor = Color.Transparent;
			lTopBarTitle.Font = new Font("Roboto", 10f, FontStyle.Regular);
			lTopBarTitle.ForeColor = Color.White;
			lTopBarTitle.Location = new Point(this.ClientSize.Width / 2 - lTopBarTitle.Width / 2, TitleOffset);
			lTopBarTitle.Text = "VIBES";
			lTopBarTitle.TextAlign = ContentAlignment.MiddleCenter;
			lTopBarTitle.MouseMove += new MouseEventHandler(Mover);
			Controls.Add(lTopBarTitle);

			// Instantiate exit button
			bExitButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			bExitButton.BackColor = Color.Transparent;
			bExitButton.BackgroundImage = ResourceLoader.loadImage(rExitButton);
			bExitButton.BackgroundImageLayout = ImageLayout.Stretch;
			bExitButton.FlatAppearance.BorderSize = 0;
			bExitButton.FlatAppearance.MouseDownBackColor = Color.DarkRed;
			bExitButton.FlatAppearance.MouseOverBackColor = Color.Red;
			bExitButton.FlatStyle = FlatStyle.Flat;
			bExitButton.Location = new Point(this.ClientSize.Width - bExitButton.Width - ControlButtonsOffset, ControlButtonsOffset);
			bExitButton.Size = new Size(TopSize - ControlButtonsResize, TopSize - ControlButtonsResize);
			bExitButton.Click += new EventHandler(ExitButton_Click);
			Controls.Add(bExitButton);

			// Instantiate maximize button
			bMaximizeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			bMaximizeButton.BackColor = Color.Transparent;
			bMaximizeButton.BackgroundImage = ResourceLoader.loadImage(rMaximizeButton);
			bMaximizeButton.BackgroundImageLayout = ImageLayout.Stretch;
			bMaximizeButton.FlatAppearance.BorderSize = 0;
			bMaximizeButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
			bMaximizeButton.FlatAppearance.MouseOverBackColor = Color.Gray;
			bMaximizeButton.FlatStyle = FlatStyle.Flat;
			bMaximizeButton.Size = new Size(TopSize - ControlButtonsResize, TopSize - ControlButtonsResize);
			bMaximizeButton.Location = new Point(this.ClientSize.Width - bExitButton.Width - ControlButtonsOffset - bExitButton.Width, ControlButtonsOffset);
			bMaximizeButton.Click += new EventHandler(MaximizeButton_Click);
			Controls.Add(bMaximizeButton);

			//Instantiate exit maximize button
			bExitMaximizeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			bExitMaximizeButton.BackColor = Color.Transparent;
			bExitMaximizeButton.BackgroundImage = ResourceLoader.loadImage(rExitMaximizeButton);
			bExitMaximizeButton.BackgroundImageLayout = ImageLayout.Stretch;
			bExitMaximizeButton.FlatAppearance.BorderSize = 0;
			bExitMaximizeButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
			bExitMaximizeButton.FlatAppearance.MouseOverBackColor = Color.Gray;
			bExitMaximizeButton.FlatStyle = FlatStyle.Flat;
			bExitMaximizeButton.Size = new Size(TopSize - ControlButtonsResize, TopSize - ControlButtonsResize);
			bExitMaximizeButton.Location = new Point(this.ClientSize.Width - bExitButton.Width - ControlButtonsOffset - bExitButton.Width, ControlButtonsOffset);
			bExitMaximizeButton.Visible = false;
			bExitMaximizeButton.Click += new EventHandler(ExitMaximizeButton_Click);
			Controls.Add(bExitMaximizeButton);

			// Instantiate minimize button
			bMinimizeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			bMinimizeButton.BackColor = Color.Transparent;
			bMinimizeButton.BackgroundImage = ResourceLoader.loadImage(rMinimizeButton);
			bMinimizeButton.BackgroundImageLayout = ImageLayout.Stretch;
			bMinimizeButton.FlatAppearance.BorderSize = 0;
			bMinimizeButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
			bMinimizeButton.FlatAppearance.MouseOverBackColor = Color.Gray;
			bMinimizeButton.FlatStyle = FlatStyle.Flat;
			bMinimizeButton.Size = new Size(TopSize - ControlButtonsResize, TopSize - ControlButtonsResize);
			bMinimizeButton.Location = new Point(this.ClientSize.Width - bExitButton.Width - bMaximizeButton.Width - ControlButtonsOffset - bMinimizeButton.Width, ControlButtonsOffset);
			bMinimizeButton.Click += new EventHandler(MinimizeButton_Click);
			Controls.Add(bMinimizeButton);
			#endregion

			#region Instantiate playpause button
			// Settings for play button
			bPlayPauseButton.BackColor = Color.Transparent;
			bPlayPauseButton.BackgroundImage = ResourceLoader.loadImage(rPlayButton);
			bPlayPauseButton.BackgroundImageLayout = ImageLayout.Stretch;
			bPlayPauseButton.FlatAppearance.BorderSize = 0;
			bPlayPauseButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
			bPlayPauseButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
			bPlayPauseButton.FlatStyle = FlatStyle.Flat;
			bPlayPauseButton.Size = new Size(PlayPauseSize + PlayPauseResize, PlayPauseSize + PlayPauseResize);
			bPlayPauseButton.Location = new Point(this.ClientSize.Width / 2 - bPlayPauseButton.Width / 2, this.ClientSize.Height - MusicControlSize + PlayPauseTopOffset - (PlayPauseResize / 2));
			bPlayPauseButton.Visible = false;
			bPlayPauseButton.Click += new EventHandler(PlayPauseButton_Click);
			bPlayPauseButton.MouseLeave += new EventHandler(PlayMouseLeave);
			Controls.Add(bPlayPauseButton);

			// Settings for unhovered play button
			bPlayPauseButtonUnhovered.BackColor = Color.Transparent;
			bPlayPauseButtonUnhovered.BackgroundImage = ResourceLoader.loadImage(rPlayButton);
			bPlayPauseButtonUnhovered.BackgroundImageLayout = ImageLayout.Stretch;
			bPlayPauseButtonUnhovered.FlatAppearance.BorderSize = 0;
			bPlayPauseButtonUnhovered.FlatAppearance.MouseDownBackColor = Color.Transparent;
			bPlayPauseButtonUnhovered.FlatAppearance.MouseOverBackColor = Color.Transparent;
			bPlayPauseButtonUnhovered.FlatStyle = FlatStyle.Flat;
			bPlayPauseButtonUnhovered.Size = new Size(PlayPauseSize, PlayPauseSize);
			bPlayPauseButtonUnhovered.Location = new Point(this.ClientSize.Width / 2 - bPlayPauseButtonUnhovered.Width / 2, this.ClientSize.Height - MusicControlSize + PlayPauseTopOffset);
			bPlayPauseButtonUnhovered.MouseEnter += new EventHandler(PlayMouseEnter);
			Controls.Add(bPlayPauseButtonUnhovered);
			#endregion

			#region Instantiate back and skip button
			// Instantiate skip button
			bSkipButton.BackColor = Color.Transparent;
			bSkipButton.BackgroundImage = ResourceLoader.loadImage(rSkipButton);
			bSkipButton.BackgroundImageLayout = ImageLayout.Stretch;
			bSkipButton.FlatAppearance.BorderSize = 0;
			bSkipButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
			bSkipButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
			bSkipButton.FlatStyle = FlatStyle.Flat;
			bSkipButton.Size = new Size(SkipBackButtonSize + SkipBackResize, SkipBackButtonSize + SkipBackResize);
			bSkipButton.Location = new Point(bPlayPauseButton.Location.X + bPlayPauseButton.Width + SkipBackOffset - (SkipBackResize / 2), bPlayPauseButton.Location.Y + ((bPlayPauseButton.Height - bSkipButton.Height) / 2));
			bSkipButton.Visible = false;
			bSkipButton.MouseLeave += new EventHandler(SkipMouseLeave);
			bSkipButton.Click += new EventHandler(SkipButton_Click);
			Controls.Add(bSkipButton);

			// Instantiate unhovered skip button
			bSkipButtonUnhovered.BackColor = Color.Transparent;
			bSkipButtonUnhovered.BackgroundImage = ResourceLoader.loadImage(rSkipButton);
			bSkipButtonUnhovered.BackgroundImageLayout = ImageLayout.Stretch;
			bSkipButtonUnhovered.FlatAppearance.BorderSize = 0;
			bSkipButtonUnhovered.FlatAppearance.MouseDownBackColor = Color.Transparent;
			bSkipButtonUnhovered.FlatAppearance.MouseOverBackColor = Color.Transparent;
			bSkipButtonUnhovered.FlatStyle = FlatStyle.Flat;
			bSkipButtonUnhovered.Size = new Size(SkipBackButtonSize, SkipBackButtonSize);
			bSkipButtonUnhovered.Location = new Point(bPlayPauseButton.Location.X + bPlayPauseButton.Width + SkipBackOffset, bPlayPauseButton.Location.Y + ((bPlayPauseButton.Height - bSkipButtonUnhovered.Height) / 2));
			bSkipButtonUnhovered.MouseEnter += new EventHandler(SkipMouseEnter);
			Controls.Add(bSkipButtonUnhovered);

			// Instantiate back button
			bBackButton.BackColor = Color.Transparent;
			bBackButton.BackgroundImage = ResourceLoader.loadImage(rBackButton);
			bBackButton.BackgroundImageLayout = ImageLayout.Stretch;
			bBackButton.FlatAppearance.BorderSize = 0;
			bBackButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
			bBackButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
			bBackButton.FlatStyle = FlatStyle.Flat;
			bBackButton.Size = new Size(SkipBackButtonSize + SkipBackResize, SkipBackButtonSize + SkipBackResize);
			bBackButton.Location = new Point(bPlayPauseButton.Location.X + bPlayPauseButton.Width + SkipBackOffset - (SkipBackResize / 2), bPlayPauseButton.Location.Y + ((bPlayPauseButton.Height - bSkipButton.Height) / 2));
			bBackButton.Visible = false;
			bBackButton.MouseLeave += new EventHandler(BackMouseLeave);
			bBackButton.Click += new EventHandler(BackButton_Click);
			Controls.Add(bBackButton);

			// Instantiate unhovered back button
			bBackButtonUnhovered.BackColor = Color.Transparent;
			bBackButtonUnhovered.BackgroundImage = ResourceLoader.loadImage(rBackButton);
			bBackButtonUnhovered.BackgroundImageLayout = ImageLayout.Stretch;
			bBackButtonUnhovered.FlatAppearance.BorderSize = 0;
			bBackButtonUnhovered.FlatAppearance.MouseDownBackColor = Color.Transparent;
			bBackButtonUnhovered.FlatAppearance.MouseOverBackColor = Color.Transparent;
			bBackButtonUnhovered.FlatStyle = FlatStyle.Flat;
			bBackButtonUnhovered.Size = new Size(SkipBackButtonSize, SkipBackButtonSize);
			bBackButtonUnhovered.Location = new Point(bPlayPauseButton.Location.X - bBackButtonUnhovered.Width - SkipBackOffset, bPlayPauseButton.Location.Y + ((bPlayPauseButton.Height - bBackButtonUnhovered.Height) / 2));
			bBackButtonUnhovered.MouseEnter += new EventHandler(BackMouseEnter);
			Controls.Add(bBackButtonUnhovered);
			#endregion

			#region Instantiate shuffle button
			// Instantiate shuffle button
			bShuffleButton.BackColor = Color.Transparent;
			bShuffleButton.BackgroundImage = ResourceLoader.loadImage(rShuffleButtonDisabled);
			bShuffleButton.BackgroundImageLayout = ImageLayout.Stretch;
			bShuffleButton.FlatAppearance.BorderSize = 0;
			bShuffleButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
			bShuffleButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
			bShuffleButton.FlatStyle = FlatStyle.Flat;
			bShuffleButton.Size = new Size(ShuffleRepeatButtonSize + ShuffleRepeatResize, ShuffleRepeatButtonSize + ShuffleRepeatResize);
			bShuffleButton.Location = new Point(bBackButton.Location.X - bShuffleButton.Width - ShuffleRepeatOffset + (ShuffleRepeatResize / 2), bPlayPauseButton.Location.Y + ((bPlayPauseButton.Height - bShuffleButton.Height) / 2));
			bShuffleButton.Visible = false;
			bShuffleButton.Click += new EventHandler(ShuffleButton_Click);
			bShuffleButton.MouseLeave += new EventHandler(ShuffleMouseLeave);
			Controls.Add(bShuffleButton);

			// Instantiate unhovered shuffle button
			bShuffleButtonUnhovered.BackColor = Color.Transparent;
			bShuffleButtonUnhovered.BackgroundImage = ResourceLoader.loadImage(rShuffleButtonDisabled);
			bShuffleButtonUnhovered.BackgroundImageLayout = ImageLayout.Stretch;
			bShuffleButtonUnhovered.FlatAppearance.BorderSize = 0;
			bShuffleButtonUnhovered.FlatAppearance.MouseDownBackColor = Color.Transparent;
			bShuffleButtonUnhovered.FlatAppearance.MouseOverBackColor = Color.Transparent;
			bShuffleButtonUnhovered.FlatStyle = FlatStyle.Flat;
			bShuffleButtonUnhovered.Size = new Size(ShuffleRepeatButtonSize, ShuffleRepeatButtonSize);
			bShuffleButtonUnhovered.Location = new Point(bBackButton.Location.X - bShuffleButtonUnhovered.Width - ShuffleRepeatOffset, bPlayPauseButton.Location.Y + ((bPlayPauseButton.Height - bShuffleButtonUnhovered.Height) / 2));
			bShuffleButtonUnhovered.Click += new EventHandler(ShuffleButton_Click);
			bShuffleButtonUnhovered.MouseEnter += new EventHandler(ShuffleMouseEnter);
			Controls.Add(bShuffleButtonUnhovered);
			#endregion

			#region Instantiate repeat button
			// Instantiate repeat button
			bRepeatButton.BackColor = Color.Transparent;
			bRepeatButton.BackgroundImage = ResourceLoader.loadImage(rRepeatButtonDisabled);
			bRepeatButton.BackgroundImageLayout = ImageLayout.Stretch;
			bRepeatButton.FlatAppearance.BorderSize = 0;
			bRepeatButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
			bRepeatButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
			bRepeatButton.FlatStyle = FlatStyle.Flat;
			bRepeatButton.Size = new Size(ShuffleRepeatButtonSize + ShuffleRepeatResize, ShuffleRepeatButtonSize + ShuffleRepeatResize);
			bRepeatButton.Location = new Point(bSkipButton.Location.X + bSkipButton.Width + ShuffleRepeatOffset - (ShuffleRepeatResize / 2), bPlayPauseButton.Location.Y + ((bPlayPauseButton.Height - bRepeatButton.Height) / 2));
			bRepeatButton.Visible = false;
			bRepeatButton.Click += new EventHandler(RepeatButton_Click);
			bRepeatButton.MouseLeave += new EventHandler(RepeatMouseLeave);
			Controls.Add(bRepeatButton);

			// Instantiate unhovered repeat button
			bRepeatButtonUnhovered.BackColor = Color.Transparent;
			bRepeatButtonUnhovered.BackgroundImage = ResourceLoader.loadImage(rRepeatButtonDisabled);
			bRepeatButtonUnhovered.BackgroundImageLayout = ImageLayout.Stretch;
			bRepeatButtonUnhovered.FlatAppearance.BorderSize = 0;
			bRepeatButtonUnhovered.FlatAppearance.MouseDownBackColor = Color.Transparent;
			bRepeatButtonUnhovered.FlatAppearance.MouseOverBackColor = Color.Transparent;
			bRepeatButtonUnhovered.FlatStyle = FlatStyle.Flat;
			bRepeatButtonUnhovered.Size = new Size(ShuffleRepeatButtonSize, ShuffleRepeatButtonSize);
			bRepeatButtonUnhovered.Location = new Point(bSkipButton.Location.X + bSkipButton.Width + ShuffleRepeatOffset, bPlayPauseButton.Location.Y + ((bPlayPauseButton.Height - bRepeatButtonUnhovered.Height) / 2));
			bRepeatButtonUnhovered.MouseEnter += new EventHandler(RepeatMouseEnter);
			Controls.Add(bRepeatButtonUnhovered);
			#endregion

			#region Instantiate Timebar
			// Timebar settings
			pTimeBarProgress.Size = new Size(0, TimeBar_BG.Height);                      // Set scale for panel
			pSliderHandle.Size = new Size(SliderHandleRadius, SliderHandleRadius);       // Resize handle for all sliders
			pTimeBarProgress.BackColor = cSliderUnselected;                              // Color the timeBarProgress panel
			pTimeBarProgress.Location = TimeBar_BG.Location;                             // Set location of panel
			Controls.Add(pTimeBarProgress);                                              // Instantiate the time bar progress
			pSliderHandle.BringToFront();                                                // Bring slider handle forward

			// Event for when hovered over the time progress
			pTimeBarProgress.MouseEnter += new EventHandler(new Action<object, EventArgs>((object sender, EventArgs args) =>
			{
				PlaybackSettings.timeSelected = true;
				pTimeBarProgress.BackColor = cSliderSelected;
				pVolumeBarVolume.BackColor = cSliderUnselected;
				Update();

				if (!PlaybackSettings.edittingTime)
				{
					pSliderHandle.Location = new Point(pTimeBarProgress.Location.X + pTimeBarProgress.Width - (pSliderHandle.Width / 2), pTimeBarProgress.Location.Y - (pSliderHandle.Height / 2) + (pTimeBarProgress.Height / 2));
					pSliderHandle.Visible = true;
					pSliderHandle.BringToFront();
				}
			}));

			// Event for when clicked on time progress
			pTimeBarProgress.MouseDown += new MouseEventHandler(new Action<object, MouseEventArgs>((object sender, MouseEventArgs args) =>
			{
				PlaybackSettings.edittingTime = true;
				pTimeBarProgress.Size = new Size(args.Location.X, pTimeBarProgress.Height);
				pSliderHandle.Location = new Point(pTimeBarProgress.Location.X + pTimeBarProgress.Width - (pSliderHandle.Width / 2), pTimeBarProgress.Location.Y - (pSliderHandle.Height / 2) + (pTimeBarProgress.Height / 2));
			}));

			// Event for when mouse moves on time progress
			pTimeBarProgress.MouseMove += new MouseEventHandler(new Action<object, MouseEventArgs>((object sender, MouseEventArgs args) =>
			{
				if (PlaybackSettings.edittingTime)
				{
					pTimeBarProgress.Size = new Size((int)Clamp(args.Location.X, 0, TimeBar_BG.Width), pTimeBarProgress.Height);
					pSliderHandle.Location = new Point(pTimeBarProgress.Location.X + pTimeBarProgress.Width - (pSliderHandle.Width / 2), pTimeBarProgress.Location.Y - (pSliderHandle.Height / 2) + (pTimeBarProgress.Height / 2));
				}
			}));

			// Event for when mouse up on time progress
			pTimeBarProgress.MouseUp += new MouseEventHandler(new Action<object, MouseEventArgs>((object sender, MouseEventArgs args) =>
			{
				PlaybackSettings.edittingTime = false;
				OnTimeBarValueChanged?.Invoke(GetTimeBarValue());
				if (!PlaybackSettings.timeSelected)
					pTimeBarProgress.BackColor = cSliderUnselected;
			}));

			// Instatiate time passed label
			lSongTimePassed.AutoSize = true;
			lSongTimePassed.BackColor = Color.Transparent;
			lSongTimePassed.Font = new Font("Roboto", 8f, FontStyle.Regular);
			lSongTimePassed.ForeColor = Color.FromArgb(212, 212, 212);
			lSongTimePassed.Text = "0:00";
			lSongTimePassed.TextAlign = ContentAlignment.MiddleCenter;
			lSongTimePassed.Location = new Point(TimeBar_BG.X - lSongTimePassed.Width - TimeIndicatorsOffset, TimeBar_BG.Y + (TimeBar_BG.Height / 2) - (lSongTimePassed.Height / 2));
			Controls.Add(lSongTimePassed);

			// Instantiate total time label
			lSongTotalTime.AutoSize = true;
			lSongTotalTime.BackColor = Color.Transparent;
			lSongTotalTime.Font = new Font("Roboto", 8f, FontStyle.Regular);
			lSongTotalTime.ForeColor = Color.FromArgb(212, 212, 212);
			lSongTotalTime.Text = "0:00";
			lSongTotalTime.TextAlign = ContentAlignment.MiddleCenter;
			lSongTotalTime.Location = new Point(TimeBar_BG.X + TimeBar_BG.Width + TimeIndicatorsOffset, TimeBar_BG.Y + (TimeBar_BG.Height / 2) - (lSongTotalTime.Height / 2));
			Controls.Add(lSongTotalTime);
			#endregion

			#region Instantiate Volumebar
			// Timebar settings
			pVolumeBarVolume.Size = new Size((int)(VolumeBar_BG.Width * ((float)PlaybackSettings.volume / 100)), VolumeBar_BG.Height);   // Set scale for panel
			pVolumeBarVolume.BackColor = cSliderUnselected;                                                                              // Color the timeBarProgress panel
			pVolumeBarVolume.Location = VolumeBar_BG.Location;                                                                           // Set location of panel
			Controls.Add(pVolumeBarVolume);                                                                                              // Instantiate the volume bar progress
			pSliderHandle.BringToFront();                                                                                                // Bring slider handle forward

			// Event for when hovered over the time progress
			pVolumeBarVolume.MouseEnter += new EventHandler(new Action<object, EventArgs>((object sender, EventArgs args) =>
			{
				PlaybackSettings.volumeSelected = true;
				pVolumeBarVolume.BackColor = cSliderSelected;
				pTimeBarProgress.BackColor = cSliderUnselected;
				Update();

				if (!PlaybackSettings.edittingVolume)
				{
					pSliderHandle.Location = new Point(pVolumeBarVolume.Location.X + pVolumeBarVolume.Width - (pSliderHandle.Width / 2), pVolumeBarVolume.Location.Y - (pSliderHandle.Height / 2) + (pVolumeBarVolume.Height / 2));
					pSliderHandle.Visible = true;
					pSliderHandle.BringToFront();
				}
			}));

			// Event for when clicked on time progress
			pVolumeBarVolume.MouseDown += new MouseEventHandler(new Action<object, MouseEventArgs>((object sender, MouseEventArgs args) =>
			{
				PlaybackSettings.edittingVolume = true;
				pVolumeBarVolume.Size = new Size(args.Location.X, pVolumeBarVolume.Height);
				pSliderHandle.Location = new Point(pVolumeBarVolume.Location.X + pVolumeBarVolume.Width - (pSliderHandle.Width / 2), pVolumeBarVolume.Location.Y - (pSliderHandle.Height / 2) + (pVolumeBarVolume.Height / 2));
			}));

			// Event for when mouse moves on time progress
			pVolumeBarVolume.MouseMove += new MouseEventHandler(new Action<object, MouseEventArgs>((object sender, MouseEventArgs args) =>
			{
				if (PlaybackSettings.edittingVolume)
				{
					pVolumeBarVolume.Size = new Size((int)Clamp(args.Location.X, 0, VolumeBar_BG.Width), pVolumeBarVolume.Height);
					pSliderHandle.Location = new Point(pVolumeBarVolume.Location.X + pVolumeBarVolume.Width - (pSliderHandle.Width / 2), pVolumeBarVolume.Location.Y - (pSliderHandle.Height / 2) + (pVolumeBarVolume.Height / 2));
				}
			}));

			// Event for when mouse up on time progress
			pVolumeBarVolume.MouseUp += new MouseEventHandler(new Action<object, MouseEventArgs>((object sender, MouseEventArgs args) =>
			{
				PlaybackSettings.edittingVolume = false;
				OnVolumeBarValueChanged?.Invoke(GetVolumeBarValue());
				if (!PlaybackSettings.volumeSelected)
					pVolumeBarVolume.BackColor = cSliderUnselected;
			}));

			// Instantiate volume speaker
			pbVolumeSpeaker.BackColor = Color.Transparent;
			pbVolumeSpeaker.Image = ResourceLoader.loadImage(rVolumeSpeaker);
			pbVolumeSpeaker.SizeMode = PictureBoxSizeMode.StretchImage;
			pbVolumeSpeaker.Location = new Point(VolumeBar_BG.X - pbVolumeSpeaker.Width - VolumeSpeakerOffset, VolumeBar_BG.Y + (VolumeBar_BG.Height / 2) - (pbVolumeSpeaker.Height / 2));
			pbVolumeSpeaker.Size = new Size(15, 15);
			Controls.Add(pbVolumeSpeaker);
			#endregion

			#region Instantiate slider handle
			// Instantiate slider handle
			pSliderHandle.BackColor = Color.Transparent;
			pSliderHandle.BackgroundImage = ResourceLoader.loadImage(rSliderHandle);
			pSliderHandle.BackgroundImageLayout = ImageLayout.Stretch;
			pSliderHandle.Size = new Size(10, 10);
			pSliderHandle.Visible = false;
			pSliderHandle.MouseDown += new MouseEventHandler(SliderHandleMouseDown);
			pSliderHandle.MouseEnter += new EventHandler(SliderHandleMouseEnter);
			pSliderHandle.MouseLeave += new EventHandler(SliderHandleMouseLeave);
			pSliderHandle.MouseMove += new MouseEventHandler(SliderHandleMouseMove);
			pSliderHandle.MouseUp += new MouseEventHandler(SliderHandleMouseUp);
			Controls.Add(pSliderHandle);
			#endregion

			#region Instantiate song info
			// Instantiate cover
			pbSongCover.Image = ResourceLoader.loadImage(rEmptyCover);
			pbSongCover.SizeMode = PictureBoxSizeMode.StretchImage;
			pbSongCover.Location = new Point(MusicControl.X + ((MusicControl.Height - (MusicControl.Height / 100 * CoverPercentage)) / 2), MusicControl.Y + ((MusicControl.Height - (MusicControl.Height / 100 * CoverPercentage)) / 2));
			pbSongCover.Size = new Size(MusicControl.Height / 100 * CoverPercentage, MusicControl.Height / 100 * CoverPercentage);
			Controls.Add(pbSongCover);

			// Instantiates song title label
			lSongTitle.AutoSize = true;
			lSongTitle.BackColor = Color.Transparent;
			lSongTitle.Font = new Font("Roboto Medium", 10f, FontStyle.Regular);
			lSongTitle.ForeColor = Color.FromArgb(226, 226, 226);
			lSongTitle.TextAlign = ContentAlignment.BottomLeft;
			lSongTitle.Location = new Point(pbSongCover.Location.X + pbSongCover.Width + SongInfoOffset, pbSongCover.Location.Y + (pbSongCover.Height / 2) - ((lSongTitle.Height + lSongArtist.Height) / 2));
			lSongTitle.Text = "";
			lSongTitle.Margin = new Padding(0, 0, 0, 0);
			lSongTitle.MouseEnter += new EventHandler(StartTitleCarousel);
			Controls.Add(lSongTitle);

			// Instantiates song artist label
			lSongArtist.AutoSize = true;
			lSongArtist.BackColor = Color.Transparent;
			lSongArtist.Font = new Font("Roboto", 9f, FontStyle.Regular);
			lSongArtist.ForeColor = Color.FromArgb(174, 174, 174);
			lSongArtist.TextAlign = ContentAlignment.TopLeft;
			lSongArtist.Location = new Point(pbSongCover.Location.X + pbSongCover.Width + SongInfoOffset, pbSongCover.Location.Y + (pbSongCover.Height / 2) + (lSongTitle.Height - ((lSongTitle.Height + lSongArtist.Height) / 2)));
			lSongArtist.Text = "";
			lSongArtist.Margin = new Padding(0, 0, 0, 0);
			lSongArtist.MouseEnter += new EventHandler(StartArtistsCarousel);
			Controls.Add(lSongArtist);

			SetSongInfo("TITLE", "ARTISTS");
			//SetSongInfo("Veel te lange title die nooit past in dat ding dus daarom carousel", "Ook een veel te lange artistname die wederom niet past in dat ding en daarom carousel");

			// Instantiate right hide panel
			SongInfoHide.BackColor = cMusicControl;
			SongInfoHide.Size = new Size((int)((float)this.MinimumSize.Width * (float)((float)TimeBarPercentage / (float)100f)) + (2 * lSongTimePassed.Width) + (2 * TimeIndicatorsOffset), lSongTitle.Height + lSongArtist.Height);
			SongInfoHide.Location = new Point(lSongTimePassed.Location.X, pbSongCover.Location.Y + (pbSongCover.Height / 2) - (SongInfoHide.Height / 2));
			Controls.Add(SongInfoHide);

			lSongTitle.SendToBack();
			lSongArtist.SendToBack();
			pbSongCover.BringToFront();
			#endregion

			pe = new PlaybackEngine();
			pe.OnNewSong += loadNewSongInfo;
			pe.OnTimeChanged += updateTimebar;
			pe.OnSongPause += onStreamPause;
			OnVolumeBarValueChanged += pe.SetVolume;
			OnTimeBarValueChanged += pe.GotoPercentage;			
		}

		#region Resize constants
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

		#region Resource name constants
		const string rWindowBackground = "window-background";
		const string rEmptyCover = "empty-cover";

		const string rSliderHandle = "slider-handle";

		const string rExitButton = "topbar-exit";
		const string rMaximizeButton = "topbar-maximize";
		const string rExitMaximizeButton = "topbar-exit-maximize";
		const string rMinimizeButton = "topbar-minimize";

		const string rPlayButton = "musiccontrol-play";
		const string rPauseButton = "musiccontrol-pause";
		const string rSkipButton = "musiccontrol-skip";
		const string rBackButton = "musiccontrol-back";
		const string rShuffleButtonDisabled = "musiccontrol-shuffle-disabled";
		const string rShuffleButtonEnabled = "musiccontrol-shuffle-enabled";
		const string rRepeatButtonDisabled = "musiccontrol-repeat-disabled";
		const string rRepeatButtonEnabled = "musiccontrol-repeat-enabled";
		const string rRepeatButtonOneEnabled = "musiccontrol-repeat-one-enabled";
		const string rVolumeSpeaker = "musiccontrol-speaker";
		#endregion

		#region Sizes and offsets
		const int TopSize = 20;                         // Size of the top bar

		const int ControlButtonsOffset = 2;             // Offset of controlbuttons
		const int ControlButtonsResize = 4;				// How much pixels the control buttons should be smaller

		const int BorderSize = 5;						// Size of the border, witch is used to resize

		const int TitleOffset = 2;                      // How far the title should be off the top of the window

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

		const int TimeBarPercentage = 30;               // How much percentage the time bar should take from the whole width of the window
		const int TimeBarOffset = 27;                   // How far the timebar should be off the bottom
		const int TimeIndicatorsOffset = 5;				// How far the time indicators should be from the timebar

		const int VolumeBarWidth = 100;					// How much wide the volume bar should be
		const int VolumeBarOffset = 20;                 // How far the volumebar should be off the right of the window
		const int VolumeSpeakerOffset = 10;				// How far should the volume speaker be from the volume bar

		const int SliderHeight = 5;						// How high a slider should be
		const int SliderHandleRadius = 12;              // Radius of slider handle

		const int CoverPercentage = 70;                 // How much space the cover should take from the music control in height
		const int SongInfoOffset = 7;                   // How far the song info should be from the cover
		const int SongInfoMaxSize = 155;				// How wide the song info can be
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
		// Volumebar of what sound level the music is currently
		Rectangle VolumeBar_BG { get { return new Rectangle(this.ClientSize.Width - VolumeBarOffset - VolumeBarWidth, MusicControl.Y + (MusicControl.Height / 2) - SliderHeight, VolumeBarWidth, SliderHeight); } }
		#endregion

		#region Colors
		Color cTopBar = Color.FromArgb(22, 22, 22);
		Color cMusicControl = Color.FromArgb(53, 53, 53);
		Color cSliderBG = Color.FromArgb(90, 90, 90);
		Color cSliderUnselected = Color.FromArgb(153, 0, 0);
		Color cSliderSelected = Color.FromArgb(204, 0, 0);
		#endregion

		#region Controls
		// Panels
		Panel pTimeBarProgress = new Panel();
		Panel pVolumeBarVolume = new Panel();
		Panel pSliderHandle = new Panel();
		Panel SongInfoHide = new Panel();
		Panel pLeftHide = new Panel();

		// Buttons
		Button bPlayPauseButton = new Button();
		Button bPlayPauseButtonUnhovered = new Button();
		Button bSkipButton = new Button();
		Button bSkipButtonUnhovered = new Button();
		Button bBackButton = new Button();
		Button bBackButtonUnhovered = new Button();
		Button bShuffleButton = new Button();
		Button bShuffleButtonUnhovered = new Button();
		Button bRepeatButton = new Button();
		Button bRepeatButtonUnhovered = new Button();

		Button bExitButton = new Button();
		Button bMaximizeButton = new Button();
		Button bExitMaximizeButton = new Button();
		Button bMinimizeButton = new Button();

		// Labels
		Label lTopBarTitle = new Label();
		Label lSongTimePassed = new Label();
		Label lSongTotalTime = new Label();
		Label lSongTitle = new Label();
		Label lSongArtist = new Label();

		// Picture boxes
		PictureBox pbSongCover = new PictureBox();
		PictureBox pbVolumeSpeaker = new PictureBox();
		#endregion

		#region Variables
		public delegate void _OnTimeBarValueChanged(float value);
		public _OnTimeBarValueChanged OnTimeBarValueChanged;

		public delegate void _OnVolumeBarValueChanged(float value);
		public _OnVolumeBarValueChanged OnVolumeBarValueChanged;

		public const int songInfoCarouselSpeed = 30;
		public const string songInfoCarouselSpace = "        ";

		private const double backTime = 1.5;

		private PlaybackEngine pe;
		#endregion

		#region Forms functions
		// Draw graphics
		protected override void OnPaint(PaintEventArgs e)
		{
			// Draw the top bar
			e.Graphics.FillRectangle(new SolidBrush(cTopBar), TopBar);

			// Draw the music control background
			e.Graphics.FillRectangle(new SolidBrush(cMusicControl), MusicControl);
			
			// Draw the timebar background
			e.Graphics.FillRectangle(new SolidBrush(cSliderBG), TimeBar_BG);

			// Draw the volumebar background
			e.Graphics.FillRectangle(new SolidBrush(cSliderBG), VolumeBar_BG);

			#region Debug shapes
			// Middle line through play/pause button (DEBUG ONLY)
			//Rectangle middle = new Rectangle(0, PlayButton.Location.Y + (PlayButton.Height / 2) - 1, this.ClientSize.Width, 2);
			//e.Graphics.FillRectangle(Brushes.Green, middle);

			// Fill rectangles for resizing (DEBUG ONLY)
			//e.Graphics.FillRectangle(Brushes.Green, _Top);
			//e.Graphics.FillRectangle(Brushes.Green, _Left);
			//e.Graphics.FillRectangle(Brushes.Green, _Right);
			//e.Graphics.FillRectangle(Brushes.Green, _Bottom);
			#endregion
		}
		// Window control
		protected override void WndProc(ref Message message)
		{
			base.WndProc(ref message);

			// Process controls
			if (message.Msg == 0x84)
			{
				Point cursor = this.PointToClient(Cursor.Position);

				#region Resize check
				if (TopLeft.Contains(cursor)) message.Result = (IntPtr)HTTOPLEFT;
				else if (TopRight.Contains(cursor)) message.Result = (IntPtr)HTTOPRIGHT;
				else if (BottomLeft.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMLEFT;
				else if (BottomRight.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMRIGHT;

				else if (_Top.Contains(cursor)) message.Result = (IntPtr)HTTOP;
				else if (_Left.Contains(cursor)) message.Result = (IntPtr)HTLEFT;
				else if (_Right.Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
				else if (_Bottom.Contains(cursor)) message.Result = (IntPtr)HTBOTTOM;

				else if (TopBar.Contains(cursor)) message.Result = (IntPtr)HTTOPBARMOVE;
				#endregion

				#region Time/Volumebar check
				// hover event for when hovered over background of timebar
				else if (TimeBar_BG.Contains(cursor))
				{
					PlaybackSettings.volumeSelected = false;
					pVolumeBarVolume.BackColor = cSliderUnselected;

					PlaybackSettings.timeSelected = true;
					pTimeBarProgress.BackColor = cSliderSelected;
					if (!PlaybackSettings.edittingTime)
					{
						pSliderHandle.Location = new Point(pTimeBarProgress.Location.X + pTimeBarProgress.Width - (pSliderHandle.Width / 2), pTimeBarProgress.Location.Y - (pSliderHandle.Height / 2) + (pTimeBarProgress.Height / 2));
						pSliderHandle.Visible = true;
						pSliderHandle.BringToFront();
					}
				}
				else if (VolumeBar_BG.Contains(cursor))
				{
					PlaybackSettings.timeSelected = false;
					pTimeBarProgress.BackColor = cSliderUnselected;
					
					PlaybackSettings.volumeSelected = true;
					pVolumeBarVolume.BackColor = cSliderSelected;
					if (!PlaybackSettings.edittingVolume)
					{
						pSliderHandle.Location = new Point(pVolumeBarVolume.Location.X + pVolumeBarVolume.Width - (pSliderHandle.Width / 2), pVolumeBarVolume.Location.Y - (pSliderHandle.Height / 2) + (pVolumeBarVolume.Height / 2));
						pSliderHandle.Visible = true;
						pSliderHandle.BringToFront();
					}
				}

				else if (!TimeBar_BG.Contains(cursor) && !VolumeBar_BG.Contains(cursor))
				{
					PlaybackSettings.timeSelected = false;
					pTimeBarProgress.BackColor = cSliderUnselected;
					pSliderHandle.Visible = false;

					PlaybackSettings.volumeSelected = false;
					pVolumeBarVolume.BackColor = cSliderUnselected;
					pSliderHandle.Visible = false;
				}
				#endregion
			}
		}

		// Event when window gets resized
		float timebarvalue;
		protected override void OnResizeBegin(EventArgs e)
		{
			this.WindowState = FormWindowState.Normal;
			bExitMaximizeButton.Visible = false;
			bMaximizeButton.Visible = true;

			timebarvalue = GetTimeBarValue();

			base.OnResizeBegin(e);
		}

		// Event when window is resizing
		protected override void OnResize(EventArgs e)
		{
			#region Update locations
			// Position timebar and volume bar location
			pTimeBarProgress.Location = TimeBar_BG.Location;
			pTimeBarProgress.Size = new Size((int)((float)TimeBar_BG.Width * (float)((float)timebarvalue / (float)100f)), pTimeBarProgress.Height);
			pVolumeBarVolume.Location = VolumeBar_BG.Location;
			lSongTimePassed.Location = new Point(TimeBar_BG.X - lSongTimePassed.Width - TimeIndicatorsOffset, TimeBar_BG.Y + (TimeBar_BG.Height / 2) - (lSongTimePassed.Height / 2));
			lSongTotalTime.Location = new Point(TimeBar_BG.X + TimeBar_BG.Width + TimeIndicatorsOffset, TimeBar_BG.Y + (TimeBar_BG.Height / 2) - (lSongTotalTime.Height / 2));
			pbVolumeSpeaker.Location = new Point(VolumeBar_BG.X - pbVolumeSpeaker.Width - VolumeSpeakerOffset, VolumeBar_BG.Y + (VolumeBar_BG.Height / 2) - (pbVolumeSpeaker.Height / 2));

			// Update title location, to keep it in the center
			lTopBarTitle.Location = new Point(this.ClientSize.Width / 2 - lTopBarTitle.Width / 2, TitleOffset);

			// Position the exit button
			bExitButton.Location = new Point(this.ClientSize.Width - bExitButton.Width - ControlButtonsOffset, ControlButtonsOffset);

			// Position the maximize and exit maximize button
			bExitMaximizeButton.Location = bMaximizeButton.Location = new Point(this.ClientSize.Width - bExitButton.Width - ControlButtonsOffset - bExitButton.Width, ControlButtonsOffset);

			// Position the minimize button to fit the top bar
			bMinimizeButton.Location = new Point(this.ClientSize.Width - bExitButton.Width - bMaximizeButton.Width - ControlButtonsOffset - bMinimizeButton.Width, ControlButtonsOffset);

			// Position the play button
			bPlayPauseButton.Location = new Point(this.ClientSize.Width / 2 - bPlayPauseButton.Width / 2, this.ClientSize.Height - MusicControlSize + PlayPauseTopOffset - (PlayPauseResize / 2));
			bPlayPauseButtonUnhovered.Location = new Point(this.ClientSize.Width / 2 - bPlayPauseButtonUnhovered.Width / 2, this.ClientSize.Height - MusicControlSize + PlayPauseTopOffset);

			// Position the skip button
			bSkipButton.Location = new Point(bPlayPauseButton.Location.X + bPlayPauseButton.Width + SkipBackOffset - (SkipBackResize / 2), bPlayPauseButton.Location.Y + ((bPlayPauseButton.Height - bSkipButton.Height) / 2));
			bSkipButtonUnhovered.Location = new Point(bPlayPauseButton.Location.X + bPlayPauseButton.Width + SkipBackOffset, bPlayPauseButton.Location.Y + ((bPlayPauseButton.Height - bSkipButtonUnhovered.Height) / 2));

			// Position the back button
			bBackButton.Location = new Point(bPlayPauseButton.Location.X - bBackButton.Width - SkipBackOffset + (SkipBackResize / 2), bPlayPauseButton.Location.Y + ((bPlayPauseButton.Height - bBackButton.Height) / 2));
			bBackButtonUnhovered.Location = new Point(bPlayPauseButton.Location.X - bBackButtonUnhovered.Width - SkipBackOffset, bPlayPauseButton.Location.Y + ((bPlayPauseButton.Height - bBackButtonUnhovered.Height) / 2));

			// Position the shuffle button
			bShuffleButton.Location = new Point(bBackButton.Location.X - bShuffleButton.Width - ShuffleRepeatOffset + (ShuffleRepeatResize / 2), bPlayPauseButton.Location.Y + ((bPlayPauseButton.Height - bShuffleButton.Height) / 2));
			bShuffleButtonUnhovered.Location = new Point(bBackButton.Location.X - bShuffleButtonUnhovered.Width - ShuffleRepeatOffset, bPlayPauseButton.Location.Y + ((bPlayPauseButton.Height - bShuffleButtonUnhovered.Height) / 2));

			// Position the unenabled repeat button
			bRepeatButton.Location = new Point(bSkipButton.Location.X + bSkipButton.Width + ShuffleRepeatOffset - (ShuffleRepeatResize / 2), bPlayPauseButton.Location.Y + ((bPlayPauseButton.Height - bRepeatButton.Height) / 2));
			bRepeatButtonUnhovered.Location = new Point(bSkipButton.Location.X + bSkipButton.Width + ShuffleRepeatOffset, bPlayPauseButton.Location.Y + ((bPlayPauseButton.Height - bRepeatButtonUnhovered.Height) / 2));

			// Position the cover image
			pbSongCover.Location = new Point(MusicControl.X + ((MusicControl.Height - (MusicControl.Height / 100 * CoverPercentage)) / 2), MusicControl.Y + ((MusicControl.Height - (MusicControl.Height / 100 * CoverPercentage)) / 2));

			// Position the song title and artist labels
			lSongTitle.Location = new Point(pbSongCover.Location.X + pbSongCover.Width + SongInfoOffset, pbSongCover.Location.Y + (pbSongCover.Height / 2) - ((lSongTitle.Height + lSongArtist.Height) / 2));
			lSongArtist.Location = new Point(pbSongCover.Location.X + pbSongCover.Width + SongInfoOffset, pbSongCover.Location.Y + (pbSongCover.Height / 2) + (lSongTitle.Height - ((lSongTitle.Height + lSongArtist.Height) / 2)));
			SongInfoHide.Location = new Point(lSongTimePassed.Location.X, pbSongCover.Location.Y + (pbSongCover.Height / 2) - (SongInfoHide.Height / 2));
			#endregion
			CutSongInfo();
			base.OnResize(e);
		}
		#endregion

		#region Events
		#region Hover events
		// Mouse enters the play button
		private void PlayMouseEnter(object sender, EventArgs e)
		{
			bPlayPauseButtonUnhovered.Visible = false;
			bPlayPauseButton.Visible = true;
		}

		// Mouse leaves the play button
		private void PlayMouseLeave(object sender, EventArgs e)
		{
			bPlayPauseButton.Visible = false;
			bPlayPauseButtonUnhovered.Visible = true;
		}

		// Mouse enters skip button
		private void SkipMouseEnter(object sender, EventArgs e)
		{
			bSkipButtonUnhovered.Visible = false;
			bSkipButton.Visible = true;
		}

		// Mouse leaves skip button
		private void SkipMouseLeave(object sender, EventArgs e)
		{
			bSkipButton.Visible = false;
			bSkipButtonUnhovered.Visible = true;
		}

		// Mouse enters back button
		private void BackMouseEnter(object sender, EventArgs e)
		{
			bBackButtonUnhovered.Visible = false;
			bBackButton.Visible = true;
		}

		// Mouse leaves back button
		private void BackMouseLeave(object sender, EventArgs e)
		{
			bBackButton.Visible = false;
			bBackButtonUnhovered.Visible = true;
		}

		// Mouse enters the unenabled shuffle button
		private void ShuffleMouseEnter(object sender, EventArgs e)
		{
			bShuffleButtonUnhovered.Visible = false;
			bShuffleButton.Visible = true;
		}

		// Mouse leaves the unenabled shuffle button
		private void ShuffleMouseLeave(object sender, EventArgs e)
		{
			bShuffleButton.Visible = false;
			bShuffleButtonUnhovered.Visible = true;
		}

		// Mouse enters the unenabled repeat button
		private void RepeatMouseEnter(object sender, EventArgs e)
		{
			bRepeatButtonUnhovered.Visible = false;
			bRepeatButton.Visible = true;
		}

		// Mouse leaves the unenabled repeat button
		private void RepeatMouseLeave(object sender, EventArgs e)
		{
			bRepeatButton.Visible = false;
			bRepeatButtonUnhovered.Visible = true;
			//RepeatButtonUnhovered.BringToFront();
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
					PlaybackSettings.edittingTime = true;

				if (PlaybackSettings.volumeSelected)
					PlaybackSettings.edittingVolume = true;
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
					OnTimeBarValueChanged?.Invoke(GetTimeBarValue());
				}

				if (PlaybackSettings.edittingVolume)
				{
					PlaybackSettings.edittingVolume = false;
					OnVolumeBarValueChanged?.Invoke(GetVolumeBarValue());
				}
			}
		}

		// Mouse enters slider
		private void SliderHandleMouseEnter(object sender, EventArgs e)
		{
			
		}

		// Mouse exits slider
		private void SliderHandleMouseLeave(object sender, EventArgs e)
		{
			if (PlaybackSettings.edittingTime || PlaybackSettings.edittingVolume)
			{
				checkUpSlider = true;
			}
		}

		// Slider drag
		private void SliderHandleMouseMove(object sender, MouseEventArgs e)
		{
			if (PlaybackSettings.edittingTime)
			{
				pSliderHandle.Location = new Point((int)Clamp(pSliderHandle.Location.X + e.Location.X - (pSliderHandle.Width / 2), TimeBar_BG.X - (pSliderHandle.Width / 2), TimeBar_BG.X + TimeBar_BG.Width - (pSliderHandle.Width / 2)), pSliderHandle.Location.Y);
				pTimeBarProgress.Size = new Size((pSliderHandle.Location.X + (pSliderHandle.Width / 2)) - TimeBar_BG.X, pTimeBarProgress.Height);
			}

			if (PlaybackSettings.edittingVolume)
			{
				pSliderHandle.Location = new Point((int)Clamp(pSliderHandle.Location.X + e.Location.X - (pSliderHandle.Width / 2), VolumeBar_BG.X - (pSliderHandle.Width / 2), VolumeBar_BG.X + VolumeBar_BG.Width - (pSliderHandle.Width / 2)), pSliderHandle.Location.Y);
				pVolumeBarVolume.Size = new Size((pSliderHandle.Location.X + (pSliderHandle.Width / 2)) - VolumeBar_BG.X, pVolumeBarVolume.Height);
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
				OnTimeBarValueChanged?.Invoke(GetTimeBarValue());
			}

			if (checkUpSlider && PlaybackSettings.edittingVolume)
			{
				PlaybackSettings.edittingVolume = false;
				checkUpSlider = false;
				OnVolumeBarValueChanged?.Invoke(GetVolumeBarValue());
			}
		}

		// Mouse move event
		private void FormMouseMove(object sender, MouseEventArgs e)
		{
			if (PlaybackSettings.edittingTime)
			{
				pSliderHandle.Location = new Point((int)Clamp(e.Location.X - (pSliderHandle.Width / 2), TimeBar_BG.X - (pSliderHandle.Width / 2), TimeBar_BG.X + TimeBar_BG.Width - (pSliderHandle.Width / 2)), pSliderHandle.Location.Y);
				pTimeBarProgress.Size = new Size((pSliderHandle.Location.X + (pSliderHandle.Width / 2)) - TimeBar_BG.X, pTimeBarProgress.Height);
			}

			if (PlaybackSettings.edittingVolume)
			{
				pSliderHandle.Location = new Point((int)Clamp(e.Location.X - (pSliderHandle.Width / 2), VolumeBar_BG.X - (pSliderHandle.Width / 2), VolumeBar_BG.X + VolumeBar_BG.Width - (pSliderHandle.Width / 2)), pSliderHandle.Location.Y);
				pVolumeBarVolume.Size = new Size((pSliderHandle.Location.X + (pSliderHandle.Width / 2)) - VolumeBar_BG.X, pVolumeBarVolume.Height);
			}
		}

		// Mouse click event
		private void FormMouseDown(object sender, MouseEventArgs e)
		{
			if (PlaybackSettings.timeSelected)
			{
				checkUpSlider = true;
				PlaybackSettings.edittingTime = true;
				pSliderHandle.Location = new Point((int)Clamp(e.Location.X - (pSliderHandle.Width / 2), TimeBar_BG.X - (pSliderHandle.Width / 2), TimeBar_BG.X + TimeBar_BG.Width - (pSliderHandle.Width / 2)), pSliderHandle.Location.Y);
				pTimeBarProgress.Size = new Size((pSliderHandle.Location.X + (pSliderHandle.Width / 2)) - TimeBar_BG.X, pTimeBarProgress.Height);
			}

			if (PlaybackSettings.volumeSelected)
			{
				checkUpSlider = true;
				PlaybackSettings.edittingVolume = true;
				pSliderHandle.Location = new Point((int)Clamp(e.Location.X - (pSliderHandle.Width / 2), VolumeBar_BG.X - (pSliderHandle.Width / 2), VolumeBar_BG.X + VolumeBar_BG.Width - (pSliderHandle.Width / 2)), pSliderHandle.Location.Y);
				pVolumeBarVolume.Size = new Size((pSliderHandle.Location.X + (pSliderHandle.Width / 2)) - VolumeBar_BG.X, pVolumeBarVolume.Height);
			}
		}
		#endregion

		#endregion

		#region Buttons
		#region ControlButtons
		// Button to quit the application
		private void ExitButton_Click(object sender, EventArgs e)
		{
			this.Close();
			//Application.Exit();
		}

		// Button to maximize the application
		private void MaximizeButton_Click(object sender, EventArgs e)
		{
			Rectangle rect = Screen.FromHandle(this.Handle).WorkingArea;
			rect.Location = new Point(0, 0);
			this.MaximizedBounds = rect;
			this.WindowState = FormWindowState.Maximized;
			bMaximizeButton.Visible = false;
			bExitMaximizeButton.Visible = true;
		}

		// Button to return from maximized view of application
		private void ExitMaximizeButton_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Normal;
			bExitMaximizeButton.Visible = false;
			bMaximizeButton.Visible = true;
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
			if (pe.GetCurrentTime().TotalSeconds < backTime)
			{
				Console.WriteLine("Back");
			}else
			{
				pe.GotoPercentage(0f);
			}
		}

		// Press on the play button
		private void PlayPauseButton_Click(object sender, EventArgs e)
		{
			if (PlaybackSettings.isPaused)
			{
				PlaybackSettings.isPaused = false;
				bPlayPauseButton.BackgroundImage = ResourceLoader.loadImage(rPauseButton);
				bPlayPauseButtonUnhovered.BackgroundImage = ResourceLoader.loadImage(rPauseButton);
			}else
			{
				PlaybackSettings.isPaused = true;
				bPlayPauseButton.BackgroundImage = ResourceLoader.loadImage(rPlayButton);
				bPlayPauseButtonUnhovered.BackgroundImage = ResourceLoader.loadImage(rPlayButton);
			}

			pe.PauseStream();
		}

		// Press on the unenabled shuffle button
		private void ShuffleButton_Click(object sender, EventArgs e)
		{
			if (PlaybackSettings.shuffle)
			{
				PlaybackSettings.shuffle = false;
				bShuffleButton.BackgroundImage = ResourceLoader.loadImage(rShuffleButtonDisabled);
				bShuffleButtonUnhovered.BackgroundImage = ResourceLoader.loadImage(rShuffleButtonDisabled);
			}
			else
			{
				PlaybackSettings.shuffle = true;
				bShuffleButton.BackgroundImage = ResourceLoader.loadImage(rShuffleButtonEnabled);
				bShuffleButtonUnhovered.BackgroundImage = ResourceLoader.loadImage(rShuffleButtonEnabled);
			}
		}

        // Press on the unenabled repeat button
        private void RepeatButton_Click(object sender, EventArgs e)
		{
			switch (PlaybackSettings.repeatState)
			{
				case PlaybackSettings.RepeatState.NONE:
					PlaybackSettings.repeatState = PlaybackSettings.RepeatState.REPEAT_ALL;
					bRepeatButton.BackgroundImage = ResourceLoader.loadImage(rRepeatButtonEnabled);
					bRepeatButtonUnhovered.BackgroundImage = ResourceLoader.loadImage(rRepeatButtonEnabled);
					break;
				case PlaybackSettings.RepeatState.REPEAT_ALL:
					PlaybackSettings.repeatState = PlaybackSettings.RepeatState.REPEAT_ONE;
					bRepeatButton.BackgroundImage = ResourceLoader.loadImage(rRepeatButtonOneEnabled);
					bRepeatButtonUnhovered.BackgroundImage = ResourceLoader.loadImage(rRepeatButtonOneEnabled);
					break;
				case PlaybackSettings.RepeatState.REPEAT_ONE:
					PlaybackSettings.repeatState = PlaybackSettings.RepeatState.NONE;
					bRepeatButton.BackgroundImage = ResourceLoader.loadImage(rRepeatButtonDisabled);
					bRepeatButtonUnhovered.BackgroundImage = ResourceLoader.loadImage(rRepeatButtonDisabled);
					break;
			}
		}
		#endregion

		bool differentSong = false;

		private void button2_Click(object sender, EventArgs e)
		{
			if (!differentSong)
				pe.StartNewSong("C:\\Users\\Abel\\Music\\Hardstyle\\Coone & Wildstylez - Here I Come.mp3");
			else
				pe.StartNewSong("music/dj_paul_elstak/demons");

			differentSong = !differentSong;
		}

		// Upload button
		private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.Show();
        }
		#endregion

		#region Custom functions
		private void onFormShow(object o, EventArgs e)
		{
			FileManager fm = new FileManager();
			PlaybackSettings.cache = fm.DeserializeFile<PlaybackCache>(Application.StartupPath + "/saves/playbackcache.save");

			if (PlaybackSettings.cache != null)
			{
				SetVolumePercentage(PlaybackSettings.cache.volume * 100f);
				loadNewSongInfo(PlaybackSettings.cache.songCache.info, PlaybackSettings.cache.songCache.cover, false);

				Console.WriteLine(PlaybackSettings.cache.timebarPercentage);

				if (!string.IsNullOrEmpty(PlaybackSettings.cache.songCache.localPath))
					pe.StartNewSong(PlaybackSettings.cache.songCache.localPath, PlaybackSettings.cache.timebarPercentage, true);
				else
					pe.StartNewSong(PlaybackSettings.cache.songCache.webDavPath, PlaybackSettings.cache.timebarPercentage, true);
			}
			else
			{
				PlaybackSettings.cache = new PlaybackCache();
			}
		}

		private void onFormClosing(object o, EventArgs e)
		{
			StopTitleCarousel();
			StopArtistsCarousel();
			pe.StopStream();
		}

		private void onFormClosed(object o, EventArgs e)
		{
			PlaybackSettings.cache.timebarPercentage = GetTimeBarValue();
			FileManager fm = new FileManager();
			fm.SerializeFile(PlaybackSettings.cache, Application.StartupPath + "/saves", "playbackcache.save");
		}

		// Update the timebar
		private void updateTimebar(TimeSpan time)
		{
			string seconds = time.Seconds.ToString();
			if (seconds.Length == 1)
				seconds = "0" + seconds;
			lSongTimePassed?.Invoke((MethodInvoker)(() => 
			{
				lSongTimePassed.Text = time.Minutes + ":" + seconds;
			}));

			if (PlaybackSettings.edittingTime)
				return;

			string[] parts = lSongTotalTime.Text.Split(':');
			int minutes = Convert.ToInt32(parts[0]);
			int sec = Convert.ToInt32(parts[1]);
			int totalseconds = (minutes * 60 * 1000) + (sec * 1000);
			SetTimeBarProcessPercentage(((float)time.TotalMilliseconds / (float)totalseconds) * (float)100f);
		}

		// Update all information
		private void loadNewSongInfo(SongInfo info, Image cover, bool unpause)
		{
			StopTitleCarousel();
			StopArtistsCarousel();

			SetSongInfo(ConvertTitle(info.title), ConvertArtists(info.artists));
			CutSongInfo();

			pbSongCover.Image = cover;

			string seconds = info.duration.Seconds.ToString();
			if (seconds.Length == 1)
				seconds = "0" + seconds;

			lSongTotalTime.Text = info.duration.Minutes + ":" + seconds;

			if (unpause)
			{
				PlaybackSettings.isPaused = false;
				bPlayPauseButton.BackgroundImage = ResourceLoader.loadImage(rPauseButton);
				bPlayPauseButtonUnhovered.BackgroundImage = ResourceLoader.loadImage(rPauseButton);
			}

			SetSongInfo(ConvertTitle(info.title), ConvertArtists(info.artists));
			CutSongInfo();
		}

		private void onStreamPause()
		{
			PlaybackSettings.isPaused = true;
			bPlayPauseButton.BackgroundImage = ResourceLoader.loadImage(rPlayButton);
			bPlayPauseButtonUnhovered.BackgroundImage = ResourceLoader.loadImage(rPlayButton);
		}

		private string ConvertArtists(string input)
		{
			string[] parts = input.Split(',');
			if (parts.Length == 1) return ConvertTitle(input);
			string returnstring = ConvertTitle(parts[0]);
			for (int i = 1; i < parts.Length; i++)
			{
				returnstring += "," + ConvertTitle(parts[i]);
			}
			return returnstring;
		}

		private string ConvertTitle(string input)
		{
			string[] parts = input.Split(' ');
			if (parts.Length == 1) return Capitalize(input);
			string returnstring = Capitalize(parts[0]);
			for (int i = 1; i < parts.Length; i++)
			{
				returnstring += " " + Capitalize(parts[i]);
			}
			return returnstring;
		}

		private string Capitalize(string input)
		{
			if (string.IsNullOrEmpty(input)) return null;
			if (input.Length == 1) return input.ToUpper();
			return input[0].ToString().ToUpper() + input.Substring(1);
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
			return (float)pTimeBarProgress.Width / (float)TimeBar_BG.Width * (float)100f;
		}

		private void SetTimeBarProcessPercentage(float percentage)
		{
			pTimeBarProgress?.Invoke((MethodInvoker)(() =>
			{
				pTimeBarProgress.Size = new Size((int)((float)TimeBar_BG.Width * (float)((float)percentage / (float)100f)), pTimeBarProgress.Height);
				if (PlaybackSettings.timeSelected)
					pSliderHandle.Location = new Point(pTimeBarProgress.Location.X + pTimeBarProgress.Width - (pSliderHandle.Width / 2), pTimeBarProgress.Location.Y - (pSliderHandle.Height / 2) + (pTimeBarProgress.Height / 2));
			}));
			//OnTimeBarValueChanged?.Invoke(percentage);
		}

		private float GetVolumeBarValue()
		{
			return (float)pVolumeBarVolume.Width / (float)VolumeBar_BG.Width;
		}

		private void SetVolumePercentage(float percentage)
		{
			pVolumeBarVolume?.Invoke((MethodInvoker)(() =>
			{
				pVolumeBarVolume.Size = new Size((int)((float)VolumeBar_BG.Width * (float)((float)percentage / (float)100f)), pVolumeBarVolume.Height);
				if (PlaybackSettings.volumeSelected)
					pSliderHandle.Location = new Point(pVolumeBarVolume.Location.X + pVolumeBarVolume.Width - (pSliderHandle.Width / 2), pVolumeBarVolume.Location.Y - (pSliderHandle.Height / 2) + (pVolumeBarVolume.Height / 2));
			}));
			OnVolumeBarValueChanged?.Invoke(percentage / 100f);
		}

		private void SetSongInfo(string title, string artists)
		{
			lSongTitle.Text = title;
			lSongArtist.Text = artists;
			PlaybackSettings.title = title;
			PlaybackSettings.artists = artists;
		}

		bool stoptitlecarousel = false;
		bool runningtitlecarousel = false;

		private void StartTitleCarousel(object sender = null, EventArgs e = null)
		{
			if (lSongTitle.Location.X + CalculateStringSize(PlaybackSettings.title, lSongTitle.Font, 0).Width <= SongInfoHide.Location.X || runningtitlecarousel)
				return;

			runningtitlecarousel = true;
			new Thread(() =>
			{
				string carouselstring = PlaybackSettings.title + songInfoCarouselSpace;
				string startstring = lSongTitle.Text;
				int index = startstring.Length;
				foreach (char c in carouselstring)
				{
					if (stoptitlecarousel)
						break;

					lSongTitle?.Invoke((MethodInvoker)(() =>
					{
						if (!stoptitlecarousel)
							lSongTitle.Text = lSongTitle.Text.Substring(1) + carouselstring[index].ToString();
					}));
					index++;
					if (index >= carouselstring.Length)
						index = 0;

					Thread.Sleep(songInfoCarouselSpeed);
					if (stoptitlecarousel)
						break;
				}
				stoptitlecarousel = false;
				runningtitlecarousel = false;
			}).Start();
		}

		private void StopTitleCarousel()
		{
			if (runningtitlecarousel)
				stoptitlecarousel = true;
			else
				stoptitlecarousel = false;
		}

		bool stopartistscarousel = false;
		bool runningartistscarousel = false;

		private void StartArtistsCarousel(object sender = null, EventArgs e = null)
		{
			if (lSongArtist.Location.X + CalculateStringSize(PlaybackSettings.artists, lSongArtist.Font, 0).Width <= SongInfoHide.Location.X || runningartistscarousel)
				return;

			runningartistscarousel = true;
			new Thread(() =>
			{
				string carouselstring = PlaybackSettings.artists + songInfoCarouselSpace;
				string startstring = lSongArtist.Text;
				int index = startstring.Length;
				foreach (char c in carouselstring)
				{
					if (stopartistscarousel)
						break;

					lSongArtist?.Invoke((MethodInvoker)(() =>
					{
						if (!stopartistscarousel)
							lSongArtist.Text = lSongArtist.Text.Substring(1) + carouselstring[index].ToString();
					}));
					index++;
					if (index >= carouselstring.Length)
						index = 0;

					Thread.Sleep(songInfoCarouselSpeed);
					if (stopartistscarousel)
						break;
				}
				stopartistscarousel = false;
				runningartistscarousel = false;
			}).Start();
		}

		private void StopArtistsCarousel()
		{
			if (runningartistscarousel)
				stopartistscarousel = true;
			else
				stopartistscarousel = false;
		}

		private void CutSongInfo()
		{
			StopTitleCarousel();
			StopArtistsCarousel();

			if (lSongTitle.Location.X + CalculateStringSize(PlaybackSettings.title, lSongTitle.Font, 0).Width > SongInfoHide.Location.X)
			{
				for (int i = 0; i < PlaybackSettings.title.Length; i++)
				{
					if (lSongTitle.Location.X + CalculateStringSize(PlaybackSettings.title.Substring(0, i), lSongTitle.Font, 0).Width > SongInfoHide.Location.X)
					{
						lSongTitle.Text = PlaybackSettings.title.Substring(0, i);
						break;
					}
				}
			}else
			{
				lSongTitle.Text = PlaybackSettings.title;
			}

			if (lSongArtist.Location.X + CalculateStringSize(PlaybackSettings.artists, lSongArtist.Font, 0).Width > SongInfoHide.Location.X)
			{
				for (int i = 0; i < PlaybackSettings.artists.Length; i++)
				{
					if (lSongArtist.Location.X + CalculateStringSize(PlaybackSettings.artists.Substring(0, i), lSongArtist.Font, 0).Width > SongInfoHide.Location.X)
					{
						lSongArtist.Text = PlaybackSettings.artists.Substring(0, i);
						break;
					}
				}
			}else
			{
				lSongArtist.Text = PlaybackSettings.artists;
			}
		}

		private Size CalculateStringSize(string input, Font font, int offset)
		{
			return TextRenderer.MeasureText(input, font) - new Size(offset, 0);
		}

	#endregion
}
}
