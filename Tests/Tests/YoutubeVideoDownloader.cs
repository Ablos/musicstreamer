using System;
using System.Net;
using Newtonsoft.Json;
using System.IO;

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

		public string DownloadVideo(string youtubeURL, string directory)
		{
			if (!ValidateYoutubeURL(youtubeURL))
				return "invalid_url";
			if (!Directory.Exists(directory))
				return "invalid_path";

			WebClient wc = new WebClient();
			wc.DownloadFile(new Uri(GetVideoURL(youtubeURL)), directory + "/" + video.title + ".mp4");

			return "success";
		}
	}
}
