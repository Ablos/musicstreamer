/*
 * (c) Abel Dieterich - HotkeyCode Inc.
 */

using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

namespace Windows
{
	public partial class Login : Form
	{
		public const int WM_NCLBUTTONDOWN = 0xA1;
		public const int HT_CAPTION = 0x2;

		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		public Login()
		{
			InitializeComponent();
			this.FormBorderStyle = FormBorderStyle.None;
			this.DoubleBuffered = true;
			this.SetStyle(ControlStyles.ResizeRedraw, true);
			this.BackgroundImage = ResourceLoader.loadImage(rWindowBackground);
			this.MaximumSize = new Size(400, 500);
			this.MinimumSize = new Size(400, 500);
			this.StartPosition = FormStartPosition.CenterScreen;
			this.MouseClick += new MouseEventHandler(OnFormMouseClick);

			#region Instantiate top bar contents
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
			bMinimizeButton.Location = new Point(this.ClientSize.Width - bExitButton.Width - ControlButtonsOffset - bMinimizeButton.Width, ControlButtonsOffset);
			bMinimizeButton.Click += new EventHandler(MinimizeButton_Click);
			Controls.Add(bMinimizeButton);
			#endregion

			#region Instantiate pictures
			pbLogoBanner.Image = ResourceLoader.loadImage(rLogoBanner);
			pbLogoBanner.BackColor = Color.Transparent;
			pbLogoBanner.SizeMode = PictureBoxSizeMode.StretchImage;
			pbLogoBanner.Size = new Size(150, 50);
			pbLogoBanner.Location = new Point(this.Width / 2 - pbLogoBanner.Width / 2, 30);
			Controls.Add(pbLogoBanner);
			#endregion

			#region Instantiate text boxes
			tbLoginBox.BackColor = cTextBox;
			tbLoginBox.BorderStyle = BorderStyle.None;
			tbLoginBox.Font = new Font("Roboto", 10f, FontStyle.Regular);
			tbLoginBox.ForeColor = cInactiveText;
			tbLoginBox.Text = loginPlaceholder;
			tbLoginBox.Size = new Size(300, 15);
			tbLoginBox.Location = new Point(this.Width / 2 - tbLoginBox.Width / 2, pbLogoBanner.Location.Y + pbLogoBanner.Height + 60);
			tbLoginBox.Enter += new EventHandler(OnLoginEnter);
			tbLoginBox.Leave += new EventHandler(OnLoginLeave);
			tbLoginBox.KeyPress += new KeyPressEventHandler(OnLoginKeyPress);
			Controls.Add(tbLoginBox);
			LoginTextBoxBackground = new Rectangle(new Point(tbLoginBox.Location.X - TextBoxBorderSize, tbLoginBox.Location.Y - TextBoxBorderSize), new Size(tbLoginBox.Width + (2 * TextBoxBorderSize), tbLoginBox.Height + (2 * TextBoxBorderSize)));

			tbPasswordBox.BackColor = cTextBox;
			tbPasswordBox.BorderStyle = BorderStyle.None;
			tbPasswordBox.Font = new Font("Roboto", 10f, FontStyle.Regular);
			tbPasswordBox.ForeColor = cInactiveText;
			tbPasswordBox.Text = passwordPlaceholder;
			tbPasswordBox.Size = new Size(300, 15);
			tbPasswordBox.Location = new Point(this.Width / 2 - tbLoginBox.Width / 2, tbLoginBox.Location.Y + tbLoginBox.Height + 25);
			tbPasswordBox.Enter += new EventHandler(OnPasswordEnter);
			tbPasswordBox.Leave += new EventHandler(OnPasswordLeave);
			tbPasswordBox.KeyPress += new KeyPressEventHandler(OnPasswordKeyPress);
			Controls.Add(tbPasswordBox);
			PasswordTextBoxBackground = new Rectangle(new Point(tbPasswordBox.Location.X - TextBoxBorderSize, tbPasswordBox.Location.Y - TextBoxBorderSize), new Size(tbPasswordBox.Width + (2 * TextBoxBorderSize), tbPasswordBox.Height + (2 * TextBoxBorderSize)));
			#endregion
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

		#region Colors
		Color cTextBox = Color.FromArgb(55, 55, 55);

		Color cInactiveText = Color.FromArgb(168, 168, 168);
		#endregion

		#region Resource name constants
		const string rWindowBackground = "window-background";

		const string rExitButton = "topbar-exit";
		const string rMaximizeButton = "topbar-maximize";
		const string rExitMaximizeButton = "topbar-exit-maximize";
		const string rMinimizeButton = "topbar-minimize";

		const string rLogoBanner = "logo-banner";

		const string loginPlaceholder = "Email or Username";
		const string passwordPlaceholder = "Password ";
		#endregion

		#region Sizes and offsets
		const int TopSize = 20;                         // Size of the top bar

		const int ControlButtonsOffset = 2;             // Offset of controlbuttons
		const int ControlButtonsResize = 4;             // How much pixels the control buttons should be smaller

		const int TextBoxBorderSize = 5;				// How much pixels should the border of the text boxes be
		#endregion

		#region Control Rectangles
		Rectangle TopBar { get { return new Rectangle(0, 0, this.ClientSize.Width, TopSize); } }
		Rectangle LoginTextBoxBackground = new Rectangle();
		Rectangle PasswordTextBoxBackground = new Rectangle();
		#endregion

		#region Colors
		Color cTopBar = Color.FromArgb(22, 22, 22);
		#endregion

		#region Controls
		// Buttons
		Button bExitButton = new Button();
		Button bMaximizeButton = new Button();
		Button bExitMaximizeButton = new Button();
		Button bMinimizeButton = new Button();

		// Picuture box
		PictureBox pbLogoBanner = new PictureBox();

		// Input fields
		TextBox tbLoginBox = new TextBox();
		TextBox tbPasswordBox = new TextBox();
		#endregion

		#region Forms functions
		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.FillRectangle(new SolidBrush(cTextBox), LoginTextBoxBackground);
			e.Graphics.FillRectangle(new SolidBrush(cTextBox), PasswordTextBoxBackground);

			base.OnPaint(e);
		}

		protected override void WndProc(ref Message message)
		{
			base.WndProc(ref message);

			// Process controls
			if (message.Msg == 0x84)
			{
				Point cursor = this.PointToClient(Cursor.Position);

				#region Resize check
				if (TopBar.Contains(cursor)) message.Result = (IntPtr)HTTOPBARMOVE;
				#endregion
			}
		}

		// Event when window is resizing
		protected override void OnResize(EventArgs e)
		{
			#region Update locations
			// Position the exit button
			bExitButton.Location = new Point(this.ClientSize.Width - bExitButton.Width - ControlButtonsOffset, ControlButtonsOffset);

			// Position the maximize and exit maximize button
			bMinimizeButton.Location = new Point(this.ClientSize.Width - bExitButton.Width - ControlButtonsOffset - bExitButton.Width, ControlButtonsOffset);
			#endregion
			base.OnResize(e);
		}
		#endregion

		#region Buttons
		#region ControlButtons
		// Button to quit the application
		private void ExitButton_Click(object sender, EventArgs e)
		{
			this.Close();
			//Application.Exit();
		}

		// Button to minimize the application
		private void MinimizeButton_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}
		#endregion
		#endregion

		#region Events

		private void OnLoginEnter(object sender, EventArgs e)
		{
			if (tbLoginBox.Text == loginPlaceholder)
			{
				tbLoginBox.Text = "";
				tbLoginBox.ForeColor = Color.White;
			}
		}

		private void OnLoginLeave(object sender, EventArgs e)
		{
			if (tbLoginBox.Text == "")
			{
				tbLoginBox.ForeColor = cInactiveText;
				tbLoginBox.Text = loginPlaceholder;
			}
		}

		private void OnPasswordEnter(object sender, EventArgs e)
		{
			if (tbPasswordBox.Text == passwordPlaceholder)
			{
				tbPasswordBox.Text = "";
				tbPasswordBox.ForeColor = Color.White;
				tbPasswordBox.UseSystemPasswordChar = true;
			}
		}

		private void OnPasswordLeave(object sender, EventArgs e)
		{
			if (tbPasswordBox.Text == "")
			{
				tbPasswordBox.ForeColor = cInactiveText;
				tbPasswordBox.UseSystemPasswordChar = false;
				tbPasswordBox.Text = passwordPlaceholder;
			}
		}

		private void OnLoginKeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString() == " ")
				e.Handled = true;
		}

		private void OnPasswordKeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString() == " ")
				e.Handled = true;
		}

		private void OnFormMouseClick(object sender, EventArgs e)
		{
			tbPasswordBox.UseSystemPasswordChar = false;
			this.ActiveControl = null;
		}

		#endregion

		#region Custom functions
		// Move the window
		private void Mover(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
			}
		}
		#endregion
	}
}
