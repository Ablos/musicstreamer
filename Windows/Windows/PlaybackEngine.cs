/*
 * (c) Abel Dieterich - HotkeyCode Inc.
 */

using System;
using System.IO;
using System.Net;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Collections.Generic;
using NAudio.Wave;
using WebDav;
using Newtonsoft.Json;

namespace Windows
{
	// Settings for playback
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

		public static PlaybackCache cache;
	}

	public class PlaybackEngine
	{
		#region Delegates
		public delegate void onNewSong(SongInfo info, Image cover, bool unpause);
		public onNewSong OnNewSong;

		public delegate void onSongPause();
		public onSongPause OnSongPause;

		public delegate void onTimeChanged(TimeSpan time);
		public onTimeChanged OnTimeChanged;

		public delegate void onSongEnd();
		public onSongEnd OnSongEnd;
		#endregion

		#region Variables
		public float currentPosition = 0f;
		StreamMediaFoundationReader mf;
		WaveOutEvent wo;
		bool stop = false;
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
		public void StartNewSong(string url, float startPercentage = 0f, bool pauseOnStart = false)
		{
			StopStream();
			stop = false;
			if (File.Exists(url))
				InitiateLocalStream(url, startPercentage, pauseOnStart);
			else
				InitiateWebStream(url, startPercentage, pauseOnStart);
		}

		/// <summary>
		/// Pause or unpause the stream.
		/// </summary>
		public void PauseStream()
		{
			if (wo.PlaybackState == PlaybackState.Playing) { wo.Pause(); OnSongPause?.Invoke(); }
			else if (wo.PlaybackState == PlaybackState.Paused) wo.Play();
		}

		/// <summary>
		/// Stop the audio stream.
		/// </summary>
		public void StopStream()
		{
			stop = true;
			wo.Stop();
		}

		/// <summary>
		/// Set the volume of the playback. Accepts a value between 0 and 1.
		/// </summary>
		/// <param name="volume"></param>
		public void SetVolume(float volume)
		{
			wo.Volume = Clamp(volume, 0f, 1f);
			PlaybackSettings.cache.volume = volume;
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
			return PlaybackSettings.cache.songCache.info.duration;
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
			OnTimeChanged?.Invoke(GetCurrentTime());
		}

		#endregion

		#region Private functions
		/// <summary>
		/// Create a new audio stream from local file.
		/// </summary>
		/// <param name="Path"></param>
		private void InitiateLocalStream(string path, float startPercentage, bool pauseOnStart)
		{
			StreamMusic(path, startPercentage, pauseOnStart, true);
			TagLib.File f = TagLib.File.Create(path);
			SongInfo info = new SongInfo(f.Tag.Title, f.Tag.FirstPerformer, f.Properties.Duration, f.Tag.FirstGenre, f.Tag.Album);
			Image cover = Image.FromStream(new MemoryStream(f.Tag.Pictures[0].Data.Data));

			PlaybackSettings.cache.songCache = new SongCache(info, cover, f.Tag.Lyrics, path);
			PlaybackSettings.cache.timebarPercentage = 0f;

			OnNewSong?.Invoke(info, cover, !pauseOnStart);
		}

		/// <summary>
		/// Create a new audio stream from URL.
		/// </summary>
		/// <param name="WebDAV URL"></param>
		private async void InitiateWebStream(string webDavURL, float startPercentage, bool pauseOnStart)
		{
			StreamMusic(webDavURL, startPercentage, pauseOnStart, false);

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

			PlaybackSettings.cache.songCache = new SongCache(info, cover, webDavURL);
			PlaybackSettings.cache.timebarPercentage = 0f;

			OnNewSong?.Invoke(info, cover, !pauseOnStart);
		}

		private void StreamMusic(string URL, float startPercentage, bool pauseOnStart, bool isLocal)
		{
			new Thread(() =>
			{
				Console.WriteLine("Starting stream at: " + URL);

				if (!isLocal)
				{
					string url = URL;

					if (PlaybackSettings.streamQuality == PlaybackSettings.StreamQuality.HIGH)
						url += "/high.mp3";
					else
						url += "/low.mp3";

					//initializes a new WEBDAV client
					WebDavClientParams clientParams = new WebDavClientParams()
					{
						BaseAddress = new Uri("https://ablos.stackstorage.com/remote.php/webdav/"),
						Credentials = new NetworkCredential("ablos", "AblosStack00")
					};
					WebDavClient wClient = new WebDavClient(clientParams);

					//DateTime s = DateTime.Now; // Save the time
					mf = new StreamMediaFoundationReader(wClient.GetRawFile(url).Result.Stream);
					//Console.WriteLine(DateTime.Now - s); // Subtract the old time from current time and write out to see how long it took to load stream
				}
				else
				{
					mf = new StreamMediaFoundationReader(File.OpenRead(URL));
				}

				wo.Init(mf);
				wo.Play();
				GotoPercentage(startPercentage);
				if (pauseOnStart)
					PauseStream();

				while (wo.PlaybackState == PlaybackState.Playing || wo.PlaybackState == PlaybackState.Paused)
				{
					if (wo.PlaybackState == PlaybackState.Playing)
						try { OnTimeChanged?.Invoke(mf.CurrentTime); } catch { }
				}

				if (wo.PlaybackState == PlaybackState.Stopped)
				{
					try { OnSongEnd?.Invoke(); }catch { }

					if (PlaybackSettings.repeatState == PlaybackSettings.RepeatState.REPEAT_ONE && !stop)
					{
						StartNewSong(URL);
					}

					stop = false;
				}
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

	[Serializable]
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

	[Serializable]
	public class SongCache
	{
		public SongInfo info;
		public Image cover;
		public string webDavPath;
		public string localPath;

		public SongCache(SongInfo info, Image cover, string webDavPath, string localPath = null)
		{
			this.info = info;
			this.cover = cover;
			this.webDavPath = webDavPath;
			this.localPath = localPath;
		}
	}

	[Serializable]
	public class PlaybackCache
	{
		public SongCache songCache;
		public List<SongCache> queue;
		public float volume;
		public float timebarPercentage;
	}
}
