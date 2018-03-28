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
			((System.ComponentModel.ISupportInitialize)(this.Time)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(299, 43);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Play";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
			this.label1.Location = new System.Drawing.Point(261, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(315, 31);
			this.label1.TabIndex = 1;
			this.label1.Text = "DJ Paul Elstak - Demons";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(380, 43);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Pause";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(461, 43);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 3;
			this.button3.Text = "Stop";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// CurrentTime
			// 
			this.CurrentTime.AutoSize = true;
			this.CurrentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.CurrentTime.Location = new System.Drawing.Point(221, 72);
			this.CurrentTime.Name = "CurrentTime";
			this.CurrentTime.Size = new System.Drawing.Size(40, 20);
			this.CurrentTime.TabIndex = 4;
			this.CurrentTime.Text = "0:00";
			this.CurrentTime.Click += new System.EventHandler(this.CurrentTime_Click);
			// 
			// Time
			// 
			this.Time.Location = new System.Drawing.Point(267, 72);
			this.Time.Name = "Time";
			this.Time.Size = new System.Drawing.Size(309, 45);
			this.Time.TabIndex = 7;
			this.Time.TickFrequency = 0;
			this.Time.TickStyle = System.Windows.Forms.TickStyle.None;
			// 
			// TotalTime
			// 
			this.TotalTime.AutoSize = true;
			this.TotalTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.TotalTime.Location = new System.Drawing.Point(582, 72);
			this.TotalTime.Name = "TotalTime";
			this.TotalTime.Size = new System.Drawing.Size(40, 20);
			this.TotalTime.TabIndex = 8;
			this.TotalTime.Text = "0:00";
			this.TotalTime.Click += new System.EventHandler(this.TotalTime_Click);
			// 
			// VolumeLabel
			// 
			this.VolumeLabel.AutoSize = true;
			this.VolumeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.VolumeLabel.Location = new System.Drawing.Point(391, 100);
			this.VolumeLabel.Name = "VolumeLabel";
			this.VolumeLabel.Size = new System.Drawing.Size(55, 17);
			this.VolumeLabel.TabIndex = 9;
			this.VolumeLabel.Text = "Volume";
			// 
			// trackBar1
			// 
			this.trackBar1.Location = new System.Drawing.Point(267, 123);
			this.trackBar1.Maximum = 100;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(309, 45);
			this.trackBar1.TabIndex = 10;
			this.trackBar1.TickFrequency = 5;
			this.trackBar1.Value = 100;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(12, 223);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(776, 20);
			this.textBox1.TabIndex = 11;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(12, 250);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(776, 23);
			this.button4.TabIndex = 12;
			this.button4.Text = "button4";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(377, 276);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 13;
			this.label2.Text = "label2";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
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
	}
}

