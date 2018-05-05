/*
 * (c) Abel Dieterich - HotkeyCode Inc.
 */

using System;
using System.IO;
using System.Net;
using System.Drawing;
using System.Threading;
using NAudio.Wave;

namespace Windows
{
	class PlaybackEngine
	{
		#region Delegates
		public delegate void onNewSong(string title, string artists, Image cover, string totaltime);
		public onNewSong OnNewSong;

		public delegate void onTimeChanged(TimeSpan time);
		public onTimeChanged OnTimeChanged;
		#endregion

		#region Variables
		public float currentPosition = 0f;
		MediaFoundationReader mf;
		WaveOutEvent wo;
		string streamID = "";
		string streamURL = "";
		const string streamServer = "http://ablos.square7.ch/";
		#endregion

		#region Constructor and Deconstructor
		public PlaybackEngine()
		{
			wo = new WaveOutEvent();
		}
		#endregion

		#region Public functions
		public void StartNewSong(string url)
		{
			if (File.Exists(url))
				InitiateLocalStream(url);
			else
				InitiateWebStream(url);
		}

		/// <summary>
		/// Pause or unpause the stream.
		/// </summary>
		public void PauseStream()
		{
			if (wo.PlaybackState == PlaybackState.Playing) wo.Pause();
			else if (wo.PlaybackState == PlaybackState.Paused) wo.Play();
		}

		/// <summary>
		/// Stop the audio stream.
		/// </summary>
		public void StopStream()
		{
			wo.Stop();
			DeleteStream();
		}

		/// <summary>
		/// Set the volume of the playback. Accepts a value between 0 and 1.
		/// </summary>
		/// <param name="volume"></param>
		public void SetVolume(float volume)
		{
			wo.Volume = Clamp(volume, 0f, 1f);
		}

		/// <summary>
		/// Get the volume of the playback.
		/// </summary>
		public float GetVolume()
		{
			return wo.Volume;
		}

		/// <summary>
		/// Get the total time of the currently playing song. Returns a TimeSpan.
		/// </summary>
		/// <returns></returns>
		public TimeSpan GetTotalTime()
		{
			if (mf != null)
			{
				return mf.TotalTime;
			}
			return new TimeSpan(0, 0, 0);
		}

		/// <summary>
		/// Skip the given amount of seconds in the track.
		/// </summary>
		/// <param name="seconds"></param>
		public void Skip(int seconds)
		{
			if (mf != null)
			{
				mf.Skip(seconds);
			}
		}

		#endregion

		#region Private functions
		/// <summary>
		/// Create a new audio stream from local file.
		/// </summary>
		/// <param name="Path"></param>
		private void InitiateLocalStream(string path)
		{
			streamURL = path;
			StreamMusic();
			TagLib.File f = TagLib.File.Create(path);
			string seconds = f.Properties.Duration.Seconds.ToString();
			if (seconds.Length == 1)
				seconds = "0" + seconds;
			OnNewSong?.Invoke(f.Tag.Title, f.Tag.FirstPerformer, Image.FromStream(new MemoryStream(f.Tag.Pictures[0].Data.Data)), f.Properties.Duration.Minutes.ToString() + ":" + seconds);
		}

		/// <summary>
		/// Create a new audio stream from URL.
		/// </summary>
		/// <param name="WebDAV URL"></param>
		private void InitiateWebStream(string webDavURL)
		{
			PruneServer();
			WebClient webClient = new WebClient();
			string response = "";
			try
			{
				response = webClient.DownloadString(streamServer + "stream.php?pass=AblosStream00&url=" + webDavURL);
			}
			catch { }

			if (!string.IsNullOrEmpty(response))
			{
				string[] parts = response.Split(':');
				if (parts[0] == "ERROR")
				{
					Console.WriteLine("ERROR while trying to stream: " + parts[1]);
				}
				else if (parts[0] == "StreamID")
				{
					parts[1] = parts[1].Trim();
					Console.WriteLine("Stream ID: " + parts[1]);
					streamURL = streamServer + "streams/" + parts[1] + ".mp3";
					streamID = parts[1];
					StreamMusic();
				}
				else
				{
					Console.WriteLine("Unknown response: " + response);
				}
			}
		}

		private void StreamMusic()
		{
			new Thread(() =>
			{
				Console.WriteLine("Starting stream at: " + streamURL);
				mf = new MediaFoundationReader(streamURL);
				wo.Init(mf);
				wo.Play();
				while (wo.PlaybackState == PlaybackState.Playing)
				{
					OnTimeChanged?.Invoke(mf.CurrentTime);
					Thread.Sleep(1);
				}

				if (wo.PlaybackState == PlaybackState.Stopped)
				{
					DeleteStream();
				}
			}).Start();
		}

		private void DeleteStream()
		{
			new Thread(() =>
			{
				if (!string.IsNullOrEmpty(streamID))
				{
					WebClient web = new WebClient();
					try
					{
						web.DownloadString(streamServer + "delete.php?pass=AblosStream00&id=" + streamID);
					}
					catch { }
				}

				streamURL = "";
				streamID = "";
			}).Start();
		}

		private void PruneServer()
		{
			new Thread(() =>
			{
				WebClient web = new WebClient();
				try
				{
					web.DownloadString(streamServer + "prune.php?pass=AblosStream00");
				}
				catch { }
			}).Start();
		}

		private float Clamp(float val, float min, float max)
		{
			if (val.CompareTo(min) < 0) return min;
			else if (val.CompareTo(max) > 0) return max;
			else return val;
		}
		#endregion
	}
}
