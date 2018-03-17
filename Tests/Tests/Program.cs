using System;


namespace Tests
{
	class Program
	{
		static void Main(string[] args)
		{
			AudioStreamer a = new AudioStreamer();
			a.InitiateLocalStream("C:\\Users\\Abel\\Desktop\\test.mp3");
			Console.WriteLine("End of script.");
			Console.ReadLine();
		}
	}
}
