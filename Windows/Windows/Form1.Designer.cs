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
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(9, 50);
			this.button1.Margin = new System.Windows.Forms.Padding(2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(56, 19);
			this.button1.TabIndex = 6;
			this.button1.Text = "button1";
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
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1098, 611);
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
	}
}

