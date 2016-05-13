using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Linq;
using System.IO;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace _6
{
    public partial class Application : Form
    {
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
        private int x = 0,y=0;

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
            //this.openFileDialog1.InitialDirectory = @"D:\Музыка\";
            this.OpenFile.Filter = "Audio file (*.mp3;*.wav)|*.mp3;*.wav";
            this.OpenFile.RestoreDirectory = true;
            this.OpenFile.Multiselect = true;
            this.OpenFile.Title = "Please select audiofile(s) file for opening";
            //listBox1.Height = this.Height - 150;
            this.KeyPreview = true;
            MenuPanel.Visible = false;

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
            OpenFileDialog open = new OpenFileDialog();
            DialogResult dr = this.OpenFile.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
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

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (PlayListComponent.Items.Count > 0)
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
            }
            else
            {
                Open_Click(sender, e);
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
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
                }
                if (e.KeyCode == Keys.Delete)
                {
                    index = PlayListComponent.SelectedIndex;
                    PlayListComponent.Items.RemoveAt(PlayListComponent.SelectedIndex);
                    PlayListComponent.SelectedIndex = index;
                }
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
           
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
                    }
                }
                else
                {
                    PlayListComponent.SetSelected(0, true);
                    listBox1_MouseDoubleClick(sender, (MouseEventArgs)e);
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
                    }
                }
                else
                {
                    PlayListComponent.SetSelected(PlayListComponent.Items.Count - 1, true);
                    listBox1_MouseDoubleClick(sender, (MouseEventArgs)e);
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
            if (output != null)
            {
                var mp3File = TagLib.File.Create(playList[(string)PlayListComponent.SelectedItem]);
                InformationAboutSong.Text = String.Join(",", mp3File.Tag.Performers) + " - " + mp3File.Tag.Title + " \r(" + mp3File.Tag.Album + ", " + mp3File.Tag.Year + ")            " + mp3File.Properties.Duration.ToString("mm\\:ss");//+" "+mp3File.Tag.FirstGenre;
                TIMER.Interval = (mp3File.Properties.Duration.Seconds + mp3File.Properties.Duration.Minutes * 60 + mp3File.Properties.Duration.Hours * 3600) * 1000;
                if (output.PlaybackState == PlaybackState.Playing) { output.Pause(); TIMER.Enabled = false; }
                else if (output.PlaybackState == PlaybackState.Paused) { output.Play(); TIMER.Enabled = true; }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Next_Click(sender, e);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
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
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
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
            Form DataBase = new DataBase();
            DataBase.Show();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Location = new System.Drawing.Point(this.Location.X + (e.X - x), this.Location.Y + (e.Y - y));
            }
        }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     