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
            this.LeftResizer = new System.Windows.Forms.Panel();
            this.RightResizer = new System.Windows.Forms.Panel();
            this.BottomResizer = new System.Windows.Forms.Panel();
            this.TopResizer = new System.Windows.Forms.Panel();
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
            this.TopBar_BG.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TopBar_BG.Name = "TopBar_BG";
            this.TopBar_BG.Size = new System.Drawing.Size(1464, 23);
            this.TopBar_BG.TabIndex = 5;
            // 
            // Title
            // 
            this.Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(1464, 23);
            this.Title.TabIndex = 0;
            this.Title.Text = "VIBES";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Mover);
            // 
            // LeftResizer
            // 
            this.LeftResizer.BackColor = System.Drawing.Color.Transparent;
            this.LeftResizer.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.LeftResizer.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftResizer.Location = new System.Drawing.Point(0, 23);
            this.LeftResizer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LeftResizer.Name = "LeftResizer";
            this.LeftResizer.Size = new System.Drawing.Size(4, 729);
            this.LeftResizer.TabIndex = 0;
            this.LeftResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resizer_Mouse_Down);
            this.LeftResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resizer_Left);
            // 
            // RightResizer
            // 
            this.RightResizer.BackColor = System.Drawing.Color.Transparent;
            this.RightResizer.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.RightResizer.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightResizer.Location = new System.Drawing.Point(1460, 23);
            this.RightResizer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RightResizer.Name = "RightResizer";
            this.RightResizer.Size = new System.Drawing.Size(4, 729);
            this.RightResizer.TabIndex = 0;
            this.RightResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resizer_Mouse_Down);
            this.RightResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resizer_Right);
            // 
            // BottomResizer
            // 
            this.BottomResizer.BackColor = System.Drawing.Color.Transparent;
            this.BottomResizer.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.BottomResizer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomResizer.Location = new System.Drawing.Point(4, 748);
            this.BottomResizer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BottomResizer.Name = "BottomResizer";
            this.BottomResizer.Size = new System.Drawing.Size(1456, 4);
            this.BottomResizer.TabIndex = 0;
            this.BottomResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resizer_Mouse_Down);
            this.BottomResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resizer_Down);
            // 
            // TopResizer
            // 
            this.TopResizer.BackColor = System.Drawing.Color.Transparent;
            this.TopResizer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TopResizer.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.TopResizer.Location = new System.Drawing.Point(4, 0);
            this.TopResizer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TopResizer.Name = "TopResizer";
            this.TopResizer.Size = new System.Drawing.Size(1460, 4);
            this.TopResizer.TabIndex = 3;
            this.TopResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resizer_Mouse_Down);
            this.TopResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resizer_Up);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1464, 752);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TopResizer);
            this.Controls.Add(this.BottomResizer);
            this.Controls.Add(this.RightResizer);
            this.Controls.Add(this.LeftResizer);
            this.Controls.Add(this.TopBar_BG);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "VIBES";
            this.TopBar_BG.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel TopResizer;
		private System.Windows.Forms.Panel TopBar_BG;
		private System.Windows.Forms.Panel LeftResizer;
		private System.Windows.Forms.Panel RightResizer;
		private System.Windows.Forms.Panel BottomResizer;
		private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button button1;
    }
}

