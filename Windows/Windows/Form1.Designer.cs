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
			this.MaximizeButton = new System.Windows.Forms.Button();
			this.NormalWindowButton = new System.Windows.Forms.Button();
			this.MinimizeButton = new System.Windows.Forms.Button();
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
			this.button3 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(516, 305);
			this.button1.Margin = new System.Windows.Forms.Padding(2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(56, 31);
			this.button1.TabIndex = 6;
			this.button1.Text = "Upload";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
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
			this.MaximizeButton.Location = new System.Drawing.Point(1045, 1);
			this.MaximizeButton.Name = "MaximizeButton";
			this.MaximizeButton.Size = new System.Drawing.Size(30, 30);
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
			this.NormalWindowButton.Location = new System.Drawing.Point(1045, 1);
			this.NormalWindowButton.Name = "NormalWindowButton";
			this.NormalWindowButton.Size = new System.Drawing.Size(30, 30);
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
			this.MinimizeButton.Location = new System.Drawing.Point(1019, 1);
			this.MinimizeButton.Name = "MinimizeButton";
			this.MinimizeButton.Size = new System.Drawing.Size(30, 30);
			this.MinimizeButton.TabIndex = 11;
			this.MinimizeButton.UseVisualStyleBackColor = false;
			this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
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
			this.PauseButton.Location = new System.Drawing.Point(489, 512);
			this.PauseButton.Name = "PauseButton";
			this.PauseButton.Size = new System.Drawing.Size(50, 50);
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
			this.PauseButtonUnhovered.Location = new System.Drawing.Point(489, 456);
			this.PauseButtonUnhovered.Name = "PauseButtonUnhovered";
			this.PauseButtonUnhovered.Size = new System.Drawing.Size(50, 50);
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
			this.SkipButton.Location = new System.Drawing.Point(615, 517);
			this.SkipButton.Name = "SkipButton";
			this.SkipButton.Size = new System.Drawing.Size(40, 40);
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
			this.SkipButtonUnhovered.Location = new System.Drawing.Point(615, 481);
			this.SkipButtonUnhovered.Name = "SkipButtonUnhovered";
			this.SkipButtonUnhovered.Size = new System.Drawing.Size(40, 40);
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
			this.BackButtonUnhovered.Location = new System.Drawing.Point(443, 522);
			this.BackButtonUnhovered.Name = "BackButtonUnhovered";
			this.BackButtonUnhovered.Size = new System.Drawing.Size(40, 40);
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
			this.BackButton.Location = new System.Drawing.Point(443, 483);
			this.BackButton.Name = "BackButton";
			this.BackButton.Size = new System.Drawing.Size(40, 40);
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
			this.ShuffleButton.Location = new System.Drawing.Point(402, 527);
			this.ShuffleButton.Name = "ShuffleButton";
			this.ShuffleButton.Size = new System.Drawing.Size(35, 35);
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
			this.ShuffleButtonUnhovered.Location = new System.Drawing.Point(402, 486);
			this.ShuffleButtonUnhovered.Name = "ShuffleButtonUnhovered";
			this.ShuffleButtonUnhovered.Size = new System.Drawing.Size(35, 35);
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
			this.EnabledShuffleButton.Location = new System.Drawing.Point(361, 527);
			this.EnabledShuffleButton.Name = "EnabledShuffleButton";
			this.EnabledShuffleButton.Size = new System.Drawing.Size(35, 35);
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
			this.EnabledShuffleButtonUnhovered.Location = new System.Drawing.Point(361, 488);
			this.EnabledShuffleButtonUnhovered.Name = "EnabledShuffleButtonUnhovered";
			this.EnabledShuffleButtonUnhovered.Size = new System.Drawing.Size(35, 35);
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
			this.RepeatButton.Location = new System.Drawing.Point(661, 520);
			this.RepeatButton.Name = "RepeatButton";
			this.RepeatButton.Size = new System.Drawing.Size(35, 35);
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
			this.RepeatButtonUnhovered.Location = new System.Drawing.Point(661, 479);
			this.RepeatButtonUnhovered.Name = "RepeatButtonUnhovered";
			this.RepeatButtonUnhovered.Size = new System.Drawing.Size(35, 35);
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
			this.EnabledRepeatButton.Location = new System.Drawing.Point(702, 520);
			this.EnabledRepeatButton.Name = "EnabledRepeatButton";
			this.EnabledRepeatButton.Size = new System.Drawing.Size(35, 35);
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
			this.EnabledRepeatButtonUnhovered.Location = new System.Drawing.Point(702, 479);
			this.EnabledRepeatButtonUnhovered.Name = "EnabledRepeatButtonUnhovered";
			this.EnabledRepeatButtonUnhovered.Size = new System.Drawing.Size(35, 35);
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
			this.EnabledRepeatOneButton.Location = new System.Drawing.Point(743, 520);
			this.EnabledRepeatOneButton.Name = "EnabledRepeatOneButton";
			this.EnabledRepeatOneButton.Size = new System.Drawing.Size(35, 35);
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
			this.EnabledRepeatOneButtonUnhovered.Location = new System.Drawing.Point(743, 479);
			this.EnabledRepeatOneButtonUnhovered.Name = "EnabledRepeatOneButtonUnhovered";
			this.EnabledRepeatOneButtonUnhovered.Size = new System.Drawing.Size(35, 35);
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
			this.SliderHandle.Location = new System.Drawing.Point(443, 578);
			this.SliderHandle.Name = "SliderHandle";
			this.SliderHandle.Size = new System.Drawing.Size(10, 10);
			this.SliderHandle.TabIndex = 30;
			this.SliderHandle.Visible = false;
			this.SliderHandle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SliderHandleMouseDown);
			this.SliderHandle.MouseEnter += new System.EventHandler(this.SliderHandleMouseEnter);
			this.SliderHandle.MouseLeave += new System.EventHandler(this.SliderHandleMouseLeave);
			this.SliderHandle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SliderHandleMouseMove);
			this.SliderHandle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SliderHandleMouseUp);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(516, 257);
			this.button3.Margin = new System.Windows.Forms.Padding(2);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(56, 31);
			this.button3.TabIndex = 31;
			this.button3.Text = "form3";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1098, 611);
			this.Controls.Add(this.button3);
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
			this.Controls.Add(this.MinimizeButton);
			this.Controls.Add(this.NormalWindowButton);
			this.Controls.Add(this.MaximizeButton);
			this.Controls.Add(this.button1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "VIBES";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMouseUp);
			this.ResumeLayout(false);

		}

		#endregion
        private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button MaximizeButton;
		private System.Windows.Forms.Button NormalWindowButton;
		private System.Windows.Forms.Button MinimizeButton;
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
        private System.Windows.Forms.Button button3;
    }
}

