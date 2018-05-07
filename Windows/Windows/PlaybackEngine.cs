/*
 * (c) Abel Dieterich - HotkeyCode Inc.
 */

using System;
using System.IO;
using System.Net;
using System.Drawing;
using System.Threading;
using System.Text;
using NAudio.Wave;
using WebDav;
using Newtonsoft.Json;

namespace Windows
{
	public static class PlaybackSettings
	{
		public enum RepeatState { NONE, REPEAT_ALL, REPEAT_ONE };

		public static bool shuffle = false;
		public static RepeatState repeatState = RepeatState.NONE;
		public static bool isPaused = true;
		public static float volume = 100f;

		public enum StreamQuality { LOW, HIGH };
		public static StreamQuality streamQuality = StreamQuality.HIGH;

		public static bool edittingTime = false;
		public static bool timeSelected = false;

		public static bool edittingVolume = false;
		public static bool volumeSelected = false;

		public static string title = "";
		public static string artists = "";
	}

	public class PlaybackEngine
	{
		#region Delegates
		public delegate void onNewSong(SongInfo info, Image cover);
		public onNewSong OnNewSong;

		public delegate void onTimeChanged(TimeSpan time);
		public onTimeChanged OnTimeChanged;

		public delegate void onSongEnd();
		public onSongEnd OnSongEnd;
		#endregion

		#region Variables
		public float currentPosition = 0f;
		MediaFoundationReader mf;
		WaveOutEvent wo;
		string streamID = "";
		string streamURL = "";
		const string streamServer = "http://ablos.square7.ch/";
		bool stop = false;
		bool startedPlaying = false;
		#endregion

		#region Constructor and Deconstructor
		public PlaybackEngine()
		{
			wo = new WaveOutEvent();
		}

		~PlaybackEngine()
		{
			StopStream();
		}
		#endregion

		#region Public functions
		public void StartNewSong(string url)
		{
			StopStream();
			stop = false;
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
			stop = true;
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
		public TimeSpan GetTotalTime()
		{
			if (mf != null)
			{
				return mf.TotalTime;
			}
			return new TimeSpan(0, 0, 0);
		}

		/// <summary>
		/// Get the current time of the currently playing song. Returns a TimeSpan.
		/// </summary>
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

		/// <summary>
		/// Go to the given percentage of the track.
		/// </summary>
		/// <param name="Percentage"></param>
		public void GotoPercentage(float percentage)
		{
			float totalMilliseconds = (float)GetTotalTime().TotalSeconds;
			int timeToGoto = (int)(totalMilliseconds * (percentage / 100f));
			Skip(timeToGoto - (int)GetCurrentTime().TotalSeconds);
		}

		#endregion

		#region Private functions
		/// <summary>
		/// Create a new audio stream from local file.
		/// </summary>
		/// <param name="Path"></param>
		private void InitiateLocalStream(string path)
		{
			startedPlaying = false;

			streamURL = path;
			streamID = "no_id_for_local_file";
			StreamMusic(path);
			TagLib.File f = TagLib.File.Create(path);
			SongInfo info = new SongInfo(f.Tag.Title, f.Tag.FirstPerformer, f.Properties.Duration, f.Tag.FirstGenre, f.Tag.Album);
			Image cover = Image.FromStream(new MemoryStream(f.Tag.Pictures[0].Data.Data));

			PlaybackCache.info = info;
			PlaybackCache.cover = cover;

			OnNewSong?.Invoke(info, cover);
		}

		/// <summary>
		/// Create a new audio stream from URL.
		/// </summary>
		/// <param name="WebDAV URL"></param>
		private async void InitiateWebStream(string webDavURL)
		{
			startedPlaying = false;

			PruneServer();
			WebClient webClient = new WebClient();
			string response = "";
			try
			{
				if (PlaybackSettings.streamQuality == PlaybackSettings.StreamQuality.LOW)
				{
					response = webClient.DownloadString(streamServer + "stream.php?pass=AblosStream00&url=" + webDavURL + "/low.mp3");
				}else
				{
					response = webClient.DownloadString(streamServer + "stream.php?pass=AblosStream00&url=" + webDavURL + "/high.mp3");
				}
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
					Console.WriteLine("Starting stream");
					StreamMusic(webDavURL);

					//initializes a new WEBDAV client
					WebDavClientParams clientParams = new WebDavClientParams()
					{
						BaseAddress = new Uri("https://ablos.stackstorage.com/remote.php/webdav/"),
						Credentials = new NetworkCredential("ablos", "AblosStack00")
					};
					WebDavClient wClient = new WebDavClient(clientParams);

					WebDavStreamResponse s = await wClient.GetRawFile(webDavURL + "/cover.png");

					WebDavStreamResponse r = await wClient.GetRawFile(webDavURL + "/info.json");
					SongInfo info = JsonConvert.DeserializeObject<SongInfo>(StreamToString(r.Stream));
					Image cover = Image.FromStream(s.Stream);

					OnNewSong?.Invoke(info, cover);
				}
				else
				{
					Console.WriteLine("Unknown response: " + response);
				}
			}
		}

		private void StreamMusic(string originalURL)
		{
			new Thread(() =>
			{
				Console.WriteLine("Starting stream at: " + streamURL);
				mf = new MediaFoundationReader(streamURL);
				wo.Init(mf);
				wo.Play();

				while (wo.PlaybackState == PlaybackState.Playing || wo.PlaybackState == PlaybackState.Paused)
				{
					startedPlaying = true;

					if (wo.PlaybackState == PlaybackState.Playing)
						try { OnTimeChanged?.Invoke(mf.CurrentTime); } catch { }

					Thread.Sleep(1);
				}

				if (wo.PlaybackState == PlaybackState.Stopped)
				{
					
					try { OnSongEnd?.Invoke(); }catch { }
					if (startedPlaying)
						DeleteStream();

					if (PlaybackSettings.repeatState == PlaybackSettings.RepeatState.REPEAT_ONE && !stop)
					{
						StartNewSong(originalURL);
					}

					stop = false;
				}
			}).Start();
		}

		private void DeleteStream()
		{
			string ID = streamID;
			new Thread(() =>
			{
				if (!string.IsNullOrEmpty(ID))
				{
					WebClient web = new WebClient();
					try
					{
						web.DownloadString(streamServer + "delete.php?pass=AblosStream00&id=" + ID);
					}
					catch { }
				}
			}).Start();

			streamURL = "";
			streamID = "";
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

		private string StreamToString(Stream stream)
		{
			stream.Position = 0;
			using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
			{
				return reader.ReadToEnd();
			}
		}
		#endregion
	}

	public class SongInfo
	{
		public string title;
		public string artists;
		public TimeSpan duration;
		public string genre;
		public string album;

		public SongInfo(string title, string artists, TimeSpan duration, string genre, string album)
		{
			this.title = title;
			this.artists = artists;
			this.duration = duration;
			this.genre = genre;
			this.album = album;
		}
	}

	public static class PlaybackCache
	{
		public static SongInfo info;
		public static Image cover;
		public static float currentTime;
		public static string webDavPath;
		public static string localPath;
	}
}
