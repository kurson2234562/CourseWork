                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using NAudio.Wave;

namespace _6
{
    public partial class Application : Form
    {
        SqlDataAdapter sda;
        BindingSource bs1 = new BindingSource();
        DataTable dt;
        SqlConnection con = new SqlConnection();
        IDictionary<string, string> playList = new Dictionary<string, string>();
        int nowplaying = -1;
        public Application()
        {
            InitializeComponent();
        }
        private BlockAlignReductionStream stream = null;
        private DirectSoundOut output = null;
        int index = 0;
        //int dur = 0;
        private int x = 0, y = 0;

        void AddToDb()
        {
            var mp3File = TagLib.File.Create(playList[(string)PlayListComponent.SelectedItem]);
            if (mp3File.Tag.Title != "" && String.Join(",", mp3File.Tag.Performers) != "")
            {
                bool add = true;
                int idGenre = 0, idSonger = 0, idSong = 0, idAlbum = 0, idCompAlbum = 0, idCompSong = 0;
                string songer = "", song = "", genre = "", album = "";
                int csong = 0, calbum = 0;
                SqlDataAdapter sdaSonger, sdaSong, sdaGenre, sdaAlbum, sdaListening, sdaComposition;
                DataTable dtSonger, dtSong, dtGenre, dtAlbum, dtListening, dtComposition;
                int posSonger = 0, posGenre = 0, posSong = 0, posAlbum = 0, posCompAlbum = 0, posCompSong = 0;
                sdaSonger = new SqlDataAdapter(@"Select * From Songer ORDER BY 1", con);
                sdaGenre = new SqlDataAdapter(@"Select * From Genre ORDER BY 1", con);
                sdaSong = new SqlDataAdapter(@"Select * From Song ORDER BY 1", con);
                sdaAlbum = new SqlDataAdapter(@"Select * From Album_info ORDER BY 1", con);
                sdaListening = new SqlDataAdapter(@"Select * From Listening ORDER BY 1", con);
                sdaComposition = new SqlDataAdapter(@"Select * From Composition_album", con);
                dtSonger = new DataTable();
                dtGenre = new DataTable();
                dtSong = new DataTable();
                dtAlbum = new DataTable();
                dtListening = new DataTable();
                dtComposition = new DataTable();
                sdaSonger.Fill(dtSonger);
                sdaGenre.Fill(dtGenre);
                sdaSong.Fill(dtSong);
                sdaAlbum.Fill(dtAlbum);
                sdaListening.Fill(dtListening);
                sdaComposition.Fill(dtComposition);
                dataGridView1.DataSource = dtSonger;
                int cntSonger = dtSonger.Rows.Count;
                /******************************************************Songer*************************************************************/
                for (int i = 0; i < cntSonger; i++)
                {
                    songer = dtSonger.Rows[i].Field<string>("FIO");
                    sdaSonger = new SqlDataAdapter(@"Select * From Songer ORDER BY 1", con);
                    dtSonger = new DataTable();
                    sdaSonger.Fill(dtSonger);
                    if (songer.ToUpper() == String.Join(",", mp3File.Tag.Performers).ToUpper())
                    {
                        add = false;
                        posSonger = i;
                    }
                }
                if (add)
                {
                    sdaSonger = new SqlDataAdapter(@"Insert INTO Songer(FIO) Values ('" + String.Join(",", mp3File.Tag.Performers) + "')", con);
                    dtSonger = new DataTable();
                    sdaSonger.Fill(dtSonger);
                    dataGridView1.DataSource = dtSonger;
                }
                sdaSonger = new SqlDataAdapter(@"Select * From Songer ORDER BY 1", con);
                dtSonger = new DataTable();
                sdaSonger.Fill(dtSonger);
                cntSonger = dtSonger.Rows.Count;
                for (int i = 0; i < cntSonger; i++)
                {
                    songer = dtSonger.Rows[i].Field<string>("FIO");
                    
                    if (songer.ToUpper() == String.Join(",", mp3File.Tag.Performers).ToUpper())
                    {
                        add = false;
                        posSonger = i;
                    }
                }
                if (posSonger > 0)
                {
                    idSonger = dtSonger.Rows[posSonger].Field<int>("ID_Songer");
                }
                sdaSonger = new SqlDataAdapter(@"Select * From Songer ORDER BY 1", con);
                dtSonger = new DataTable();
                sdaSonger.Fill(dtSonger);
                /******************************************************Genre*************************************************************/
                add = true;
                int cntGenre = dtGenre.Rows.Count;
                for (int i = 0; i < cntGenre; i++)
                {
                    genre = dtGenre.Rows[i].Field<string>("Name_genre");
                    sdaGenre = new SqlDataAdapter(@"Select * From Genre ORDER BY 1", con);
                    dtGenre = new DataTable();
                    sdaGenre.Fill(dtGenre);
                    if (mp3File.Tag.FirstGenre == null || (genre.ToUpper() == mp3File.Tag.FirstGenre.ToUpper()))
                    {
                        add = false;
                        posGenre = i;
                    }
                    
                }
                if (add)
                {
                    sdaGenre = new SqlDataAdapter(@"Insert INTO Genre(Name_genre) Values ('" + mp3File.Tag.FirstGenre + "')", con);
                    dtGenre = new DataTable();
                    sdaGenre.Fill(dtGenre);
                    sdaGenre.Update(dtGenre);
                    dataGridView1.DataSource = dtGenre;
                }
                for (int i = 0; i < cntGenre; i++)
                {
                    sdaGenre = new SqlDataAdapter(@"Select * From Genre ORDER BY 1", con);
                    dtGenre = new DataTable();
                    sdaGenre.Fill(dtGenre);
                    cntGenre = dtGenre.Rows.Count;
                    genre = dtGenre.Rows[i].Field<string>("Name_genre");
                    if (genre == mp3File.Tag.FirstGenre || genre == "")
                    {
                        posGenre = i;
                    }
                }
                if (posGenre > 0)
                {
                    idGenre = dtGenre.Rows[posGenre].Field<int>("ID_Genre");
                }
                /******************************************************Song*************************************************************/
                int cntSong = dtSong.Rows.Count;
                add = true;
                for (int i = 0; i < cntSong; i++)
                {
                    song = dtSong.Rows[i].Field<string>("Name_song");
                    sdaSong = new SqlDataAdapter(@"Select * From Song ORDER BY 1", con);
                    dtSong = new DataTable();
                    sdaSong.Fill(dtSong);
                    if (song == mp3File.Tag.Title || song == "")
                    {
                        add = false;
                        posSong = i;
                    }
                }

                if (add)
                {
                    sdaSong = new SqlDataAdapter(@"Insert INTO Song(Name_song, Duration, ID_Genre) Values ('" + mp3File.Tag.Title + "','" + mp3File.Properties.Duration.Hours + ":" + mp3File.Properties.Duration.Minutes + ":" + mp3File.Properties.Duration.Seconds + "'," + idGenre + ")", con);
                    dtSong = new DataTable();
                    sdaSong.Fill(dtSong);
                    sdaSong.Update(dtSong);
                    dataGridView1.DataSource = dtSong;
                }
                sdaSong = new SqlDataAdapter(@"Select * From Song ORDER BY 1", con);
                dtSong = new DataTable();
                sdaSong.Fill(dtSong);
                cntSong = dtSong.Rows.Count;
                for (int i = 0; i < cntSong; i++)
                {
                    song = dtSong.Rows[i].Field<string>("Name_song");
                    if (song == mp3File.Tag.Title || song == "")
                    {
                        add = false;
                        posSong = i;
                    }
                }
                if (posSong > 0)
                {
                    idSong = dtSong.Rows[posSong].Field<int>("ID_Song");
                }
                /******************************************************Album*************************************************************/
                int cntAlbum = dtAlbum.Rows.Count;
                add = true;
                for (int i = 0; i < cntAlbum; i++)
                {
                    album = dtAlbum.Rows[i].Field<string>("Name_album");
                    sdaAlbum = new SqlDataAdapter(@"Select * From Album_info ORDER BY 1", con);
                    dtAlbum = new DataTable();
                    sdaAlbum.Fill(dtAlbum);
                    if (mp3File.Tag.Album == null || album.ToUpper() == mp3File.Tag.Album.ToUpper())
                    {

                        add = false;
                        posAlbum = i;
                    }
                }
                if (add)
                {
                    sdaAlbum = new SqlDataAdapter(@"Insert INTO Album_info(Name_album, Year_of_issue, ID_Songer) Values ('" + mp3File.Tag.Album + "','" + mp3File.Tag.Year + "'," + idSonger + ")", con);
                    dtAlbum = new DataTable();
                    sdaAlbum.Fill(dtAlbum);
                    sdaAlbum.Update(dtAlbum);
                    dataGridView1.DataSource = dtAlbum;
                }
                for (int i = 0; i < cntAlbum; i++)
                {
                    sdaAlbum = new SqlDataAdapter(@"Select * From Album_info ORDER BY 1", con);
                    dtAlbum = new DataTable();
                    sdaAlbum.Fill(dtAlbum);
                    cntAlbum = dtAlbum.Rows.Count;
                    album = dtAlbum.Rows[i].Field<string>("Name_album");
                    if (album == mp3File.Tag.Album || album == "")
                    {
                        posAlbum = i;
                    }
                }
                if (posAlbum > 0)
                {
                    idAlbum = dtAlbum.Rows[posAlbum].Field<int>("ID_Album");
                }
                /******************************************************Listening************************************************************/
                sdaListening = new SqlDataAdapter(@"Insert INTO Listening(ID_Song, ID_Songer, DateTime_Listening) Values (" + idSong + "," + idSonger + ",'" + DateTime.Now + "')", con);
                dtListening = new DataTable();
                sdaListening.Fill(dtListening);
                sdaListening.Update(dtListening);
                dataGridView1.DataSource = dtListening;

                int cntComposition = dtComposition.Rows.Count;

                add = true;
                for (int i = 0; i < cntComposition; i++)
                {
                    csong = dtComposition.Rows[i].Field<int>("ID_Song");
                    sdaComposition = new SqlDataAdapter(@"Select * From Composition_album ORDER BY 1", con);
                    dtComposition = new DataTable();
                    sdaComposition.Fill(dtComposition);
                    //MessageBox.Show("csong=" + csong, "idsong=" + idSong);
                    if (csong==idSong && mp3File.Tag.Album!="")
                    {
                        add = false;
                        posCompSong = i;
                    }
                }
                if (add)
                {
                    sdaComposition = new SqlDataAdapter(@"INSERT INTO Composition_album(ID_Album, ID_Song) VALUES(" + idAlbum + "," + idSong + ")", con);
                    dtComposition = new DataTable();
                    sdaComposition.Fill(dtComposition);
                    sdaComposition.Update(dtComposition);
                    dataGridView1.DataSource = dtComposition;
                }
            }
        }
        private void FollowSize()
        {
            OpenButton.Width = this.Width - 24;
            PlayListComponent.Width = this.Width - 24;
            PlayListComponent.Height = this.Height - 125;
            ResizePanel.Width = this.Width;
            CloseButton.Location = new System.Drawing.Point(this.Width - 36, 0);
            MaximizeButton.Location = new System.Drawing.Point(this.Width - 72, 0);
            MinimizeButton.Location = new System.Drawing.Point(this.Width - 108, 0);
            PreviousButton.Width = (this.Width - 48) / 3;
            PlayPauseButton.Location = new System.Drawing.Point(PreviousButton.Width + 24, 94);
            PlayPauseButton.Width = (this.Width - 48) / 3;
            NextButton.Location = new System.Drawing.Point(2 * PreviousButton.Width + 36, 94);
            NextButton.Width = (this.Width - 48) / 3;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.openFileDialog1.InitialDirectory = @"D:\Iocuea\";
            this.OpenFile.Filter = "Audio file (*.mp3;*.wav)|*.mp3;*.wav";
            this.OpenFile.RestoreDirectory = true;
            this.OpenFile.Multiselect = true;
            this.OpenFile.Title = "Please select audiofile(s) file for opening";
            //listBox1.Height = this.Height - 150;
            this.KeyPreview = true;
            MenuPanel.Visible = false;
            this.songerTableAdapter.Fill(this.audio_libDataSet.Songer);
            con.ConnectionString = @"Data Source=.;Initial Catalog=Audio_lib; Integrated Security=true";
            con.Open();

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            FollowSize();
            //OpenButton.Width = this.Width - 24;
            //PlayListComponent.Width = this.Width - 24;
            //PlayListComponent.Height = this.Height - 125;
        }

        private void Open_Click(object sender, EventArgs e)
        {
            MenuPanel.Visible = false;
            OpenFileDialog open = new OpenFileDialog();
            DialogResult dr = this.OpenFile.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {
                    foreach (string fileName in OpenFile.FileNames)
                    {
                        string shortPath = Path.GetFileName(fileName);
                        shortPath = shortPath.Substring(0, shortPath.Length - 4);
                        PlayListComponent.Items.Add(shortPath);
                        playList.Add(shortPath, fileName);
                        WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(fileName));
                        stream = new BlockAlignReductionStream(pcm);
                        var mp3File = TagLib.File.Create(fileName);
                        TIMER.Enabled = true;
                    }
                    PreviousButton.Enabled = true;
                    PlayPauseButton.Enabled = true;
                    NextButton.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(@"Error: Could not read file from disk. " + ex.Message);
                }
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            MenuPanel.Visible = false;
            if (PlayListComponent.Items.Count > 0)
            {
                if (PlayListComponent.SelectedIndex != PlayListComponent.Items.Count - 1)
                {
                    nowplaying++;
                    if (nowplaying > 0)
                    {
                        PlayListComponent.SelectedIndex = nowplaying;
                        WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(playList[(string)PlayListComponent.SelectedItem]));
                        stream = new BlockAlignReductionStream(pcm);
                        if (output == null)
                            output = new DirectSoundOut();

                        output.Init(stream);
                        output.Play();
                        AddToDb();
                    }
                }
                else
                {
                    PlayListComponent.SetSelected(PlayListComponent.Items.Count-PlayListComponent.Items.Count, true);
                    KeyEventArgs kea= new KeyEventArgs(Keys.Enter);
                    PlayListComponent_KeyDown(sender, kea);
                }
                if (output != null)
                {
                    var mp3File = TagLib.File.Create(playList[(string)PlayListComponent.SelectedItem]);
                    InformationAboutSong.Text = String.Join(",", mp3File.Tag.Performers) + " - " + mp3File.Tag.Title + " \r(" + mp3File.Tag.Album + ", " + mp3File.Tag.Year + ")            " + mp3File.Properties.Duration.ToString("mm\\:ss");//+" "+mp3File.Tag.FirstGenre;
                    TIMER.Interval = (mp3File.Properties.Duration.Seconds + mp3File.Properties.Duration.Minutes * 60 + mp3File.Properties.Duration.Hours * 3600) * 1000;
                }
            }
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            MenuPanel.Visible = false;
            if (PlayListComponent.Items.Count > 0)
            {
                if (PlayListComponent.SelectedIndex > 0)
                {
                    --nowplaying;
                    if (nowplaying >= 0)
                    {
                        PlayListComponent.SelectedIndex = nowplaying;
                        WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(playList[(string)PlayListComponent.SelectedItem]));
                        stream = new BlockAlignReductionStream(pcm);
                        if (output == null)
                            output = new DirectSoundOut();
                        output.Init(stream);
                        output.Play();
                        AddToDb();
                    }
                }
                else
                {
                    PlayListComponent.SetSelected(PlayListComponent.Items.Count - 1, true);
                    //PlayListComponent_MouseDoubleClick(sender, (MouseEventArgs)e);
                    KeyEventArgs kea = new KeyEventArgs(Keys.Enter);
                    PlayListComponent_KeyDown(sender, kea);
                }
                if (output != null)
                {
                    var mp3File = TagLib.File.Create(playList[(string)PlayListComponent.SelectedItem]);
                    InformationAboutSong.Text = String.Join(",", mp3File.Tag.Performers) + " - " + mp3File.Tag.Title + " \r(" + mp3File.Tag.Album + ", " + mp3File.Tag.Year + ")            " + mp3File.Properties.Duration.ToString("mm\\:ss");//+" "+mp3File.Tag.FirstGenre;
                    TIMER.Interval = (mp3File.Properties.Duration.Seconds + mp3File.Properties.Duration.Minutes * 60 + mp3File.Properties.Duration.Hours * 3600) * 1000;
                }
            }
        }

        private void PlayPause_Click(object sender, EventArgs e)
        {
            MenuPanel.Visible = false;
            if (output != null)
            {
                var mp3File = TagLib.File.Create(playList[(string)PlayListComponent.SelectedItem]);
                InformationAboutSong.Text = String.Join(",", mp3File.Tag.Performers) + " - " + mp3File.Tag.Title + " \r(" + mp3File.Tag.Album + ", " + mp3File.Tag.Year + ")            " + mp3File.Properties.Duration.ToString("mm\\:ss");//+" "+mp3File.Tag.FirstGenre;
                TIMER.Interval = (mp3File.Properties.Duration.Seconds + mp3File.Properties.Duration.Minutes * 60 + mp3File.Properties.Duration.Hours * 3600) * 1000;
                if (output.PlaybackState == PlaybackState.Playing) { output.Pause(); TIMER.Enabled = false; }
                else if (output.PlaybackState == PlaybackState.Paused) { output.Play(); TIMER.Enabled = true; }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    PlayPause_Click(sender, e);
                    break;
                case Keys.MediaPlayPause:
                    PlayPause_Click(sender, e);
                    break;
                case Keys.MediaNextTrack:
                    Next_Click(sender, e);
                    break;
                case Keys.MediaPreviousTrack:
                    Previous_Click(sender, e);
                    break;
            }
            if ((e.KeyCode == Keys.O && e.Control))
            {
                Open_Click(sender, e);
            }
        }

        private void CloseTools_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            MenuPanel.Visible = false;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (output!=null)
            output.Dispose();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPanel.Visible = !(MenuPanel.Visible);
            MenuPanel.Height = MenuCloseButton.Height + AboutButton.Height + DataBaseButton.Height;
        }

        private void MenuCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MaximizeButton_Click(object sender, EventArgs e)
        {
            switch (this.WindowState)
            {
                case FormWindowState.Normal:
                    this.WindowState = FormWindowState.Maximized;
                    break;
                case FormWindowState.Maximized:
                    this.WindowState = FormWindowState.Normal;
                    break;
            }
            FollowSize();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            Form About = new About();
            About.ShowDialog();
        }

        private void DataBaseButton_Click(object sender, EventArgs e)
        {
            authorization authorization = new authorization();
            authorization.Show();
        }

        private void PlayListComponent_KeyDown(object sender, KeyEventArgs e)
        {
            if (PlayListComponent.Items.Count > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    nowplaying = PlayListComponent.SelectedIndex;
                    WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(playList[(string)PlayListComponent.SelectedItem]));
                    stream = new BlockAlignReductionStream(pcm);
                    if (output == null)
                        output = new DirectSoundOut();
                    output.Init(stream);
                    output.Play();
                    var mp3File = TagLib.File.Create(playList[(string)PlayListComponent.SelectedItem]);
                    InformationAboutSong.Text = String.Join(",", mp3File.Tag.Performers) + " - " + mp3File.Tag.Title + " \r(" + mp3File.Tag.Album + ", " + mp3File.Tag.Year + ")            " + mp3File.Properties.Duration.ToString("mm\\:ss");//+" "+mp3File.Tag.FirstGenre;
                    TIMER.Interval = (mp3File.Properties.Duration.Seconds + mp3File.Properties.Duration.Minutes * 60 + mp3File.Properties.Duration.Hours * 3600) * 1000;
                    AddToDb();
                }
                if (e.KeyCode == Keys.Delete)
                {
                    index = PlayListComponent.SelectedIndex;
                    PlayListComponent.Items.RemoveAt(PlayListComponent.SelectedIndex);
                    PlayListComponent.SelectedIndex = index;
                }
            }
        }

        private void PlayListComponent_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MenuPanel.Visible = false;
            if (PlayListComponent.Items.Count > 0 && PlayListComponent.SelectedIndex>=0)
            {
                nowplaying = PlayListComponent.SelectedIndex;
                WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(playList[(string)PlayListComponent.SelectedItem]));
                stream = new BlockAlignReductionStream(pcm);
                if (output == null)
                    output = new DirectSoundOut();
                output.Init(stream);
                output.Play();
                var mp3File = TagLib.File.Create(playList[(string)PlayListComponent.SelectedItem]);
                InformationAboutSong.Text = String.Join(",", mp3File.Tag.Performers) + " - " + mp3File.Tag.Title + " \r(" + mp3File.Tag.Album + ", " + mp3File.Tag.Year + ")            " + mp3File.Properties.Duration.ToString("mm\\:ss");//+" "+mp3File.Tag.FirstGenre;
                TIMER.Interval = (mp3File.Properties.Duration.Seconds + mp3File.Properties.Duration.Minutes * 60 + mp3File.Properties.Duration.Hours * 3600) * 1000;
                AddToDb();
            }
            else if (PlayListComponent.Items.Count<=0)
            {
                Open_Click(sender, e);
            }
        }

        private void TIMER_Tick(object sender, EventArgs e)
        {
            Next_Click(sender, e);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new System.Drawing.Point(this.Location.X + (e.X - x), this.Location.Y + (e.Y - y));
            }
        }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              