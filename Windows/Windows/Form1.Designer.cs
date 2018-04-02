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
			// Title
			// 
			this.Title.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.Title.AutoSize = true;
			this.Title.BackColor = System.Drawing.Color.Transparent;
			this.Title.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Title.ForeColor = System.Drawing.Color.White;
			this.Title.Location = new System.Drawing.Point(516, 9);
			this.Title.Name = "Title";
			this.Title.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.Title.Size = new System.Drawing.Size(42, 15);
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
			this.QuitButton.Location = new System.Drawing.Point(1069, 1);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(30, 30);
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
			this.PlayButton.Location = new System.Drawing.Point(516, 512);
			this.PlayButton.Name = "PlayButton";
			this.PlayButton.Size = new System.Drawing.Size(50, 50);
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
			this.PlayButtonUnhovered.Location = new System.Drawing.Point(516, 512);
			this.PlayButtonUnhovered.Name = "PlayButtonUnhovered";
			this.PlayButtonUnhovered.Size = new System.Drawing.Size(50, 50);
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
			this.PauseButton.Location = new System.Drawing.Point(516, 512);
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
			this.PauseButtonUnhovered.Location = new System.Drawing.Point(516, 512);
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
			this.SkipButton.Location = new System.Drawing.Point(581, 517);
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
			this.SkipButtonUnhovered.Location = new System.Drawing.Point(627, 517);
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
			this.BackButtonUnhovered.Location = new System.Drawing.Point(627, 471);
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
			this.BackButton.Location = new System.Drawing.Point(581, 471);
			this.BackButton.Name = "BackButton";
			this.BackButton.Size = new System.Drawing.Size(40, 40);
			this.BackButton.TabIndex = 19;
			this.BackButton.UseVisualStyleBackColor = false;
			this.BackButton.Visible = false;
			this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
			this.BackButton.MouseLeave += new System.EventHandler(this.BackMouseLeave);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1098, 611);
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
			this.Name = "Form1";
			this.Text = "VIBES";
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
	}
}

