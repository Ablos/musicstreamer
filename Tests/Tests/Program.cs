using System;


namespace Tests
{
	class Program
	{
		static void Main(string[] args)
		{
			YoutubeAudioDownloader dl = new YoutubeAudioDownloader();
			Console.WriteLine(dl.DownloadVideo(Console.ReadLine(), "C:\\Users\\Abel\\Desktop"));
			Console.WriteLine("End of script.");
			Console.ReadLine();
		}
	}
}
