using System;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;
using NReco.VideoConverter;
using NAudio.Wave;
using NAudio.Lame;

namespace Windows
{
	class YoutubeAudioDownloader
	{
		private class Video
		{
			public string title = "";
			public string thumbnail = "";
			public URL[] urls = new URL[0];

			public class URL
			{
				public string label = "";
				public string id = "";
				public string size = "";
			}
		}

		public WebClient wc;
		Video video;
		public FFMpegConverter ffmpeg;
		public enum State { INACTIVE, VALIDATING_URL, VALIDATING_PATH, COLLECTING_URL, CREATING_DIR, DOWNLOADING_VIDEO, CREATING_LOW, CREATING_NORMAL, CREATING_HIGH, CREATING_ULTRA, CLEANING, DONE };
		public delegate void OnStateChanged(State state);
		public OnStateChanged onStateChanged;

		public YoutubeAudioDownloader()
		{
			wc = new WebClient();
			ffmpeg = new FFMpegConverter();
			onStateChanged?.Invoke(State.INACTIVE);
		}

		private bool ValidateYoutubeURL(string url)
		{
			try
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
				request.Method = "HEAD";
				using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
				{
					return response.ResponseUri.ToString().Contains("youtube.com");
				}
			}
			catch
			{
				return false;
			}
		}

		private string GetVideoURL(string url)
		{
			video = JsonConvert.DeserializeObject<Video>(wc.DownloadString("https://www.saveitoffline.com/process/?url=" + url + "&type=json"));
			return video.urls[0].id;
		}

		private string CleanPath(string directory, string dirname)
		{
			dirname = Regex.Unescape(dirname);

			foreach (char c in Path.GetInvalidPathChars())
			{
				dirname = dirname.Replace(c, ' ');
			}

			return directory + "/" + dirname;
		}

		public void CreateMP3s(string dir)
		{
			onStateChanged?.Invoke(State.CREATING_ULTRA);
			ffmpeg.ConvertMedia(dir + "/video.mp4", null, dir + "/ultra.mp3", "mp3", new ConvertSettings()
			{
				CustomOutputArgs = " -b:a 320k -bufsize 320k "
			});

			Mp3FileReader reader = new Mp3FileReader(dir + "/ultra.mp3");

			onStateChanged?.Invoke(State.CREATING_HIGH);
			LameMP3FileWriter high = new LameMP3FileWriter(dir + "/high.mp3", reader.WaveFormat, 256);
			reader.CopyTo(high);

			onStateChanged?.Invoke(State.CREATING_NORMAL);
			LameMP3FileWriter normal = new LameMP3FileWriter(dir + "/normal.mp3", reader.WaveFormat, 128);
			reader.CopyTo(normal);

			onStateChanged?.Invoke(State.CREATING_LOW);
			LameMP3FileWriter low = new LameMP3FileWriter(dir + "/low.mp3", reader.WaveFormat, 64);
			reader.CopyTo(low);
		}

		public string DownloadAudio(string youtubeURL, string directory)
		{
			onStateChanged?.Invoke(State.VALIDATING_URL);
			if (!ValidateYoutubeURL(youtubeURL))
				return "invalid|url";
			onStateChanged?.Invoke(State.VALIDATING_PATH);
			if (!Directory.Exists(directory))
				return "invalid|path";

			onStateChanged?.Invoke(State.COLLECTING_URL);
			string url = GetVideoURL(youtubeURL);
			onStateChanged?.Invoke(State.CREATING_DIR);
			string dir = CleanPath(directory, video.title);
			int counter = 0;
			string oDir = dir;
			bool successDir = false;
			while (!successDir)
			{
				if (counter > 0)
				{
					dir = oDir + " (" + counter.ToString() + ")";
				}

				if (Directory.Exists(dir))
				{
					counter++;
				}
				else
				{
					try
					{
						Directory.CreateDirectory(dir);
						successDir = true;
					}
					catch
					{
						counter++;
					}
				}
			}

			onStateChanged?.Invoke(State.DOWNLOADING_VIDEO);
			wc.DownloadFile(new Uri(url), dir + "/video.mp4");

			CreateMP3s(dir);

			onStateChanged?.Invoke(State.CLEANING);
			File.Delete(dir + "/video.mp4");

			onStateChanged?.Invoke(State.DONE);
			return "success|" + dir;
		}
	}
}
