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
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1098, 611);
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
	}
}

