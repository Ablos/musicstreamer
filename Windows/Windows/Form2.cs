/*
 * (c) HotkeyCode Inc.
 */

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Lame;
using NAudio.Wave;
using WebDav;

namespace Windows
{
    public partial class Form2 : Form
    {
        #region SharedVars
        bool isYT = false;
        bool sameBitrate = false;

        string TempName = "";
        string fileLocation = "";
        string saveName = "";
        string firstArtist = "";
        string outgoingTemp = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\musicStreamer\\OutgoingTemp\\";
        string MP3Temp = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\musicStreamer\\MP3Temp\\";
        string title = "";
        string artists = "";
        string album = "";
        string genre = "";
        string duration = "";
        #endregion



        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(outgoingTemp))
            {
                Directory.CreateDirectory(outgoingTemp);
            }
            if (!Directory.Exists(MP3Temp))
            {
                Directory.CreateDirectory(MP3Temp);
            }
        }




        private void ButtonBrowseMP3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "MP3 music files|*.mp3";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.FileName;
            }
        }

        private void ButtonProcess_Click(object sender, EventArgs e)
        {
            fileLocation = textBox1.Text.Trim();
            TempName = DateTime.Now.Ticks.ToString() + ".mp3";

            isYT = fileLocation.StartsWith("https://www.youtube.com/");
            if (isYT)
            {
                button1.Click -= ButtonBrowseMP3_Click;
                button2.Click -= ButtonProcess_Click;
                textBox1.ReadOnly = true;

                Task.Run((Action)DownloadYT);
            }

            if (File.Exists(fileLocation))
            {
                button1.Click -= ButtonBrowseMP3_Click;
                button2.Click -= ButtonProcess_Click;
                textBox1.ReadOnly = true;

                ProcessFile();
            }
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            title = textBox2.Text.Trim().ToLower();
            album = textBox3.Text.Trim().ToLower();
            genre = textBox4.Text.Trim().ToLower();
            artists = textBox5.Text.Trim().ToLower();

            if (title != "" && album != "" && genre != "" && artists != "")
            {
                Task.Run((Action)FindCover);
                label10.Text = "Please Wait...";
                button4.Click -= ButtonSubmit_Click;
            }
        }

        private void ButtonBrowseCover_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Supported Images|*.bmp;*.jpg;*.jpeg;*.png";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(dialog.FileName);
                pictureBox2.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void ButtonClearCover_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = false;
        }

        private void ButtonFinish_Click(object sender, EventArgs e)
        {
            button3.Click -= ButtonFinish_Click;

            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;

            SaveCover();
            Task.Run((Action)ManageUpload);
        }




        void DownloadYT()
        {
            UpdateYTStatus("Downloading Youtube Audio...");

            try
            {
                WebClient client = new WebClient();
                client.DownloadFile(new Uri("https://www.convertmp3.io/fetch/?video=" + fileLocation), MP3Temp + TempName);
                fileLocation = MP3Temp + TempName;
                client.Dispose();


                if (new FileInfo(fileLocation).Length > 2000)
                {
                    TagLib.File f = TagLib.File.Create(MP3Temp + TempName);

                    string titleYT = f.Tag.Title;
                    string[] tmp = titleYT.Split(new string[] { " - " }, StringSplitOptions.None);
                    artists = tmp[0].Replace(" & ", ",").Replace("&", ",").Trim();
                    title = tmp[tmp.Length == 1 ? 0 : 1].Split("(".ToCharArray())[0].Trim();
                    duration = f.Properties.Duration.TotalSeconds.ToString();

                    sameBitrate = f.Properties.AudioBitrate == 128;

                    f.RemoveTags(TagLib.TagTypes.AllTags);
                    f.Save();
                    f.Dispose();

                    textBox2.Invoke(new Action(() => textBox2.Text = title));
                    textBox5.Invoke(new Action(() => textBox5.Text = artists));

                    panel1.Invoke(new Action(() => panel1.Visible = true));

                    UpdateYTStatus("Youtube Audio Downloaded");
                }
                else
                {
                    Notify("Download from YouTube went wrong. If you keep getting this error, try another youtube video of the same song.", false);
                    UpdateYTStatus("");

                    button1.Invoke(new Action(() => button1.Click += ButtonBrowseMP3_Click));
                    button2.Invoke(new Action(() => button2.Click += ButtonProcess_Click));
                    button2.Invoke(new Action(() => textBox1.ReadOnly = false));
                }
            }
            catch
            {
                Notify("Download from YouTube went wrong. If you keep getting this error, try another youtube video of the same song.", false);
                UpdateYTStatus("");

                button1.Invoke(new Action(() => button1.Click += ButtonBrowseMP3_Click));
                button2.Invoke(new Action(() => button2.Click += ButtonProcess_Click));
                button2.Invoke(new Action(() => textBox1.ReadOnly = false));
            }
        }

        void ProcessFile()
        {
            TagLib.File f = TagLib.File.Create(fileLocation);

            if (f.Tag.Genres.Length > 0)
            {
                genre = f.Tag.Genres[0];
            }
            foreach (string s in f.Tag.Performers)
            {
                if (artists == "")
                {
                    artists += s;
                }
                else
                {
                    artists += "," + s;
                }
            }
            artists = artists.Replace(" & ", ",").Replace("&", ",");
            title = f.Tag.Title;
            album = f.Tag.Album;
            duration = f.Properties.Duration.TotalSeconds.ToString();

            if (f.Properties.AudioBitrate == 128)
            {
                sameBitrate = true;

                File.Copy(fileLocation, MP3Temp + TempName);
                fileLocation = MP3Temp + TempName;

                f = TagLib.File.Create(fileLocation);
                f.RemoveTags(TagLib.TagTypes.AllTags);
                f.Save();
            }

            f.Dispose();



            textBox2.Text = title;
            textBox3.Text = album;
            textBox4.Text = genre;
            textBox5.Text = artists;

            panel1.Visible = true;
        }

        void FindCover()
        {
            try
            {
                byte[] image = GetImage(GetCoverImageUrl(title, artists));

                using (MemoryStream ms = new MemoryStream(image))
                {
                    pictureBox1.Invoke(new Action(() => pictureBox1.Image = Image.FromStream(ms)));
                    pictureBox2.Invoke(new Action(() => pictureBox2.Image = Image.FromStream(ms)));
                }

                panel1.Invoke(new Action(() => panel1.Visible = false));
                panel2.Invoke(new Action(() => panel2.Visible = false));
                panel3.Invoke(new Action(() => panel3.Visible = true));

                label10.Invoke(new Action(() => label10.Text = ""));
                button4.Invoke(new Action(() => button4.Click += ButtonSubmit_Click));
            }
            catch { }
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

        void SaveCover()
        {
            Directory.CreateDirectory(outgoingTemp + title);

            UpdateStatus("Converting File: 0%");
            Bitmap bitmap = new Bitmap(400, 400);
            pictureBox1.DrawToBitmap(bitmap, pictureBox1.ClientRectangle);
            bitmap.Save(outgoingTemp + title + "\\cover.png", ImageFormat.Png);
            bitmap = new Bitmap(180, 180);
            pictureBox2.DrawToBitmap(bitmap, pictureBox1.ClientRectangle);
            bitmap.Save(outgoingTemp + title + "\\covericon.png", ImageFormat.Png);
            UpdateStatus("Converting File: 10%");
        }

        void ManageUpload()
        {
            try
            {
                ConvertMp3();
                Upload();
            }
            catch
            {
                Notify(title + " has failed uploading.", false);
            }
        }

        void ConvertMp3()
        {
            ID3TagData empty = new ID3TagData();

            Mp3FileReader reader = new Mp3FileReader(fileLocation);
            LameMP3FileWriter writer = new LameMP3FileWriter(outgoingTemp + title + "\\low.mp3", reader.WaveFormat, 64, empty);
            reader.CopyTo(writer);
            reader.Dispose();
            writer.Dispose();

            if (sameBitrate)
            {
                UpdateStatus("Converting File: 90%");

                File.Move(fileLocation, outgoingTemp + title + "\\high.mp3");
            }
            else
            {
                UpdateStatus("Converting File: 40%");

                reader = new Mp3FileReader(fileLocation);
                writer = new LameMP3FileWriter(outgoingTemp + title + "\\high.mp3", reader.WaveFormat, 128, empty);
                reader.CopyTo(writer);
                reader.Dispose();
                writer.Dispose();

                if (isYT)
                {
                    File.Delete(fileLocation);
                }
            }

            UpdateStatus("Converting File: 100%");
        }

        async void Upload()
        {
            WebDavClientParams clientParams = new WebDavClientParams()
            {
                BaseAddress = new Uri("https://ablos.stackstorage.com/remote.php/webdav/music/"),
                Credentials = new NetworkCredential("ablos", "AblosStack00")
            };
            WebDavClient wClient = new WebDavClient(clientParams);



            bool artistExist = false;
            firstArtist = artists.Split(',')[0].Trim().Replace(" ", "_").ToLower();

            PropfindResponse artist = await wClient.Propfind("/");
            foreach (WebDavResource folder in artist.Resources)
            {
                if (folder.DisplayName == firstArtist)
                {
                    artistExist = true;
                }
            }
            if (!artistExist)
            {
                await wClient.Mkcol(firstArtist);
            }



            bool songExist = false;
            saveName = title.Trim().Replace(" ", "_").ToLower();

            PropfindResponse song = await wClient.Propfind(firstArtist + "/");
            while (!songExist)
            {
                bool nameChange = false;
                foreach (WebDavResource folder in song.Resources)
                {
                    if (folder.DisplayName == saveName)
                    {
                        saveName += "1";
                        nameChange = true;
                    }
                }
                if (!nameChange)
                {
                    songExist = true;
                }
            }
            await wClient.Mkcol(firstArtist + "/" + saveName);



            UpdateStatus("Uploading To Server: 0%");
            await wClient.PutFile(firstArtist + "/" + saveName + "/cover.png", File.OpenRead(outgoingTemp + title + "\\cover.png"));
            await wClient.PutFile(firstArtist + "/" + saveName + "/covericon.png", File.OpenRead(outgoingTemp + title + "\\covericon.png"));
            UpdateStatus("Uploading To Server: 10%");
            await wClient.PutFile(firstArtist + "/" + saveName + "/low.mp3", File.OpenRead(outgoingTemp + title + "\\low.mp3"));
            UpdateStatus("Uploading To Server: 40%");
            await wClient.PutFile(firstArtist + "/" + saveName + "/high.mp3", File.OpenRead(outgoingTemp + title + "\\high.mp3"));
            UpdateStatus("Uploading To Server: 100%");



            WebClient client = new WebClient();
            string feedback = client.DownloadString("http://ablos.square7.ch/upload.php/?title=" + title + "&artists=" + artists + "&genre=" + genre + "&album=" + album + "&duration=" + duration + "&path=" + "/music/" + firstArtist + "/" + saveName + "/");

            if (feedback.Trim() == "affirmative")
            {
                Notify(title + " was uploaded successfully.", true);
            }

            Directory.Delete(outgoingTemp + title, true);

            CloseForm();
        }

        void Notify(string text, bool state)
        {
            NotifyIcon notifyIcon1 = new NotifyIcon();
            notifyIcon1.Visible = true;
            notifyIcon1.Icon = Properties.Resources.MainIcon;
            notifyIcon1.Text = "VIBES";
            notifyIcon1.ShowBalloonTip(3000, "Upload", text, state?ToolTipIcon.Info:ToolTipIcon.Error);
        }

        void UpdateStatus(string status)
        {
            if (label8.InvokeRequired)
            {
                label8.Invoke(new Action(() => label8.Text = status));
            }
            else
            {
                label8.Text = status;
            }
        }

        void UpdateYTStatus(string status)
        {
            if (label9.InvokeRequired)
            {
                label9.Invoke(new Action(() => label9.Text = status));
            }
            else
            {
                label9.Text = status;
            }
        }

        void CloseForm()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Close()));
            }
            else
            {
                Close();
            }

        }
    }
}
