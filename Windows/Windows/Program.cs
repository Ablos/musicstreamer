using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AudioStreamer;

namespace Windows
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			new Streamer().InitiateLocalStream("C:\\Users\\Abel\\Desktop\\test.mp3");
			Application.Run(new Form1());
		}
	}
}
