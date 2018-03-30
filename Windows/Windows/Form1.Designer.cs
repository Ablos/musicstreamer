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
<<<<<<< HEAD
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.TopBar_BG = new System.Windows.Forms.Panel();
			this.Title = new System.Windows.Forms.Label();
			this.LeftResizer = new System.Windows.Forms.Panel();
			this.RightResizer = new System.Windows.Forms.Panel();
			this.BottomResizer = new System.Windows.Forms.Panel();
			this.TopResizer = new System.Windows.Forms.Panel();
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
			this.Title.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Title.ForeColor = System.Drawing.Color.White;
			this.Title.Location = new System.Drawing.Point(0, 0);
			this.Title.Name = "Title";
			this.Title.Size = new System.Drawing.Size(1098, 19);
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
			this.LeftResizer.Location = new System.Drawing.Point(0, 19);
			this.LeftResizer.Name = "LeftResizer";
			this.LeftResizer.Size = new System.Drawing.Size(3, 592);
			this.LeftResizer.TabIndex = 0;
			this.LeftResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resizer_Mouse_Down);
			this.LeftResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resizer_Left);
			// 
			// RightResizer
			// 
			this.RightResizer.BackColor = System.Drawing.Color.Transparent;
			this.RightResizer.Cursor = System.Windows.Forms.Cursors.SizeWE;
			this.RightResizer.Dock = System.Windows.Forms.DockStyle.Right;
			this.RightResizer.Location = new System.Drawing.Point(1095, 19);
			this.RightResizer.Name = "RightResizer";
			this.RightResizer.Size = new System.Drawing.Size(3, 592);
			this.RightResizer.TabIndex = 0;
			this.RightResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resizer_Mouse_Down);
			this.RightResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resizer_Right);
			// 
			// BottomResizer
			// 
			this.BottomResizer.BackColor = System.Drawing.Color.Transparent;
			this.BottomResizer.Cursor = System.Windows.Forms.Cursors.SizeNS;
			this.BottomResizer.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.BottomResizer.Location = new System.Drawing.Point(3, 608);
			this.BottomResizer.Name = "BottomResizer";
			this.BottomResizer.Size = new System.Drawing.Size(1092, 3);
			this.BottomResizer.TabIndex = 0;
			this.BottomResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resizer_Mouse_Down);
			this.BottomResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resizer_Down);
			// 
			// TopResizer
			// 
			this.TopResizer.BackColor = System.Drawing.Color.Transparent;
			this.TopResizer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.TopResizer.Cursor = System.Windows.Forms.Cursors.SizeNS;
			this.TopResizer.Location = new System.Drawing.Point(3, 0);
			this.TopResizer.Name = "TopResizer";
			this.TopResizer.Size = new System.Drawing.Size(1095, 3);
			this.TopResizer.TabIndex = 3;
			this.TopResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resizer_Mouse_Down);
			this.TopResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resizer_Up);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1098, 611);
			this.Controls.Add(this.TopResizer);
			this.Controls.Add(this.BottomResizer);
			this.Controls.Add(this.RightResizer);
			this.Controls.Add(this.LeftResizer);
			this.Controls.Add(this.TopBar_BG);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "VIBES";
			this.TopBar_BG.ResumeLayout(false);
			this.ResumeLayout(false);
=======
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.CurrentTime = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.TrackBar();
            this.TotalTime = new System.Windows.Forms.Label();
            this.VolumeLabel = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(399, 53);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Play";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(348, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "DJ Paul Elstak - Demons";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(507, 53);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 2;
            this.button2.Text = "Pause";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(615, 53);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 3;
            this.button3.Text = "Stop";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // CurrentTime
            // 
            this.CurrentTime.AutoSize = true;
            this.CurrentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.CurrentTime.Location = new System.Drawing.Point(295, 89);
            this.CurrentTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CurrentTime.Name = "CurrentTime";
            this.CurrentTime.Size = new System.Drawing.Size(51, 25);
            this.CurrentTime.TabIndex = 4;
            this.CurrentTime.Text = "0:00";
            this.CurrentTime.Click += new System.EventHandler(this.CurrentTime_Click);
            // 
            // Time
            // 
            this.Time.Location = new System.Drawing.Point(356, 89);
            this.Time.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(412, 56);
            this.Time.TabIndex = 7;
            this.Time.TickFrequency = 0;
            this.Time.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // TotalTime
            // 
            this.TotalTime.AutoSize = true;
            this.TotalTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TotalTime.Location = new System.Drawing.Point(776, 89);
            this.TotalTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TotalTime.Name = "TotalTime";
            this.TotalTime.Size = new System.Drawing.Size(51, 25);
            this.TotalTime.TabIndex = 8;
            this.TotalTime.Text = "0:00";
            this.TotalTime.Click += new System.EventHandler(this.TotalTime_Click);
            // 
            // VolumeLabel
            // 
            this.VolumeLabel.AutoSize = true;
            this.VolumeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.VolumeLabel.Location = new System.Drawing.Point(521, 123);
            this.VolumeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.VolumeLabel.Name = "VolumeLabel";
            this.VolumeLabel.Size = new System.Drawing.Size(65, 20);
            this.VolumeLabel.TabIndex = 9;
            this.VolumeLabel.Text = "Volume";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(356, 151);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(412, 56);
            this.trackBar1.TabIndex = 10;
            this.trackBar1.TickFrequency = 5;
            this.trackBar1.Value = 100;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 274);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1033, 22);
            this.textBox1.TabIndex = 11;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(16, 308);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(1035, 28);
            this.button4.TabIndex = 12;
            this.button4.Text = "Download";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(503, 340);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "No video";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(16, 238);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(1035, 28);
            this.button6.TabIndex = 15;
            this.button6.Text = "Upload";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.VolumeLabel);
            this.Controls.Add(this.TotalTime);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.CurrentTime);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
>>>>>>> c5d66c1e5e8d1db8e3057430f3e7978ba8a9a077

		}

		#endregion
<<<<<<< HEAD
		private System.Windows.Forms.Panel TopResizer;
		private System.Windows.Forms.Panel TopBar_BG;
		private System.Windows.Forms.Panel LeftResizer;
		private System.Windows.Forms.Panel RightResizer;
		private System.Windows.Forms.Panel BottomResizer;
		private System.Windows.Forms.Label Title;
	}
=======

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label CurrentTime;
		private System.Windows.Forms.TrackBar Time;
		private System.Windows.Forms.Label TotalTime;
		private System.Windows.Forms.Label VolumeLabel;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
>>>>>>> c5d66c1e5e8d1db8e3057430f3e7978ba8a9a077
}

