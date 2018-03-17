using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AudioStreamer;

namespace Windows
{
	public partial class Form1 : Form
	{
		Streamer s;
		public Form1()
		{
			InitializeComponent();
			s = new Streamer();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			s.InitiateWebStream("Music/DJ_Paul_Elstak/Demons/ultra.mp3");
		}

		private void button2_Click(object sender, EventArgs e)
		{
			s.PauseStream();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			s.StopStream();
		}
	}
}
