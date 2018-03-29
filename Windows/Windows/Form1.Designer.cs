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
            this.button5 = new System.Windows.Forms.Button();
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
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(16, 308);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(1035, 28);
            this.button4.TabIndex = 12;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(503, 340);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(200, 441);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(146, 28);
            this.button5.TabIndex = 14;
            this.button5.Text = "Upload Track";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.button5);
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

		}

		#endregion

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
    }
}

