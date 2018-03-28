using System;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;

namespace Tests
{
	class YoutubeVideoDownloader
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
			}catch
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

		private string CleanPath(string directory, string filename)
		{
			filename = Regex.Unescape(filename);

			foreach (char c in Path.GetInvalidFileNameChars())
			{
				filename = filename.Replace(c, ' ');
			}

			return directory + "/" + filename + ".mp4";
		}

		public string DownloadVideo(string youtubeURL, string directory)
		{
			if (!ValidateYoutubeURL(youtubeURL))
				return "invalid|url";
			if (!Directory.Exists(directory))
				return "invalid|path";

			WebClient wc = new WebClient();
			wc.DownloadFile(new Uri(GetVideoURL(youtubeURL)), CleanPath(directory, video.title));

			return "success|" + CleanPath(directory, video.title);
		}
	}
}
