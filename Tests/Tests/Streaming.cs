using System;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using WebDAVClient;
using NAudio.Wave;
using System.IO;

namespace Tests
{
	class Streaming
	{
		IClient c;

		public async void Initialize()
		{
			c = new Client(new NetworkCredential { UserName = "ablos", Password = "AblosStack00" });
			c.Server = "https://ablos.stackstorage.com/";
			c.BasePath = "/remote.php/webdav/";
			await fetchFiles();
		}

		private async Task fetchFiles()
		{
			var files = await c.List();

			foreach (var file in files)
			{
				Console.WriteLine("Found file: " + file.DisplayName);
				WebClient webClient = new WebClient();
				string response = "";
				try
				{
					response = webClient.DownloadString("http://ablos.square7.ch/stream.php?pass=AblosStream00&url=" + file.Href);
				}catch { }

				if (!string.IsNullOrEmpty(response))
				{
					string[] parts = response.Split(':');
					if (parts[0] == "ERROR")
					{
						Console.WriteLine("ERROR while trying to stream: " + parts[1]);
					}else if (parts[0] == "StreamID")
					{
						Console.WriteLine("Stream ID: " + parts[1]);
						string url = "http://ablos.square7.ch/streams/" + parts[1] + ".mp3";
						Console.WriteLine(url);
						Thread.Sleep(3000);
						using (var mf = new MediaFoundationReader(url))
						using (var wo = new WaveOutEvent())
						{
							wo.Init(mf);
							wo.Play();
							while (wo.PlaybackState == PlaybackState.Playing)
							{
								Thread.Sleep(1000);
							}
						}
					}
					else
					{
						Console.WriteLine("Unknown response: " + response);
					}
				}
			}
		}
	}
}
