using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AudioStreamer;

namespace Windows
{
	public partial class Form1 : Form
	{
		Streamer s;
		public Form1()
		{
			InitializeComponent();
			s = new Streamer();
			new Thread(() =>
			{
				while (true)
				{
					loop();
					Thread.Sleep(100);
				}
			}).Start();
		}

		private void loop()
		{
			CurrentTime.BeginInvoke(new Action(() =>
			{
				CurrentTime.Text = s.GetCurrentTime().ToString(@"m\:ss");
			}));
			Time.BeginInvoke(new Action(() =>
			{
				Time.Value = s.GetCurrentTime().Seconds + (s.GetCurrentTime().Minutes * 60);
			}));
		}

		private void button1_Click(object sender, EventArgs e)
		{
			s.InitiateWebStream("Music/DJ_Paul_Elstak/Demons/ultra.mp3");
			Thread.Sleep(1000);
			TotalTime.Text = s.GetTotalTime().ToString(@"m\:ss");
			Time.Maximum = s.GetTotalTime().Seconds + (s.GetTotalTime().Minutes * 60);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			s.PauseStream();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			s.StopStream();
		}

		private void TotalTime_Click(object sender, EventArgs e)
		{

		}

		private void CurrentTime_Click(object sender, EventArgs e)
		{
			
		}
	}
}
