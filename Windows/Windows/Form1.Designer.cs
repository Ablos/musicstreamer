namespace Windows
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.QuitButton = new System.Windows.Forms.Button();
            this.MaximizeButton = new System.Windows.Forms.Button();
            this.NormalWindowButton = new System.Windows.Forms.Button();
            this.MinimizeButton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            this.PlayButtonUnhovered = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.PauseButtonUnhovered = new System.Windows.Forms.Button();
            this.SkipButton = new System.Windows.Forms.Button();
            this.SkipButtonUnhovered = new System.Windows.Forms.Button();
            this.BackButtonUnhovered = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.ShuffleButton = new System.Windows.Forms.Button();
            this.ShuffleButtonUnhovered = new System.Windows.Forms.Button();
            this.EnabledShuffleButton = new System.Windows.Forms.Button();
            this.EnabledShuffleButtonUnhovered = new System.Windows.Forms.Button();
            this.RepeatButton = new System.Windows.Forms.Button();
            this.RepeatButtonUnhovered = new System.Windows.Forms.Button();
            this.EnabledRepeatButton = new System.Windows.Forms.Button();
            this.EnabledRepeatButtonUnhovered = new System.Windows.Forms.Button();
            this.EnabledRepeatOneButton = new System.Windows.Forms.Button();
            this.EnabledRepeatOneButtonUnhovered = new System.Windows.Forms.Button();
            this.SliderHandle = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(688, 375);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "Upload";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Title
            // 
            this.Title.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Location = new System.Drawing.Point(688, 11);
            this.Title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Title.Name = "Title";
            this.Title.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Title.Size = new System.Drawing.Size(58, 20);
            this.Title.TabIndex = 7;
            this.Title.Text = "VIBES";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Mover);
            // 
            // QuitButton
            // 
            this.QuitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.QuitButton.BackColor = System.Drawing.Color.Transparent;
            this.QuitButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("QuitButton.BackgroundImage")));
            this.QuitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.QuitButton.FlatAppearance.BorderSize = 0;
            this.QuitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.QuitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.QuitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QuitButton.Location = new System.Drawing.Point(1425, 1);
            this.QuitButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(40, 37);
            this.QuitButton.TabIndex = 8;
            this.QuitButton.UseVisualStyleBackColor = false;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // MaximizeButton
            // 
            this.MaximizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MaximizeButton.BackColor = System.Drawing.Color.Transparent;
            this.MaximizeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MaximizeButton.BackgroundImage")));
            this.MaximizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MaximizeButton.FlatAppearance.BorderSize = 0;
            this.MaximizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MaximizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.MaximizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaximizeButton.Location = new System.Drawing.Point(1393, 1);
            this.MaximizeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeButton.Name = "MaximizeButton";
            this.MaximizeButton.Size = new System.Drawing.Size(40, 37);
            this.MaximizeButton.TabIndex = 9;
            this.MaximizeButton.UseVisualStyleBackColor = false;
            this.MaximizeButton.Click += new System.EventHandler(this.MaximizeButton_Click);
            // 
            // NormalWindowButton
            // 
            this.NormalWindowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NormalWindowButton.BackColor = System.Drawing.Color.Transparent;
            this.NormalWindowButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("NormalWindowButton.BackgroundImage")));
            this.NormalWindowButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NormalWindowButton.FlatAppearance.BorderSize = 0;
            this.NormalWindowButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NormalWindowButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.NormalWindowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NormalWindowButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.NormalWindowButton.Location = new System.Drawing.Point(1393, 1);
            this.NormalWindowButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NormalWindowButton.Name = "NormalWindowButton";
            this.NormalWindowButton.Size = new System.Drawing.Size(40, 37);
            this.NormalWindowButton.TabIndex = 10;
            this.NormalWindowButton.UseVisualStyleBackColor = false;
            this.NormalWindowButton.Visible = false;
            this.NormalWindowButton.Click += new System.EventHandler(this.NormalWindowButton_Click);
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimizeButton.BackColor = System.Drawing.Color.Transparent;
            this.MinimizeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MinimizeButton.BackgroundImage")));
            this.MinimizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MinimizeButton.FlatAppearance.BorderSize = 0;
            this.MinimizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MinimizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.MinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeButton.Location = new System.Drawing.Point(1359, 1);
            this.MinimizeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(40, 37);
            this.MinimizeButton.TabIndex = 11;
            this.MinimizeButton.UseVisualStyleBackColor = false;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.BackColor = System.Drawing.Color.Transparent;
            this.PlayButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PlayButton.BackgroundImage")));
            this.PlayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PlayButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.PlayButton.FlatAppearance.BorderSize = 0;
            this.PlayButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.PlayButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.PlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayButton.Location = new System.Drawing.Point(745, 630);
            this.PlayButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(67, 62);
            this.PlayButton.TabIndex = 12;
            this.PlayButton.UseVisualStyleBackColor = false;
            this.PlayButton.Visible = false;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            this.PlayButton.MouseLeave += new System.EventHandler(this.PlayMouseLeave);
            // 
            // PlayButtonUnhovered
            // 
            this.PlayButtonUnhovered.BackColor = System.Drawing.Color.Transparent;
            this.PlayButtonUnhovered.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PlayButtonUnhovered.BackgroundImage")));
            this.PlayButtonUnhovered.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PlayButtonUnhovered.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.PlayButtonUnhovered.FlatAppearance.BorderSize = 0;
            this.PlayButtonUnhovered.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.PlayButtonUnhovered.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.PlayButtonUnhovered.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayButtonUnhovered.Location = new System.Drawing.Point(745, 561);
            this.PlayButtonUnhovered.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PlayButtonUnhovered.Name = "PlayButtonUnhovered";
            this.PlayButtonUnhovered.Size = new System.Drawing.Size(67, 62);
            this.PlayButtonUnhovered.TabIndex = 13;
            this.PlayButtonUnhovered.UseVisualStyleBackColor = false;
            this.PlayButtonUnhovered.MouseEnter += new System.EventHandler(this.PlayMouseEnter);
            // 
            // PauseButton
            // 
            this.PauseButton.BackColor = System.Drawing.Color.Transparent;
            this.PauseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PauseButton.BackgroundImage")));
            this.PauseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PauseButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.PauseButton.FlatAppearance.BorderSize = 0;
            this.PauseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.PauseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.PauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PauseButton.Location = new System.Drawing.Point(652, 630);
            this.PauseButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(67, 62);
            this.PauseButton.TabIndex = 14;
            this.PauseButton.UseVisualStyleBackColor = false;
            this.PauseButton.Visible = false;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            this.PauseButton.MouseLeave += new System.EventHandler(this.PauseMouseLeave);
            // 
            // PauseButtonUnhovered
            // 
            this.PauseButtonUnhovered.BackColor = System.Drawing.Color.Transparent;
            this.PauseButtonUnhovered.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PauseButtonUnhovered.BackgroundImage")));
            this.PauseButtonUnhovered.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PauseButtonUnhovered.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.PauseButtonUnhovered.FlatAppearance.BorderSize = 0;
            this.PauseButtonUnhovered.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.PauseButtonUnhovered.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.PauseButtonUnhovered.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PauseButtonUnhovered.Location = new System.Drawing.Point(652, 561);
            this.PauseButtonUnhovered.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PauseButtonUnhovered.Name = "PauseButtonUnhovered";
            this.PauseButtonUnhovered.Size = new System.Drawing.Size(67, 62);
            this.PauseButtonUnhovered.TabIndex = 15;
            this.PauseButtonUnhovered.UseVisualStyleBackColor = false;
            this.PauseButtonUnhovered.Visible = false;
            this.PauseButtonUnhovered.MouseEnter += new System.EventHandler(this.PauseMouseEnter);
            // 
            // SkipButton
            // 
            this.SkipButton.BackColor = System.Drawing.Color.Transparent;
            this.SkipButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SkipButton.BackgroundImage")));
            this.SkipButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SkipButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.SkipButton.FlatAppearance.BorderSize = 0;
            this.SkipButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SkipButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SkipButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SkipButton.Location = new System.Drawing.Point(820, 636);
            this.SkipButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SkipButton.Name = "SkipButton";
            this.SkipButton.Size = new System.Drawing.Size(53, 49);
            this.SkipButton.TabIndex = 16;
            this.SkipButton.UseVisualStyleBackColor = false;
            this.SkipButton.Visible = false;
            this.SkipButton.Click += new System.EventHandler(this.SkipButton_Click);
            this.SkipButton.MouseEnter += new System.EventHandler(this.SkipMouseEnter);
            this.SkipButton.MouseLeave += new System.EventHandler(this.SkipMouseLeave);
            // 
            // SkipButtonUnhovered
            // 
            this.SkipButtonUnhovered.BackColor = System.Drawing.Color.Transparent;
            this.SkipButtonUnhovered.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SkipButtonUnhovered.BackgroundImage")));
            this.SkipButtonUnhovered.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SkipButtonUnhovered.Cursor = System.Windows.Forms.Cursors.Default;
            this.SkipButtonUnhovered.FlatAppearance.BorderSize = 0;
            this.SkipButtonUnhovered.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SkipButtonUnhovered.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SkipButtonUnhovered.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SkipButtonUnhovered.Location = new System.Drawing.Point(820, 592);
            this.SkipButtonUnhovered.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SkipButtonUnhovered.Name = "SkipButtonUnhovered";
            this.SkipButtonUnhovered.Size = new System.Drawing.Size(53, 49);
            this.SkipButtonUnhovered.TabIndex = 17;
            this.SkipButtonUnhovered.UseVisualStyleBackColor = false;
            this.SkipButtonUnhovered.MouseEnter += new System.EventHandler(this.SkipMouseEnter);
            // 
            // BackButtonUnhovered
            // 
            this.BackButtonUnhovered.BackColor = System.Drawing.Color.Transparent;
            this.BackButtonUnhovered.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BackButtonUnhovered.BackgroundImage")));
            this.BackButtonUnhovered.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackButtonUnhovered.Cursor = System.Windows.Forms.Cursors.Default;
            this.BackButtonUnhovered.FlatAppearance.BorderSize = 0;
            this.BackButtonUnhovered.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BackButtonUnhovered.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BackButtonUnhovered.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButtonUnhovered.Location = new System.Drawing.Point(591, 642);
            this.BackButtonUnhovered.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BackButtonUnhovered.Name = "BackButtonUnhovered";
            this.BackButtonUnhovered.Size = new System.Drawing.Size(53, 49);
            this.BackButtonUnhovered.TabIndex = 18;
            this.BackButtonUnhovered.UseVisualStyleBackColor = false;
            this.BackButtonUnhovered.MouseEnter += new System.EventHandler(this.BackMouseEnter);
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.Transparent;
            this.BackButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BackButton.BackgroundImage")));
            this.BackButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.BackButton.FlatAppearance.BorderSize = 0;
            this.BackButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BackButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Location = new System.Drawing.Point(591, 594);
            this.BackButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(53, 49);
            this.BackButton.TabIndex = 19;
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Visible = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            this.BackButton.MouseLeave += new System.EventHandler(this.BackMouseLeave);
            // 
            // ShuffleButton
            // 
            this.ShuffleButton.BackColor = System.Drawing.Color.Transparent;
            this.ShuffleButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ShuffleButton.BackgroundImage")));
            this.ShuffleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ShuffleButton.FlatAppearance.BorderSize = 0;
            this.ShuffleButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ShuffleButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ShuffleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShuffleButton.Location = new System.Drawing.Point(536, 649);
            this.ShuffleButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ShuffleButton.Name = "ShuffleButton";
            this.ShuffleButton.Size = new System.Drawing.Size(47, 43);
            this.ShuffleButton.TabIndex = 20;
            this.ShuffleButton.UseVisualStyleBackColor = false;
            this.ShuffleButton.Visible = false;
            this.ShuffleButton.Click += new System.EventHandler(this.ShuffleButton_Click);
            this.ShuffleButton.MouseLeave += new System.EventHandler(this.ShuffleMouseLeave);
            // 
            // ShuffleButtonUnhovered
            // 
            this.ShuffleButtonUnhovered.BackColor = System.Drawing.Color.Transparent;
            this.ShuffleButtonUnhovered.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ShuffleButtonUnhovered.BackgroundImage")));
            this.ShuffleButtonUnhovered.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ShuffleButtonUnhovered.FlatAppearance.BorderSize = 0;
            this.ShuffleButtonUnhovered.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ShuffleButtonUnhovered.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ShuffleButtonUnhovered.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShuffleButtonUnhovered.Location = new System.Drawing.Point(536, 598);
            this.ShuffleButtonUnhovered.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ShuffleButtonUnhovered.Name = "ShuffleButtonUnhovered";
            this.ShuffleButtonUnhovered.Size = new System.Drawing.Size(47, 43);
            this.ShuffleButtonUnhovered.TabIndex = 21;
            this.ShuffleButtonUnhovered.UseVisualStyleBackColor = false;
            this.ShuffleButtonUnhovered.MouseEnter += new System.EventHandler(this.ShuffleMouseEnter);
            // 
            // EnabledShuffleButton
            // 
            this.EnabledShuffleButton.BackColor = System.Drawing.Color.Transparent;
            this.EnabledShuffleButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EnabledShuffleButton.BackgroundImage")));
            this.EnabledShuffleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EnabledShuffleButton.FlatAppearance.BorderSize = 0;
            this.EnabledShuffleButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.EnabledShuffleButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.EnabledShuffleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EnabledShuffleButton.Location = new System.Drawing.Point(481, 649);
            this.EnabledShuffleButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EnabledShuffleButton.Name = "EnabledShuffleButton";
            this.EnabledShuffleButton.Size = new System.Drawing.Size(47, 43);
            this.EnabledShuffleButton.TabIndex = 22;
            this.EnabledShuffleButton.UseVisualStyleBackColor = false;
            this.EnabledShuffleButton.Visible = false;
            this.EnabledShuffleButton.Click += new System.EventHandler(this.EnabledShuffleButton_Click);
            this.EnabledShuffleButton.MouseLeave += new System.EventHandler(this.EnabledShuffleMouseLeave);
            // 
            // EnabledShuffleButtonUnhovered
            // 
            this.EnabledShuffleButtonUnhovered.BackColor = System.Drawing.Color.Transparent;
            this.EnabledShuffleButtonUnhovered.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EnabledShuffleButtonUnhovered.BackgroundImage")));
            this.EnabledShuffleButtonUnhovered.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EnabledShuffleButtonUnhovered.FlatAppearance.BorderSize = 0;
            this.EnabledShuffleButtonUnhovered.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.EnabledShuffleButtonUnhovered.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.EnabledShuffleButtonUnhovered.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EnabledShuffleButtonUnhovered.Location = new System.Drawing.Point(481, 601);
            this.EnabledShuffleButtonUnhovered.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EnabledShuffleButtonUnhovered.Name = "EnabledShuffleButtonUnhovered";
            this.EnabledShuffleButtonUnhovered.Size = new System.Drawing.Size(47, 43);
            this.EnabledShuffleButtonUnhovered.TabIndex = 23;
            this.EnabledShuffleButtonUnhovered.UseVisualStyleBackColor = false;
            this.EnabledShuffleButtonUnhovered.Visible = false;
            this.EnabledShuffleButtonUnhovered.MouseEnter += new System.EventHandler(this.EnabledShuffleMouseEnter);
            // 
            // RepeatButton
            // 
            this.RepeatButton.BackColor = System.Drawing.Color.Transparent;
            this.RepeatButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RepeatButton.BackgroundImage")));
            this.RepeatButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RepeatButton.FlatAppearance.BorderSize = 0;
            this.RepeatButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.RepeatButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.RepeatButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RepeatButton.Location = new System.Drawing.Point(881, 640);
            this.RepeatButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RepeatButton.Name = "RepeatButton";
            this.RepeatButton.Size = new System.Drawing.Size(47, 43);
            this.RepeatButton.TabIndex = 24;
            this.RepeatButton.UseVisualStyleBackColor = false;
            this.RepeatButton.Visible = false;
            this.RepeatButton.Click += new System.EventHandler(this.RepeatButton_Click);
            this.RepeatButton.MouseLeave += new System.EventHandler(this.RepeatMouseLeave);
            // 
            // RepeatButtonUnhovered
            // 
            this.RepeatButtonUnhovered.BackColor = System.Drawing.Color.Transparent;
            this.RepeatButtonUnhovered.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RepeatButtonUnhovered.BackgroundImage")));
            this.RepeatButtonUnhovered.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RepeatButtonUnhovered.FlatAppearance.BorderSize = 0;
            this.RepeatButtonUnhovered.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.RepeatButtonUnhovered.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.RepeatButtonUnhovered.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RepeatButtonUnhovered.Location = new System.Drawing.Point(881, 590);
            this.RepeatButtonUnhovered.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RepeatButtonUnhovered.Name = "RepeatButtonUnhovered";
            this.RepeatButtonUnhovered.Size = new System.Drawing.Size(47, 43);
            this.RepeatButtonUnhovered.TabIndex = 25;
            this.RepeatButtonUnhovered.UseVisualStyleBackColor = false;
            this.RepeatButtonUnhovered.MouseEnter += new System.EventHandler(this.RepeatMouseEnter);
            // 
            // EnabledRepeatButton
            // 
            this.EnabledRepeatButton.BackColor = System.Drawing.Color.Transparent;
            this.EnabledRepeatButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EnabledRepeatButton.BackgroundImage")));
            this.EnabledRepeatButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EnabledRepeatButton.FlatAppearance.BorderSize = 0;
            this.EnabledRepeatButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.EnabledRepeatButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.EnabledRepeatButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EnabledRepeatButton.Location = new System.Drawing.Point(936, 640);
            this.EnabledRepeatButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EnabledRepeatButton.Name = "EnabledRepeatButton";
            this.EnabledRepeatButton.Size = new System.Drawing.Size(47, 43);
            this.EnabledRepeatButton.TabIndex = 26;
            this.EnabledRepeatButton.UseVisualStyleBackColor = false;
            this.EnabledRepeatButton.Visible = false;
            this.EnabledRepeatButton.Click += new System.EventHandler(this.EnabledRepeatButton_Click);
            this.EnabledRepeatButton.MouseLeave += new System.EventHandler(this.EnabledRepeatMouseLeave);
            // 
            // EnabledRepeatButtonUnhovered
            // 
            this.EnabledRepeatButtonUnhovered.BackColor = System.Drawing.Color.Transparent;
            this.EnabledRepeatButtonUnhovered.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EnabledRepeatButtonUnhovered.BackgroundImage")));
            this.EnabledRepeatButtonUnhovered.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EnabledRepeatButtonUnhovered.FlatAppearance.BorderSize = 0;
            this.EnabledRepeatButtonUnhovered.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.EnabledRepeatButtonUnhovered.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.EnabledRepeatButtonUnhovered.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EnabledRepeatButtonUnhovered.Location = new System.Drawing.Point(936, 590);
            this.EnabledRepeatButtonUnhovered.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EnabledRepeatButtonUnhovered.Name = "EnabledRepeatButtonUnhovered";
            this.EnabledRepeatButtonUnhovered.Size = new System.Drawing.Size(47, 43);
            this.EnabledRepeatButtonUnhovered.TabIndex = 27;
            this.EnabledRepeatButtonUnhovered.UseVisualStyleBackColor = false;
            this.EnabledRepeatButtonUnhovered.Visible = false;
            this.EnabledRepeatButtonUnhovered.MouseEnter += new System.EventHandler(this.EnabledRepeatMouseEnter);
            // 
            // EnabledRepeatOneButton
            // 
            this.EnabledRepeatOneButton.BackColor = System.Drawing.Color.Transparent;
            this.EnabledRepeatOneButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EnabledRepeatOneButton.BackgroundImage")));
            this.EnabledRepeatOneButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EnabledRepeatOneButton.FlatAppearance.BorderSize = 0;
            this.EnabledRepeatOneButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.EnabledRepeatOneButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.EnabledRepeatOneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EnabledRepeatOneButton.Location = new System.Drawing.Point(991, 640);
            this.EnabledRepeatOneButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EnabledRepeatOneButton.Name = "EnabledRepeatOneButton";
            this.EnabledRepeatOneButton.Size = new System.Drawing.Size(47, 43);
            this.EnabledRepeatOneButton.TabIndex = 28;
            this.EnabledRepeatOneButton.UseVisualStyleBackColor = false;
            this.EnabledRepeatOneButton.Visible = false;
            this.EnabledRepeatOneButton.Click += new System.EventHandler(this.EnabledRepeatOneButton_Click);
            this.EnabledRepeatOneButton.MouseLeave += new System.EventHandler(this.EnabledRepeatOneMouseLeave);
            // 
            // EnabledRepeatOneButtonUnhovered
            // 
            this.EnabledRepeatOneButtonUnhovered.BackColor = System.Drawing.Color.Transparent;
            this.EnabledRepeatOneButtonUnhovered.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EnabledRepeatOneButtonUnhovered.BackgroundImage")));
            this.EnabledRepeatOneButtonUnhovered.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EnabledRepeatOneButtonUnhovered.FlatAppearance.BorderSize = 0;
            this.EnabledRepeatOneButtonUnhovered.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.EnabledRepeatOneButtonUnhovered.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.EnabledRepeatOneButtonUnhovered.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EnabledRepeatOneButtonUnhovered.Location = new System.Drawing.Point(991, 590);
            this.EnabledRepeatOneButtonUnhovered.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EnabledRepeatOneButtonUnhovered.Name = "EnabledRepeatOneButtonUnhovered";
            this.EnabledRepeatOneButtonUnhovered.Size = new System.Drawing.Size(47, 43);
            this.EnabledRepeatOneButtonUnhovered.TabIndex = 29;
            this.EnabledRepeatOneButtonUnhovered.UseVisualStyleBackColor = false;
            this.EnabledRepeatOneButtonUnhovered.Visible = false;
            this.EnabledRepeatOneButtonUnhovered.MouseEnter += new System.EventHandler(this.EnabledRepeatOneMouseEnter);
            // 
            // SliderHandle
            // 
            this.SliderHandle.BackColor = System.Drawing.Color.Transparent;
            this.SliderHandle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SliderHandle.BackgroundImage")));
            this.SliderHandle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SliderHandle.Location = new System.Drawing.Point(591, 711);
            this.SliderHandle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SliderHandle.Name = "SliderHandle";
            this.SliderHandle.Size = new System.Drawing.Size(13, 12);
            this.SliderHandle.TabIndex = 30;
            this.SliderHandle.Visible = false;
            this.SliderHandle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SliderHandleMouseDown);
            this.SliderHandle.MouseEnter += new System.EventHandler(this.SliderHandleMouseEnter);
            this.SliderHandle.MouseLeave += new System.EventHandler(this.SliderHandleMouseLeave);
            this.SliderHandle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SliderHandleMouseMove);
            this.SliderHandle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SliderHandleMouseUp);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(369, 204);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 38);
            this.button2.TabIndex = 31;
            this.button2.Text = "Upload";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1464, 752);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.SliderHandle);
            this.Controls.Add(this.EnabledRepeatOneButtonUnhovered);
            this.Controls.Add(this.EnabledRepeatOneButton);
            this.Controls.Add(this.EnabledRepeatButtonUnhovered);
            this.Controls.Add(this.EnabledRepeatButton);
            this.Controls.Add(this.RepeatButtonUnhovered);
            this.Controls.Add(this.RepeatButton);
            this.Controls.Add(this.EnabledShuffleButtonUnhovered);
            this.Controls.Add(this.EnabledShuffleButton);
            this.Controls.Add(this.ShuffleButtonUnhovered);
            this.Controls.Add(this.ShuffleButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.BackButtonUnhovered);
            this.Controls.Add(this.SkipButtonUnhovered);
            this.Controls.Add(this.SkipButton);
            this.Controls.Add(this.PauseButtonUnhovered);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.PlayButtonUnhovered);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.MinimizeButton);
            this.Controls.Add(this.NormalWindowButton);
            this.Controls.Add(this.MaximizeButton);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "VIBES";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormMouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
        private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label Title;
		private System.Windows.Forms.Button QuitButton;
		private System.Windows.Forms.Button MaximizeButton;
		private System.Windows.Forms.Button NormalWindowButton;
		private System.Windows.Forms.Button MinimizeButton;
		private System.Windows.Forms.Button PlayButton;
		private System.Windows.Forms.Button PlayButtonUnhovered;
		private System.Windows.Forms.Button PauseButton;
		private System.Windows.Forms.Button PauseButtonUnhovered;
		private System.Windows.Forms.Button SkipButton;
		private System.Windows.Forms.Button SkipButtonUnhovered;
		private System.Windows.Forms.Button BackButtonUnhovered;
		private System.Windows.Forms.Button BackButton;
		private System.Windows.Forms.Button ShuffleButton;
		private System.Windows.Forms.Button ShuffleButtonUnhovered;
		private System.Windows.Forms.Button EnabledShuffleButton;
		private System.Windows.Forms.Button EnabledShuffleButtonUnhovered;
		private System.Windows.Forms.Button RepeatButton;
		private System.Windows.Forms.Button RepeatButtonUnhovered;
		private System.Windows.Forms.Button EnabledRepeatButton;
		private System.Windows.Forms.Button EnabledRepeatButtonUnhovered;
		private System.Windows.Forms.Button EnabledRepeatOneButton;
		private System.Windows.Forms.Button EnabledRepeatOneButtonUnhovered;
		private System.Windows.Forms.Panel SliderHandle;
        private System.Windows.Forms.Button button2;
    }
}

