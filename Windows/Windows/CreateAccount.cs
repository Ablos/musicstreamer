/*
 * (c) Abel Dieterich - HotkeyCode Inc.
 */

using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

namespace Windows
{
	public partial class CreateAccount : Form
	{
		public const int WM_NCLBUTTONDOWN = 0xA1;
		public const int HT_CAPTION = 0x2;

		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		public CreateAccount(Login l)
		{
			login = l;

			InitializeComponent();
			this.Icon = ResourceLoader.loadIcon("logo-icon");
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
			tbUsernameBox.BackColor = cTextBox;
			tbUsernameBox.BorderStyle = BorderStyle.None;
			tbUsernameBox.Font = new Font("Roboto", 10f, FontStyle.Regular);
			tbUsernameBox.ForeColor = cInactiveText;
			tbUsernameBox.Text = usernamePlaceholder;
			tbUsernameBox.Size = new Size(300, 15);
			tbUsernameBox.Location = new Point(this.Width / 2 - tbUsernameBox.Width / 2, pbLogoBanner.Location.Y + pbLogoBanner.Height + 60);
			tbUsernameBox.Enter += new EventHandler(OnUsernameEnter);
			tbUsernameBox.Leave += new EventHandler(OnUsernameLeave);
			tbUsernameBox.KeyPress += new KeyPressEventHandler(OnUsernameKeyPress);
			Controls.Add(tbUsernameBox);
			UsernameTextBoxBackground = new Rectangle(new Point(tbUsernameBox.Location.X - TextBoxBorderSize, tbUsernameBox.Location.Y - TextBoxBorderSize), new Size(tbUsernameBox.Width + (2 * TextBoxBorderSize), tbUsernameBox.Height + (2 * TextBoxBorderSize)));

			tbEmailBox.BackColor = cTextBox;
			tbEmailBox.BorderStyle = BorderStyle.None;
			tbEmailBox.Font = new Font("Roboto", 10f, FontStyle.Regular);
			tbEmailBox.ForeColor = cInactiveText;
			tbEmailBox.Text = emailPlaceholder;
			tbEmailBox.Size = tbUsernameBox.Size;
			tbEmailBox.Location = new Point(this.Width / 2 - tbUsernameBox.Width / 2, tbUsernameBox.Location.Y + tbUsernameBox.Height + 25);
			tbEmailBox.Enter += new EventHandler(OnEmailEnter);
			tbEmailBox.Leave += new EventHandler(OnEmailLeave);
			tbEmailBox.KeyPress += new KeyPressEventHandler(OnEmailKeyPress);
			Controls.Add(tbEmailBox);
			EmailTextBoxBackground = new Rectangle(new Point(tbEmailBox.Location.X - TextBoxBorderSize, tbEmailBox.Location.Y - TextBoxBorderSize), new Size(tbEmailBox.Width + (2 * TextBoxBorderSize), tbEmailBox.Height + (2 * TextBoxBorderSize)));

			tbPasswordBox.BackColor = cTextBox;
			tbPasswordBox.BorderStyle = BorderStyle.None;
			tbPasswordBox.Font = new Font("Roboto", 10f, FontStyle.Regular);
			tbPasswordBox.ForeColor = cInactiveText;
			tbPasswordBox.Text = passwordPlaceholder;
			tbPasswordBox.Size = tbEmailBox.Size;
			tbPasswordBox.Location = new Point(this.Width / 2 - tbEmailBox.Width / 2, tbEmailBox.Location.Y + tbEmailBox.Height + 25);
			tbPasswordBox.Enter += new EventHandler(OnPasswordEnter);
			tbPasswordBox.Leave += new EventHandler(OnPasswordLeave);
			tbPasswordBox.KeyPress += new KeyPressEventHandler(OnPasswordKeyPress);
			Controls.Add(tbPasswordBox);
			PasswordTextBoxBackground = new Rectangle(new Point(tbPasswordBox.Location.X - TextBoxBorderSize, tbPasswordBox.Location.Y - TextBoxBorderSize), new Size(tbPasswordBox.Width + (2 * TextBoxBorderSize), tbPasswordBox.Height + (2 * TextBoxBorderSize)));

			tbPasswordConfirmBox.BackColor = cTextBox;
			tbPasswordConfirmBox.BorderStyle = BorderStyle.None;
			tbPasswordConfirmBox.Font = new Font("Roboto", 10f, FontStyle.Regular);
			tbPasswordConfirmBox.ForeColor = cInactiveText;
			tbPasswordConfirmBox.Text = passwordConfirmPlaceholder;
			tbPasswordConfirmBox.Size = tbPasswordBox.Size;
			tbPasswordConfirmBox.Location = new Point(this.Width / 2 - tbPasswordBox.Width / 2, tbPasswordBox.Location.Y + tbPasswordBox.Height + 25);
			tbPasswordConfirmBox.Enter += new EventHandler(OnPasswordConfirmEnter);
			tbPasswordConfirmBox.Leave += new EventHandler(OnPasswordConfirmLeave);
			tbPasswordConfirmBox.KeyPress += new KeyPressEventHandler(OnPasswordConfirmKeyPress);
			Controls.Add(tbPasswordConfirmBox);
			PasswordConfirmTexBoxBackground = new Rectangle(new Point(tbPasswordConfirmBox.Location.X - TextBoxBorderSize, tbPasswordConfirmBox.Location.Y - TextBoxBorderSize), new Size(tbPasswordConfirmBox.Width + (2 * TextBoxBorderSize), tbPasswordConfirmBox.Height + (2 * TextBoxBorderSize)));

			#endregion

			#region Instantiate login button

			bCreateAccountButton.BackColor = cUnhoveredButton;
			bCreateAccountButton.FlatStyle = FlatStyle.Flat;
			bCreateAccountButton.FlatAppearance.BorderSize = 0;
			bCreateAccountButton.FlatAppearance.MouseOverBackColor = cHoveredButton;
			bCreateAccountButton.FlatAppearance.MouseDownBackColor = cMouseDownButton;
			bCreateAccountButton.ForeColor = Color.White;
			bCreateAccountButton.Font = new Font("Roboto Light", 12f, FontStyle.Regular);
			bCreateAccountButton.Text = "CREATE ACCOUNT";
			bCreateAccountButton.TextAlign = ContentAlignment.MiddleCenter;
			bCreateAccountButton.Size = new Size(250, 30);
			bCreateAccountButton.Location = new Point(this.Width / 2 - bCreateAccountButton.Width / 2, tbPasswordConfirmBox.Location.Y + tbPasswordConfirmBox.Height + 25);
			bCreateAccountButton.MouseClick += new MouseEventHandler(OnCreateAccountButtonClicked);
			Controls.Add(bCreateAccountButton);

			#endregion

			#region Instantiate error label
			lErrorLabel.AutoSize = false;
			lErrorLabel.Size = new Size(300, 24);
			lErrorLabel.BackColor = cErrorBackground;
			lErrorLabel.Font = new Font("Roboto", 10f, FontStyle.Regular);
			lErrorLabel.ForeColor = Color.White;
			lErrorLabel.Location = new Point(this.Width / 2 - lErrorLabel.Width / 2, bCreateAccountButton.Location.Y + bCreateAccountButton.Height + 25);
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
			bSignupButton.Text = "LOGIN";
			bSignupButton.TextAlign = ContentAlignment.MiddleCenter;
			bSignupButton.Size = new Size(150, 30);
			bSignupButton.Location = new Point(this.Width / 2 - (bSignupButton.Width / 2), this.Height - bSignupButton.Height - 5);
			bSignupButton.MouseClick += new MouseEventHandler(OnLoginButtonClicked);
			Controls.Add(bSignupButton);
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

		const string usernamePlaceholder = "Username ";
		const string emailPlaceholder = "E-mail ";
		const string passwordPlaceholder = "Password ";
		const string passwordConfirmPlaceholder = "Confirm password";
		const string createAccountURL = "http://ablos.square7.ch/accounts/signup.php";
		const string emptyFieldError = "Please fill in all fields!";
		const string noPasswordMatchError = "The passwords don't match!";
		const string falseEmailError = "Please fill in valid e-mail!";
		const string userExistsError = "This username is already taken!";
		#endregion

		#region Sizes and offsets
		const int TopSize = 20;                         // Size of the top bar

		const int ControlButtonsOffset = 2;             // Offset of controlbuttons
		const int ControlButtonsResize = 4;             // How much pixels the control buttons should be smaller

		const int TextBoxBorderSize = 5;                // How much pixels should the border of the text boxes be
		#endregion

		#region Control Rectangles
		Rectangle TopBar { get { return new Rectangle(0, 0, this.ClientSize.Width, TopSize); } }
		Rectangle UsernameTextBoxBackground = new Rectangle();
		Rectangle EmailTextBoxBackground = new Rectangle();
		Rectangle PasswordTextBoxBackground = new Rectangle();
		Rectangle PasswordConfirmTexBoxBackground = new Rectangle();
		#endregion

		#region Controls
		// Buttons
		Button bExitButton = new Button();
		Button bMaximizeButton = new Button();
		Button bExitMaximizeButton = new Button();
		Button bMinimizeButton = new Button();

		Button bCreateAccountButton = new Button();

		Button bSignupButton = new Button();

		// Picuture box
		PictureBox pbLogoBanner = new PictureBox();

		// Input fields
		TextBox tbUsernameBox = new TextBox();
		TextBox tbEmailBox = new TextBox();
		TextBox tbPasswordBox = new TextBox();
		TextBox tbPasswordConfirmBox = new TextBox();

		// Labels
		Label lErrorLabel = new Label();
		Label lErrorFlag = new Label();
		#endregion

		#region Variables
		AccountInfo accountInfo = new AccountInfo();
		Login login;
		#endregion

		#region Forms functions
		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.FillRectangle(new SolidBrush(cTextBox), UsernameTextBoxBackground);
			e.Graphics.FillRectangle(new SolidBrush(cTextBox), EmailTextBoxBackground);
			e.Graphics.FillRectangle(new SolidBrush(cTextBox), PasswordTextBoxBackground);
			e.Graphics.FillRectangle(new SolidBrush(cTextBox), PasswordConfirmTexBoxBackground);

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
				OnCreateAccountButtonClicked(null, null);
		}
		#endregion

		#region Buttons
		#region ControlButtons
		// Button to quit the application
		private void ExitButton_Click(object sender, EventArgs e)
		{
			login.Close();
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

		private void OnUsernameEnter(object sender, EventArgs e)
		{
			DisableErrorMessage();

			if (tbUsernameBox.Text == usernamePlaceholder)
			{
				tbUsernameBox.Text = "";
				tbUsernameBox.ForeColor = Color.White;
			}
		}

		private void OnUsernameLeave(object sender, EventArgs e)
		{
			if (tbUsernameBox.Text == "")
			{
				accountInfo.username = null;
				tbUsernameBox.ForeColor = cInactiveText;
				tbUsernameBox.Text = usernamePlaceholder;
			}
			else
			{
				accountInfo.username = tbUsernameBox.Text.ToLower();
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
				accountInfo.password = null;
				tbPasswordBox.ForeColor = cInactiveText;
				tbPasswordBox.UseSystemPasswordChar = false;
				tbPasswordBox.Text = passwordPlaceholder;
			}
			else
			{
				accountInfo.password = tbPasswordBox.Text;
			}
		}

		private void OnEmailEnter(object sender, EventArgs e)
		{
			DisableErrorMessage();

			if (tbEmailBox.Text == emailPlaceholder)
			{
				tbEmailBox.Text = "";
				tbEmailBox.ForeColor = Color.White;
			}
		}

		private void OnEmailLeave(object sender, EventArgs e)
		{
			if (tbEmailBox.Text == "")
			{
				accountInfo.email = null;
				tbEmailBox.ForeColor = cInactiveText;
				tbEmailBox.Text = emailPlaceholder;
			}else
			{
				accountInfo.email = tbEmailBox.Text.ToLower();
			}
		}

		private void OnPasswordConfirmEnter(object sender, EventArgs e)
		{
			DisableErrorMessage();

			if (tbPasswordConfirmBox.Text == passwordConfirmPlaceholder)
			{
				tbPasswordConfirmBox.Text = "";
				tbPasswordConfirmBox.ForeColor = Color.White;
				tbPasswordConfirmBox.UseSystemPasswordChar = true;
			}
		}

		private void OnPasswordConfirmLeave(object sender, EventArgs e)
		{
			if (tbPasswordConfirmBox.Text == "")
			{
				accountInfo.passwordconfirm = null;
				tbPasswordConfirmBox.ForeColor = cInactiveText;
				tbPasswordConfirmBox.UseSystemPasswordChar = false;
				tbPasswordConfirmBox.Text = passwordConfirmPlaceholder;
			}else
			{
				accountInfo.passwordconfirm = tbPasswordConfirmBox.Text;
			}
		}

		private void OnUsernameKeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString() == " ")
				e.Handled = true;
			if (e.KeyChar == (char)13)
			{
				this.ActiveControl = null;
				OnCreateAccountButtonClicked(null, null);
			}
		}

		private void OnPasswordKeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString() == " ")
				e.Handled = true;
			if (e.KeyChar == (char)13)
			{
				this.ActiveControl = null;
				OnCreateAccountButtonClicked(null, null);
			}
		}

		private void OnEmailKeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString() == " ")
				e.Handled = true;
			if (e.KeyChar == (char)13)
			{
				this.ActiveControl = null;
				OnCreateAccountButtonClicked(null, null);
			}
		}

		private void OnPasswordConfirmKeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString() == " ")
				e.Handled = true;
			if (e.KeyChar == (char)13)
			{
				this.ActiveControl = null;
				OnCreateAccountButtonClicked(null, null);
			}
		}

		private void OnFormMouseClick(object sender, EventArgs e)
		{
			if (tbPasswordBox.Text == "")
			{
				tbPasswordBox.UseSystemPasswordChar = false;
			}

			if (tbPasswordConfirmBox.Text == "")
			{
				tbPasswordConfirmBox.UseSystemPasswordChar = false;
			}

			this.ActiveControl = null;
		}

		private void OnCreateAccountButtonClicked(object sender, MouseEventArgs e)
		{
			DisableErrorMessage();

			if (string.IsNullOrEmpty(accountInfo.username) || string.IsNullOrEmpty(accountInfo.email) || string.IsNullOrEmpty(accountInfo.password) || string.IsNullOrEmpty(accountInfo.passwordconfirm))
			{
				DisplayErrorMessage(emptyFieldError, cErrorBackground);
				return;
			}

			if (accountInfo.password != accountInfo.passwordconfirm)
			{
				DisplayErrorMessage(noPasswordMatchError, cErrorBackground);
				return;
			}

			ServerCommunication sc = new ServerCommunication();
			string response = sc.SendPost(createAccountURL, String.Format("username={0}&email={1}&password={2}", accountInfo.username, accountInfo.email, accountInfo.password));
			response = response.Trim();
			string[] splittedResponse = response.Split(' ');
			switch (splittedResponse[0])
			{
				case "empty_value":
					DisplayErrorMessage(emptyFieldError, cErrorBackground);
					return;
				case "false_email":
					DisplayErrorMessage(falseEmailError, cErrorBackground);
					return;
				case "user_exists":
					DisplayErrorMessage(userExistsError, cErrorBackground);
					return;
				case "success":
					break;
				default:
					Console.WriteLine("ERROR FROM SERVER: " + response);
					return;
			}

			CreateUser();
		}

		private void OnLoginButtonClicked(object sender, MouseEventArgs e)
		{
			login.Location = this.Location;
			login.Visible = true;
			this.Close();
		}

		private void onFormShow(object sender, EventArgs e)
		{
			
		}

		#endregion

		#region Custom functions
		private void CreateUser()
		{
			Console.WriteLine("Sent confirmation mail to: " + accountInfo.email);
			login.Location = this.Location;
			login.DisplayErrorMessage("Sent confirmation mail!", cMessageBackground);
			login.Visible = true;
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

		private class AccountInfo
		{
			public string username;
			public string email;
			public string password;
			public string passwordconfirm;
		}
	}
}
