using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using System.Windows.Forms;

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
					try
					{
						loop();
					}catch { }
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

		private void button4_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(textBox1.Text))
			{
				new Thread(() =>
				{
					YoutubeAudioDownloader dl = new YoutubeAudioDownloader();
					dl.DownloadAudio(textBox1.Text, "C:/Users/Abel/Desktop");
					dl.onStateChanged += UpdateDownloadState;
					dl.wc.DownloadProgressChanged += UpdateDownloadProgress;
					dl.wc.DownloadFileCompleted += FinishedDownloadProgress;
				}).Start();
			}
		}

		private void UpdateConvertProgress(object sender, NReco.VideoConverter.ConvertProgressEventArgs e)
		{
			progressBar1.Value = (int)e.TotalDuration.TotalSeconds - (int)e.Processed.TotalSeconds;
		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

<<<<<<< HEAD
		private void UpdateDownloadProgress(object sender, DownloadProgressChangedEventArgs e)
		{
			progressBar1.Value = e.ProgressPercentage;
		}

		private void FinishedDownloadProgress(object sender, AsyncCompletedEventArgs e)
		{
			progressBar1.Value = 0;
		}

		private void UpdateDownloadState(YoutubeAudioDownloader.State state)
		{
			Console.WriteLine("Working");
			switch (state)
			{
				case YoutubeAudioDownloader.State.VALIDATING_URL:
					label2.Text = "Validating URL...";
					break;
				case YoutubeAudioDownloader.State.VALIDATING_PATH:
					label2.Text = "Validating path...";
					break;
				case YoutubeAudioDownloader.State.COLLECTING_URL:
					label2.Text = "Collecting URL...";
					break;
				case YoutubeAudioDownloader.State.CREATING_DIR:
					label2.Text = "Creating directory...";
					break;
				case YoutubeAudioDownloader.State.DOWNLOADING_VIDEO:
					label2.Text = "Downloading video...";
					break;
				case YoutubeAudioDownloader.State.CREATING_LOW:
					label2.Text = "Creating low quality MP3...";
					break;
				case YoutubeAudioDownloader.State.CREATING_NORMAL:
					label2.Text = "Creating normal quality MP3...";
					break;
				case YoutubeAudioDownloader.State.CREATING_HIGH:
					label2.Text = "Creating high quality MP3...";
					break;
				case YoutubeAudioDownloader.State.CREATING_ULTRA:
					label2.Text = "Creating ultra quality MP3...";
					break;
				case YoutubeAudioDownloader.State.CLEANING:
					label2.Text = "Cleaning up...";
					break;
				case YoutubeAudioDownloader.State.DONE:
					label2.Text = "DONE!";
					break;
				default:
					label2.Text = "Invactive";
					break;
			}
		}

		private void progressBar1_Click(object sender, EventArgs e)
		{

		}
	}
=======
        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }
    }
>>>>>>> 1534013d8e4915cde7334590be9eac1b9b689574
}
