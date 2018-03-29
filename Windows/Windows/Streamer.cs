/*
 * (c) HotkeyCode Inc.
 */

using System;
using System.Threading;
using System.Net;
using NAudio.Wave;

namespace Windows
{
	public class Streamer
	{
		#region Variables
		public float currentPosition = 0f;
		MediaFoundationReader mf;
		WaveOutEvent wo;
		string streamID = "";
		string streamURL = "";
		const string streamServer = "http://ablos.square7.ch/";
		#endregion

		#region Constructor and Destructor
		public Streamer()
		{
			wo = new WaveOutEvent();
		}

		~Streamer()
		{
			DeleteStream();
		}
		#endregion

		#region Public functions
		/// <summary>
		/// Create a new audio stream from URL.
		/// </summary>
		/// <param name="WebDAV URL"></param>
		public void InitiateWebStream(string webDavURL)
		{
			PruneServer();
			webDavURL = CreateCompatibleURL(webDavURL);
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

		/// <summary>
		/// Create a new audio stream from local file.
		/// </summary>
		/// <param name="Path"></param>
		public void InitiateLocalStream(string path)
		{
			streamURL = path;
			StreamMusic();
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
		/// Return the current time of the track.
		/// </summary>
		/// <returns></returns>
		public TimeSpan GetCurrentTime()
		{
			if (mf != null)
			{
				return mf.CurrentTime;
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
		private string CreateCompatibleURL(string url)
		{
			url = url.Replace(" ", "%20");
			url = url.Replace("&", "%26");

			return url;
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
					Thread.Sleep(100);
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
