using System;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;
using NReco.VideoConverter;

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

		Video video;

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
			WebClient wc = new WebClient();
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
			FFMpegConverter ffmpeg = new FFMpegConverter();
			ffmpeg.ConvertMedia(dir + "/video.mp4", null, dir + "/low.mp3", "mp3", new ConvertSettings()
			{
				CustomOutputArgs = " -b:v 64k -bufsize 64k "
			});
			ffmpeg.ConvertMedia(dir + "/video.mp4", null, dir + "/normal.mp3", "mp3", new ConvertSettings()
			{
				CustomOutputArgs = " -b:v 128k -bufsize 128k "
			});
			ffmpeg.ConvertMedia(dir + "/video.mp4", null, dir + "/high.mp3", "mp3", new ConvertSettings()
			{
				CustomOutputArgs = " -b:v 256k -bufsize 256k "
			});
			ffmpeg.ConvertMedia(dir + "/video.mp4", null, dir + "/ultra.mp3", "mp3", new ConvertSettings()
			{
				CustomOutputArgs = " -b:v 320k -bufsize 320k "
			});
		}

		public string DownloadAudio(string youtubeURL, string directory)
		{
			if (!ValidateYoutubeURL(youtubeURL))
				return "invalid|url";
			if (!Directory.Exists(directory))
				return "invalid|path";

			WebClient wc = new WebClient();
			string url = GetVideoURL(youtubeURL);
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
			wc.DownloadFile(new Uri(url), dir + "/video.mp4");

			CreateMP3s(dir);

			return "success|" + dir;
		}
	}
}
