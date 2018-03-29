using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "MP3 music files|*.mp3";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fileLocation = textBox1.Text.Trim();

            if (File.Exists(fileLocation))
            {
                TagLib.File f = TagLib.File.Create(fileLocation);

                string artists = "";
                foreach (string s in f.Tag.Performers)
                {
                    if (artists == "")
                    {
                        artists += s;
                    } else
                    {
                        artists += "," + s;
                    }
                }

                textBox2.Text = f.Tag.Title;
                textBox3.Text = f.Tag.Album;
                textBox4.Text = f.Tag.Genres[0];
                textBox5.Text = artists;

                panel1.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = true;

                byte[] image = GetImage(GetCoverImageUrl(textBox2.Text, textBox5.Text));
                using (var ms = new MemoryStream(image))
                {
                    pictureBox1.Image = Image.FromStream(ms);
                    pictureBox2.Image = Image.FromStream(ms);
                }
            }

        }

        private string GetCoverImageUrl(string title, string artists)
        {
            string googleUrl = "https://www.google.com/search?q=" + title + " " + artists.Replace(",", " ") + " cover&tbm=isch";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(googleUrl);
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";

            string html = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();

            int ndx = html.IndexOf("\"ou\"", StringComparison.Ordinal);
            ndx = html.IndexOf("\"", ndx + 4, StringComparison.Ordinal);
            ndx++;
            int ndx2 = html.IndexOf("\"", ndx, StringComparison.Ordinal);
            string url = html.Substring(ndx, ndx2 - ndx);
            return url;
        }

        private byte[] GetImage(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                if (dataStream == null)
                    return null;
                using (var sr = new BinaryReader(dataStream))
                {
                    byte[] bytes = sr.ReadBytes(100000000);

                    return bytes;
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\MusicStreamer\\OutgoingTemp"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\MusicStreamer\\OutgoingTemp");
            }
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\MusicStreamer\\YoutubeTemp"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\MusicStreamer\\YoutubeTemp");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Supported Images|*.bmp;*.jpg;*.jpeg;*.png";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(dialog.FileName);
                pictureBox2.Image = Image.FromFile(dialog.FileName);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
        }
    }
}
