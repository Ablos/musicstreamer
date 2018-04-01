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
			this.TopBar_BG = new System.Windows.Forms.Panel();
			this.Title = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.TopBar_BG.SuspendLayout();
			this.SuspendLayout();
			// 
			// TopBar_BG
			// 
			this.TopBar_BG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
			this.TopBar_BG.Controls.Add(this.Title);
			this.TopBar_BG.Cursor = System.Windows.Forms.Cursors.Default;
			this.TopBar_BG.Dock = System.Windows.Forms.DockStyle.Top;
			this.TopBar_BG.Location = new System.Drawing.Point(0, 0);
			this.TopBar_BG.Name = "TopBar_BG";
			this.TopBar_BG.Size = new System.Drawing.Size(1098, 19);
			this.TopBar_BG.TabIndex = 5;
			// 
			// Title
			// 
			this.Title.Dock = System.Windows.Forms.DockStyle.Top;
			this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Title.ForeColor = System.Drawing.Color.White;
			this.Title.Location = new System.Drawing.Point(0, 0);
			this.Title.Name = "Title";
			this.Title.Size = new System.Drawing.Size(1098, 19);
			this.Title.TabIndex = 0;
			this.Title.Text = "VIBES";
			this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Mover);
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
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1098, 611);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.TopBar_BG);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "VIBES";
			this.TopBar_BG.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel TopBar_BG;
		private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button button1;
    }
}

