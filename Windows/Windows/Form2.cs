using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
