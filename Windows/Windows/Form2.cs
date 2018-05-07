/*
 * (c) Paul Tervoort - HotkeyCode Inc.
 */

#region References
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
using Newtonsoft.Json;
#endregion

namespace Windows
{
    public partial class Form2 : Form
    {
        #region SharedVars
        //booleans
        bool isYT = false;
        bool sameBitrate = false;

        //strings
        string TempName = "";
        string fileLocation = "";
        string saveName = "";
        string firstArtist = "";
        string outgoingTemp = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\musicStreamer\\OutgoingTemp\\";
        string MP3Temp = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\musicStreamer\\MP3Temp\\";

        //strings for in mysql
        string title = "";
        string artists = "";
        string album = "";
        string genre = "";
        TimeSpan duration = new TimeSpan();

        //notify icon for the messages
        NotifyIcon notifyIcon1 = new NotifyIcon();

        //image holding the original downloaded cover file
        Image cover = null;
        #endregion


        #region Initializing
        //initializes the form
        public Form2()
        {
            InitializeComponent();
        }

        //checks if required folders exist
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
        #endregion


        #region FunctionsWithEvent
        //pops up a file dialog for uploading a mp3-file
        private void ButtonBrowseMP3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "MP3 music files|*.mp3";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.FileName;
            }
        }

        //downloads mp3-file if required and extracts all info
        private void ButtonProcess_Click(object sender, EventArgs e)
        {
            fileLocation = textBox1.Text.Trim();
            TempName = DateTime.Now.Ticks.ToString() + ".mp3";

            //processes YouTube if YouTube link detected
            isYT = fileLocation.StartsWith("https://www.youtube.com/");
            if (isYT)
            {
                button1.Click -= ButtonBrowseMP3_Click;
                button2.Click -= ButtonProcess_Click;
                textBox1.ReadOnly = true;

                Task.Run((Action)DownloadYT);
            }

            //processes mp3-file if given file exists
            if (File.Exists(fileLocation))
            {
                button1.Click -= ButtonBrowseMP3_Click;
                button2.Click -= ButtonProcess_Click;
                textBox1.ReadOnly = true;

                ProcessFile();
            }
        }

        //takes data from the textboxes and searches for a matching cover
        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            //gets data from the textboxes
            title = textBox2.Text.Trim().ToLower();
            album = textBox3.Text.Trim().ToLower();
            genre = textBox4.Text.Trim().ToLower();
            artists = textBox5.Text.Trim().ToLower();

            //if no field is empty, go to next dialog
            if (title != "" && album != "" && genre != "" && artists != "")
            {
                Task.Run((Action)FindCover);
                label10.Text = "Please Wait...";
                button4.Click -= ButtonSubmit_Click;
            }
        }

        //pops up a file dialog for manual adding a cover
        private void ButtonBrowseCover_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Supported Images|*.bmp;*.jpg;*.jpeg;*.png";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                cover = Image.FromFile(dialog.FileName);
                UpdatePictureboxes();
            }
        }

        //clears the cover data
        private void ButtonClearCover_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
        }

        //closes the form
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        //takes you back to previous menu
        private void ButtonBack_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = false;
        }

        //converts everything to the right format and sends it to the server
        private void ButtonFinish_Click(object sender, EventArgs e)
        {
            //disables all buttons except the cancel button
            button3.Click -= ButtonFinish_Click;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;

            //upload
            SaveCover();
            Task.Run((Action)ManageUpload);
        }

        //changes the cover image to how the user wants it
        private void SelectCoverFitMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePictureboxes();
        }
        #endregion


        #region OtherFunctions
        //downloads the mp3-file from YouTube on a separate thread and tries to extract artists and title
        private void DownloadYT()
        {
            UpdateYTStatus("Downloading Youtube Audio...");

            try
            {
                //downloads the mp3-file from YouTube
                WebClient client = new WebClient();
                client.DownloadFile(new Uri("https://www.convertmp3.io/fetch/?video=" + fileLocation), MP3Temp + TempName);
                fileLocation = MP3Temp + TempName;
                client.Dispose();


                //checks if file is not unbelievable short (aka 2kb)
                if (new FileInfo(fileLocation).Length > 2000)
                {
                    TagLib.File f = TagLib.File.Create(MP3Temp + TempName);

                    //gets the info from the downloaded mp3-file
                    string titleYT = f.Tag.Title;
                    string[] tmp = titleYT.Split(new string[] { " - " }, StringSplitOptions.None);
                    artists = tmp[0].Replace(" & ", ",").Replace("&", ",").Trim();
                    title = tmp[tmp.Length == 1 ? 0 : 1].Split("(".ToCharArray())[0].Trim();
                    duration = f.Properties.Duration;

                    //checks if the bitrate is already 128kbps
                    sameBitrate = f.Properties.AudioBitrate == 128;

                    //removes all tags from the mp3-file
                    f.RemoveTags(TagLib.TagTypes.AllTags);
                    f.Save();
                    f.Dispose();

                    //updates the form
                    textBox2.Invoke(new Action(() => textBox2.Text = title));
                    textBox5.Invoke(new Action(() => textBox5.Text = artists));

                    //displays the next dialog
                    panel1.Invoke(new Action(() => panel1.Visible = true));

                    UpdateYTStatus("Youtube Audio Downloaded");
                }
                else
                {
                    //file download went wrong: too short file
                    Notify("Download from YouTube went wrong. If you keep getting this error, try another youtube video of the same song.", false);
                    UpdateYTStatus("");

                    //enable previous controls again
                    button1.Invoke(new Action(() => button1.Click += ButtonBrowseMP3_Click));
                    button2.Invoke(new Action(() => button2.Click += ButtonProcess_Click));
                    button2.Invoke(new Action(() => textBox1.ReadOnly = false));
                }
            }
            catch
            {
                //something crashed
                Notify("Download from YouTube went wrong. If you keep getting this error, try another youtube video of the same song.", false);
                UpdateYTStatus("");

                //enable previous controls again
                button1.Invoke(new Action(() => button1.Click += ButtonBrowseMP3_Click));
                button2.Invoke(new Action(() => button2.Click += ButtonProcess_Click));
                button2.Invoke(new Action(() => textBox1.ReadOnly = false));
            }
        }

        //extracts title, album, genre, artists from a mp3-file
        private void ProcessFile()
        {
            TagLib.File f = TagLib.File.Create(fileLocation);

            //adds all artist tags together
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

            //gets all other info
            artists = artists.Replace(" & ", ",").Replace("&", ",");
            title = f.Tag.Title;
            album = f.Tag.Album;
            duration = f.Properties.Duration;

            //if bitrate already 128kbps, copy the file and clear all tags
            if (f.Properties.AudioBitrate == 128)
            {
                sameBitrate = true;

                File.Copy(fileLocation, MP3Temp + TempName);
                fileLocation = MP3Temp + TempName;

                f = TagLib.File.Create(fileLocation);
                f.RemoveTags(TagLib.TagTypes.AllTags);
                f.Save();
            }

            //applies the info to the textboxes
            textBox2.Text = title;
            textBox3.Text = album;
            textBox4.Text = genre;
            textBox5.Text = artists;

            //enables next dialog
            panel1.Visible = true;
        }

        //manages the process of finding a matching cover on a separate thread
        private void FindCover()
        {
            try
            {
                //gets the image
                byte[] image = GetImage(GetCoverImageUrl(title, artists));

                //converts the image from the filestream
                using (MemoryStream ms = new MemoryStream(image))
                {
                    cover = Image.FromStream(ms);
                }

                //puts the image to the pictureboxes
                pictureBox1.Invoke(new Action(() => pictureBox1.Image = cover));
                pictureBox2.Invoke(new Action(() => pictureBox2.Image = cover));

                //displays the next dialog with the pictureboxes
                panel1.Invoke(new Action(() => panel1.Visible = false));
                panel2.Invoke(new Action(() => panel2.Visible = false));
                panel3.Invoke(new Action(() => panel3.Visible = true));

                //resets the previous dialog, for when user presses the previous button
                label10.Invoke(new Action(() => label10.Text = ""));
                button4.Invoke(new Action(() => button4.Click += ButtonSubmit_Click));

                comboBox1.Invoke(new Action(() => comboBox1.SelectedIndex = 0));
            }
            catch { }
        }

        //returns the link to the which appears top-left on a google page if you search for %title% %artist% cover
        private string GetCoverImageUrl(string title, string artists)
        {
            //create the url for google search
            string googleUrl = "https://www.google.com/search?q=" + title + " " + artists.Replace(",", " ") + " cover&tbm=isch";

            //create a suitable webrequest
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(googleUrl);
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";

            //gets the html document
            string html = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();

            //finds the right link in the html
            int ndx = html.IndexOf("\"ou\"", StringComparison.Ordinal);
            ndx = html.IndexOf("\"", ndx + 4, StringComparison.Ordinal);
            ndx++;
            int ndx2 = html.IndexOf("\"", ndx, StringComparison.Ordinal);
            string url = html.Substring(ndx, ndx2 - ndx);
            return url;
        }

        //returns a byte array containing the image of a given url
        private byte[] GetImage(string url)
        {
			//create webrequest
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //writes the image to a datastream
            using (Stream dataStream = response.GetResponseStream())
            {
                using (var sr = new BinaryReader(dataStream))
                {
                    //read all bytes
                    byte[] bytes = sr.ReadBytes(100000000);

                    //return imagedata
                    return bytes;
                }
            }
        }

        //writes the image in a picturebox to a file
        private void SaveCover()
        {
            UpdateUploadStatus("Converting File: 0%");

            //creates a temp directory for this song
            Directory.CreateDirectory(outgoingTemp + title);

            //writes the image from the big picturebox as 400x400 image
            Bitmap bitmap = new Bitmap(400, 400);
            pictureBox1.DrawToBitmap(bitmap, pictureBox1.ClientRectangle);
            bitmap.Save(outgoingTemp + title + "\\cover.png", ImageFormat.Png);

            //writes the image from the small picturebox as 180x180 icon
            bitmap = new Bitmap(180, 180);
            pictureBox2.DrawToBitmap(bitmap, pictureBox1.ClientRectangle);
            bitmap.Save(outgoingTemp + title + "\\covericon.png", ImageFormat.Png);

            UpdateUploadStatus("Converting File: 10%");
        }

        //manages the whole upload process on a separate thread
        private void ManageUpload()
        {
            try
            {
                //converts the mp3-files to get a 64 and 128 kbps file
                ConvertMp3();

                //uploads the mp3-files and the cover files and adds all data to mysql
                Upload();
            }
            catch
            {
                //something went wrong
                Notify("\"" + title + "\" has failed uploading.", false);
            }
        }

        //makes sure that there is a 64kbps mp3-file and a 128kbps
        private void ConvertMp3()
        {
            //empty ID3tag to include during the conversion, to make sure there are no tags in the file
            ID3TagData empty = new ID3TagData();

            //converts the file to a low quality format (64kbps)
            Mp3FileReader reader = new Mp3FileReader(fileLocation);
            LameMP3FileWriter writer = new LameMP3FileWriter(outgoingTemp + title + "\\low.mp3", reader.WaveFormat, 64, empty);
            reader.CopyTo(writer);
            reader.Dispose();
            writer.Dispose();

            //if the original file already was 128kbps, there is no need to convert
            if (sameBitrate)
            {
                UpdateUploadStatus("Converting File: 90%");

                //move a copy of the original file, with its ID3tags removed earlier, to the folder which will be uploaded
                File.Move(fileLocation, outgoingTemp + title + "\\high.mp3");
            }
            else
            {
                UpdateUploadStatus("Converting File: 40%");

                //convert the source file to 128 kbps, high quality in this program
                reader = new Mp3FileReader(fileLocation);
                writer = new LameMP3FileWriter(outgoingTemp + title + "\\high.mp3", reader.WaveFormat, 128, empty);
                reader.CopyTo(writer);
                reader.Dispose();
                writer.Dispose();

                //if a file from YouTube was used as source, delete it from the temp
                if (isYT)
                {
                    File.Delete(fileLocation);
                }
            }

            UpdateUploadStatus("Converting File: 100%");
        }

        //uploads both mp3-files and the cover to WEBDAV and adds all info to mysql
        private async void Upload()
        {
            //initializes a new WEBDAV client
            WebDavClientParams clientParams = new WebDavClientParams()
            {
                BaseAddress = new Uri("https://ablos.stackstorage.com/remote.php/webdav/music/"),
                Credentials = new NetworkCredential("ablos", "AblosStack00")
            };
            WebDavClient wClient = new WebDavClient(clientParams);


            //picks 1 artist to use as destination folder on the server
            firstArtist = artists.Split(',')[0].Trim().Replace(" ", "_").ToLower();

            //searches for a folder with the name of the picked artist
            bool artistExist = false;
            PropfindResponse artist = await wClient.Propfind("/");
            foreach (WebDavResource folder in artist.Resources)
            {
                if (folder.DisplayName == firstArtist)
                {
                    artistExist = true;
                }
            }

            //creates the folder if there is no folder with this name on the server
            if (!artistExist)
            {
                await wClient.Mkcol(firstArtist);
            }


            //replaces spaces in the title with underscores, just for saving
            saveName = title.Trim().Replace(" ", "_").ToLower();

            //looks if this name already exists for this artist, and add characters to make suitable name for a folder on the server
            bool songExist = false;
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

            //creates the folder on the server
            await wClient.Mkcol(firstArtist + "/" + saveName);
			
			SongInfo info = new SongInfo(title, artists, duration, genre, album);
			File.WriteAllText(outgoingTemp + title + "\\songinfo.json", JsonConvert.SerializeObject(info));

            //uploads all file from the local folder to the folder on the server
            UpdateUploadStatus("Uploading To Server: 0%");
            await wClient.PutFile(firstArtist + "/" + saveName + "/cover.png", File.OpenRead(outgoingTemp + title + "\\cover.png"));
            await wClient.PutFile(firstArtist + "/" + saveName + "/covericon.png", File.OpenRead(outgoingTemp + title + "\\covericon.png"));
            UpdateUploadStatus("Uploading To Server: 10%");
            await wClient.PutFile(firstArtist + "/" + saveName + "/low.mp3", File.OpenRead(outgoingTemp + title + "\\low.mp3"));
            UpdateUploadStatus("Uploading To Server: 40%");
            await wClient.PutFile(firstArtist + "/" + saveName + "/high.mp3", File.OpenRead(outgoingTemp + title + "\\high.mp3"));
			UpdateUploadStatus("Uploading To Server: 95%");
			await wClient.PutFile(firstArtist + "/" + saveName + "/info.json", File.OpenRead(outgoingTemp + title + "\\songinfo.json"));
            UpdateUploadStatus("Uploading To Server: 100%");


            //adds the info about this song to mysql
            WebClient client = new WebClient();
            string feedback = client.DownloadString("http://ablos.square7.ch/upload.php/?title=" + title + "&artists=" + artists + "&genre=" + genre + "&album=" + album + "&duration=" + duration + "&path=" + "/music/" + firstArtist + "/" + saveName + "/");

            //notifies the user that the upload was done
            if (feedback.Trim() == "affirmative")
            {
				string[] parts = title.Split(' ');
				string capTitle = parts[0][0].ToString().ToUpper() + parts[0].Substring(1);

				for (int i = 1; i < parts.Length; i++)
				{
					capTitle += " " + parts[i][0].ToString().ToUpper() + parts[i].Substring(1);
				}

                Notify("\"" + capTitle + "\" was uploaded successfully.", true);
            }

            //deletes the local directory
            Directory.Delete(outgoingTemp + title, true);

            //closes this form
            CloseForm();
        }

        //notifies the user with a given text and a positive/negative symbol
        private void Notify(string text, bool state)
        {
            //creates the notify icon
            notifyIcon1.Visible = true;
            notifyIcon1.Icon = Windows.Properties.Resources.MainIcon;
            notifyIcon1.Text = "VIBES";

            //displays the notification
            notifyIcon1.ShowBalloonTip(3000, "VIBES", text, state?ToolTipIcon.Info:ToolTipIcon.Error);
        }

        //sets the text of uploadstatus-label, even if called on separate thread
        private void UpdateUploadStatus(string status)
        {
            if (label8.InvokeRequired)
            {
                //if from separate thread, use invoke
                label8.Invoke(new Action(() => label8.Text = status));
            }
            else
            {
                //if from same thread, use the regular way
                label8.Text = status;
            }
        }

        //sets the text of YouTubestatus-label, even if called on separate thread
        private void UpdateYTStatus(string status)
        {
            if (label9.InvokeRequired)
            {
                //if from separate thread, use invoke
                label9.Invoke(new Action(() => label9.Text = status));
            }
            else
            {
                //if from same thread, use the regular way
                label9.Text = status;
            }
        }

        //closes this form, even if called on separate thread
        private void CloseForm()
        {
            if (InvokeRequired)
            {
                //if from separate thread, use invoke
                Invoke(new Action(() => Close()));
            }
            else
            {
                //if from same thread, use the regular way
                Close();
            }

        }

        //updates the image in the pictureboxes, using the option selected by the user
        void UpdatePictureboxes()
        {
            switch (comboBox1.SelectedIndex)
            {
                //selected add bars
                case 0:
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;

                    //applies cover image to the pictureboxes
                    pictureBox1.Image = cover;
                    pictureBox2.Image = cover;
                    break;


                //selected zoom
                case 1:
                    //creates temp image
                    Image tmpImage = new Bitmap(400, 400);

                    //cuts edges from the temp image
                    Graphics g = Graphics.FromImage(tmpImage);
                    g.FillRectangle(new SolidBrush(Color.White), 0, 0, 400, 400);
                    int t = 0, l = 0;
                    if (cover.Height > cover.Width)
                        t = (cover.Height - cover.Width) / 2;
                    else
                        l = (cover.Width - cover.Height) / 2;
                    g.DrawImage(cover, new Rectangle(0, 0, 400, 400), new Rectangle(l, t, cover.Width - l * 2, cover.Height - t * 2), GraphicsUnit.Pixel);
                    g.Dispose();

                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                    //applies temp image to the pictureboxes
                    pictureBox1.Image = tmpImage;
                    pictureBox2.Image = tmpImage;
                    break;


                //selected stretch
                case 2:
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                    //applies cover image to the pictureboxes
                    pictureBox1.Image = cover;
                    pictureBox2.Image = cover;
                    break;
            }
        }
        #endregion
    }
}
