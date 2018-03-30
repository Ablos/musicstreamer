using System;
using WindowsInput;
using System.Threading;

namespace Tests
{
	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				InputSimulator.SimulateKeyDown(VirtualKeyCode.VK_W);
				Thread.Sleep(100);
				InputSimulator.SimulateKeyUp(VirtualKeyCode.VK_W);
				Thread.Sleep(2000);
				InputSimulator.SimulateKeyDown(VirtualKeyCode.VK_S);
				Thread.Sleep(100);
				InputSimulator.SimulateKeyUp(VirtualKeyCode.VK_S);
			}

			YoutubeAudioDownloader dl = new YoutubeAudioDownloader();
			Console.WriteLine(dl.DownloadVideo(Console.ReadLine(), "C:\\Users\\Abel\\Desktop"));
			Console.WriteLine("End of script.");
			Console.ReadLine();
		}
	}
}
