using System;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using WebDAVClient;
using NAudio.Wave;
using System.IO;

namespace Tests
{
	class Program
	{
		IClient c;

		#region Main
		static void Main(string[] args)
		{
			Program p = new Program();
			p.Initialize();
			Console.ReadLine();
		}
		#endregion

		private async void Initialize()
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
				FileStream f = File.OpenWrite("C:\\Users\\Abel\\Desktop\\song.mp3");
				Stream s = await c.Download(file.Href);
				s.CopyTo(f);

				using (var audioFile = new AudioFileReader("C:\\Users\\Abel\\Desktop\\song.mp3"))
				using (var outputDevice = new WaveOutEvent())
				{
					outputDevice.Init(audioFile);
					outputDevice.Play();
					while (outputDevice.PlaybackState == PlaybackState.Playing)
					{
						Thread.Sleep(1000);
					}
				}
			}
		}
	}
}
