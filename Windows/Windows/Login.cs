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
			this.Shown += new EventHandler(onFormShow);

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

			#region Instantate remember me
			// Instantiate remember me label
			lRememberMe.AutoSize = true;
			lRememberMe.BackColor = Color.Transparent;
			lRememberMe.Font = new Font("Roboto", 9f, FontStyle.Regular);
			lRememberMe.ForeColor = cRememberMe;
			lRememberMe.Text = "Remember me";
			lRememberMe.Location = new Point(tbPasswordBox.Location.X, tbPasswordBox.Location.Y + tbPasswordBox.Height + 15);
			lRememberMe.TextAlign = ContentAlignment.MiddleLeft;
			Controls.Add(lRememberMe);

			// Instantiate remember me checkbox
			cbRememberMe.Appearance = Appearance.Button;
			cbRememberMe.BackgroundImage = ResourceLoader.loadImage(rUncheckedCheckbox);
			cbRememberMe.BackgroundImageLayout = ImageLayout.Stretch;
			cbRememberMe.BackColor = Color.Transparent;
			cbRememberMe.FlatStyle = FlatStyle.Flat;
			cbRememberMe.FlatAppearance.BorderSize = 0;
			cbRememberMe.FlatAppearance.MouseDownBackColor = Color.Transparent;
			cbRememberMe.FlatAppearance.MouseOverBackColor = Color.Transparent;
			cbRememberMe.FlatAppearance.CheckedBackColor = Color.Transparent;
			cbRememberMe.Text = "";
			cbRememberMe.TextImageRelation = TextImageRelation.ImageBeforeText;
			cbRememberMe.ImageIndex = 0;
			cbRememberMe.Size = new Size(lRememberMe.Height, lRememberMe.Height);
			cbRememberMe.Location = new Point(tbPasswordBox.Location.X + tbPasswordBox.Width - cbRememberMe.Width, lRememberMe.Location.Y);
			cbRememberMe.CheckedChanged += new EventHandler(OnRememberMeChanged);
			Controls.Add(cbRememberMe);
			#endregion

			#region Instantiate login button

			bLoginButton.BackColor = cUnhoveredButton;
			bLoginButton.FlatStyle = FlatStyle.Flat;
			bLoginButton.FlatAppearance.BorderSize = 0;
			bLoginButton.FlatAppearance.MouseOverBackColor = cHoveredButton;
			bLoginButton.FlatAppearance.MouseDownBackColor = cMouseDownButton;
			bLoginButton.ForeColor = Color.White;
			bLoginButton.Font = new Font("Roboto Light", 12f, FontStyle.Regular);
			bLoginButton.Text = "LOGIN";
			bLoginButton.TextAlign = ContentAlignment.MiddleCenter;
			bLoginButton.Size = new Size(250, 30);
			bLoginButton.Location = new Point(this.Width / 2 - bLoginButton.Width / 2, lRememberMe.Location.Y + lRememberMe.Height + 25);
			bLoginButton.MouseClick += new MouseEventHandler(OnLoginButtonClicked);
			Controls.Add(bLoginButton);

			#endregion

			#region Instantiate error label
			lErrorLabel.AutoSize = false;
			lErrorLabel.Size = new Size(300, 24);
			lErrorLabel.BackColor = cErrorBackground;
			lErrorLabel.Font = new Font("Roboto", 10f, FontStyle.Regular);
			lErrorLabel.ForeColor = Color.White;
			lErrorLabel.Location = new Point(this.Width / 2 - lErrorLabel.Width / 2, bLoginButton.Location.Y + bLoginButton.Height + 25);
			lErrorLabel.Text = "Please fill in both fields!";
			lErrorLabel.TextAlign = ContentAlignment.MiddleCenter;
			lErrorLabel.Visible = false;
			Controls.Add(lErrorLabel);

			lErrorFlag.AutoSize = true;
			lErrorFlag.BackColor = cErrorBackground;
			lErrorFlag.Font = new Font("Roboto", 15f, FontStyle.Regular);
			lErrorFlag.ForeColor = Color.White;
			lErrorFlag.Location = lErrorLabel.Location;
			lErrorFlag.Text = "⚑";
			lErrorFlag.Visible = false;
			Controls.Add(lErrorFlag);
			lErrorFlag.BringToFront();
			#endregion

			#region Instantiate bottombuttons

			// Instantiate signup button
			bSignupButton.BackColor = Color.Transparent;
			bSignupButton.FlatStyle = FlatStyle.Flat;
			bSignupButton.FlatAppearance.BorderSize = 0;
			bSignupButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
			bSignupButton.FlatAppearance.MouseOverBackColor = Color.Gray;
			bSignupButton.ForeColor = Color.White;
			bSignupButton.Font = new Font("Roboto Light", 10f, FontStyle.Regular);
			bSignupButton.Text = "SIGN UP";
			bSignupButton.TextAlign = ContentAlignment.MiddleCenter;
			bSignupButton.Size = new Size(150, 30);
			bSignupButton.Location = new Point(this.Width / 2 - bSignupButton.Width - 10, this.Height - bSignupButton.Height - 5);
			bSignupButton.MouseClick += new MouseEventHandler(OnSignupButtonClicked);
			Controls.Add(bSignupButton);

			// Instantiate reset password button
			bPasswordResetButton.BackColor = Color.Transparent;
			bPasswordResetButton.FlatStyle = FlatStyle.Flat;
			bPasswordResetButton.FlatAppearance.BorderSize = 0;
			bPasswordResetButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
			bPasswordResetButton.FlatAppearance.MouseOverBackColor = Color.Gray;
			bPasswordResetButton.ForeColor = Color.White;
			bPasswordResetButton.Font = new Font("Roboto Light", 10f, FontStyle.Regular);
			bPasswordResetButton.Text = "RESET PASSWORD";
			bPasswordResetButton.TextAlign = ContentAlignment.MiddleCenter;
			bPasswordResetButton.Size = new Size(150, 30);
			bPasswordResetButton.Location = new Point(this.Width / 2 + 10, this.Height - bPasswordResetButton.Height - 5);
			bPasswordResetButton.MouseClick += new MouseEventHandler(OnPasswordResetButtonClicked);
			Controls.Add(bPasswordResetButton);

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
		Color cRememberMe = Color.FromArgb(200, 200, 200);
		Color cInactiveText = Color.FromArgb(168, 168, 168);
		Color cUnhoveredButton = Color.FromArgb(237, 4, 4);
		Color cHoveredButton = Color.FromArgb(199, 5, 5);
		Color cMouseDownButton = Color.FromArgb(182, 6, 6);
		Color cErrorBackground = Color.FromArgb(179, 39, 39);
		Color cMessageBackground = Color.FromArgb(39, 179, 39);
		#endregion

		#region Resource name constants
		const string rWindowBackground = "window-background";

		const string rExitButton = "topbar-exit";
		const string rMaximizeButton = "topbar-maximize";
		const string rExitMaximizeButton = "topbar-exit-maximize";
		const string rMinimizeButton = "topbar-minimize";

		const string rLogoBanner = "logo-banner";

		const string rUncheckedCheckbox = "checkbox-unchecked";
		const string rCheckedCheckbox = "checkbox-checked";

		const string loginPlaceholder = "Email or Username";
		const string passwordPlaceholder = "Password ";
		const string loginURL = "http://ablos.square7.ch/accounts/login.php";
		const string emptyFieldError = "Please fill in both fields!";
		const string wrongCredentialsError = "Username or Password incorrect!";
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

		#region Controls
		// Buttons
		Button bExitButton = new Button();
		Button bMaximizeButton = new Button();
		Button bExitMaximizeButton = new Button();
		Button bMinimizeButton = new Button();

		Button bLoginButton = new Button();

		Button bSignupButton = new Button();
		Button bPasswordResetButton = new Button();

		// Picuture box
		PictureBox pbLogoBanner = new PictureBox();

		// Input fields
		TextBox tbLoginBox = new TextBox();
		TextBox tbPasswordBox = new TextBox();

		// Labels
		Label lRememberMe = new Label();
		Label lErrorLabel = new Label();
		Label lErrorFlag = new Label();

		// Checkboxes
		CheckBox cbRememberMe = new CheckBox();
		#endregion

		#region Variables
		LoginInfo loginInfo;
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

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			if (e.KeyCode == Keys.Return)
				OnLoginButtonClicked(null, null);
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
			DisableErrorMessage();

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
			}else
			{
				loginInfo.username = tbLoginBox.Text.ToLower();
			}
		}

		private void OnPasswordEnter(object sender, EventArgs e)
		{
			DisableErrorMessage();

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
			}else
			{
				loginInfo.password = tbPasswordBox.Text;
			}
		}

		private void OnLoginKeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString() == " ")
				e.Handled = true;
			if (e.KeyChar == (char)13)
			{
				this.ActiveControl = null;
				OnLoginButtonClicked(null, null);
			}
		}

		private void OnPasswordKeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString() == " ")
				e.Handled = true;
			if (e.KeyChar == (char)13)
			{
				this.ActiveControl = null;
				OnLoginButtonClicked(null, null);
			}
		}

		private void OnFormMouseClick(object sender, EventArgs e)
		{
			if (tbPasswordBox.Text == "")
			{
				tbPasswordBox.UseSystemPasswordChar = false;
			}
			this.ActiveControl = null;
		}

		private void OnRememberMeChanged(object sender, EventArgs e)
		{
			DisableErrorMessage();

			loginInfo.rememberme = cbRememberMe.Checked;

			if (cbRememberMe.Checked)
				cbRememberMe.BackgroundImage = ResourceLoader.loadImage(rCheckedCheckbox);
			else
				cbRememberMe.BackgroundImage = ResourceLoader.loadImage(rUncheckedCheckbox);

			this.ActiveControl = null;
		}

		private void OnLoginButtonClicked(object sender, MouseEventArgs e)
		{
			DisableErrorMessage();

			if (string.IsNullOrEmpty(loginInfo.username) || string.IsNullOrEmpty(loginInfo.password))
			{
				DisplayErrorMessage(emptyFieldError, cErrorBackground);
				return;
			}

			ServerCommunication sc = new ServerCommunication();
			string response = sc.SendPost(loginURL, String.Format("username={0}&password={1}", loginInfo.username, loginInfo.password));
			response = response.Trim();
			string[] splittedResponse = response.Split(' ');
			switch (splittedResponse[0])
			{
				case "empty_value":
					DisplayErrorMessage(emptyFieldError, cErrorBackground);
					return;
				case "incorrect":
					DisplayErrorMessage(wrongCredentialsError, cErrorBackground);
					return;
				case "user_not_found":
					DisplayErrorMessage(wrongCredentialsError, cErrorBackground);
					return;
				case "success":
					break;
				default:
					Console.WriteLine("ERROR FROM SERVER: " + response);
					return;
			}

			if (!loginInfo.rememberme)
				loginInfo.password = "";

			loginInfo.username = splittedResponse[1];

			FileManager fm = new FileManager();
			fm.SerializeFile(loginInfo, Application.StartupPath + "/saves", "session.save");

			LoginUser();
		}

		private void OnSignupButtonClicked(object sender, MouseEventArgs e)
		{

		}

		private void OnPasswordResetButtonClicked(object sender, MouseEventArgs e)
		{

		}

		private void onFormShow(object sender, EventArgs e)
		{
			FileManager fm = new FileManager();
			loginInfo = fm.DeserializeFile<LoginInfo>(Application.StartupPath + "/saves/session.save");

			if (loginInfo == null)
				loginInfo = new LoginInfo();

			if (loginInfo.rememberme)
			{
				LoginUser();
				return;
			}

			tbLoginBox.Focus();
			tbLoginBox.Text = loginInfo.username;
			this.ActiveControl = null;
		}

		#endregion

		#region Custom functions
		private void LoginUser()
		{
			Userinfo.username = loginInfo.username;
			Console.WriteLine("Logged in as user: " + loginInfo.username);
			this.Close();
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

		private void DisableErrorMessage()
		{
			lErrorLabel.Visible = false;
			lErrorFlag.Visible = false;
		}

		private void DisplayErrorMessage(string message, Color background)
		{
			lErrorLabel.BackColor = background;
			lErrorFlag.BackColor = background;
			lErrorLabel.Visible = true;
			lErrorFlag.Visible = true;

			lErrorLabel.Text = message;
		}
		#endregion
	}

	[Serializable]
	public class LoginInfo
	{
		public string username = "";
		public string password = "";
		public bool rememberme = false;
	}

	public static class Userinfo
	{
		public static string username;
	}
}
