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
//Git Test
//Commit Test
namespace _6
{
    public partial class Form1 : Form
    {
        IDictionary<string, string> playList = new Dictionary<string, string>();
        int nowplaying = -1;
        public Form1()
        {
            InitializeComponent();
        }
        private BlockAlignReductionStream stream = null;
        private DirectSoundOut output = null;
        int index = 0;
        int dur = 0;
        private int x = 0,y=0;

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.openFileDialog1.InitialDirectory = @"D:\Музыка\";
            this.openFileDialog1.Filter = "Audio file (*.mp3;*.wav)|*.mp3;*.wav";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Please select audiofile(s) file for opening";
            //listBox1.Height = this.Height - 150;
            this.KeyPreview = true;   
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Open.Width = this.Width - 40;
            listBox1.Width = this.Width - 40;
            listBox1.Height = this.Height - 150;
        }

        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    foreach (string fileName in openFileDialog1.FileNames)
                    {
                        string shortPath = Path.GetFileName(fileName);
                        shortPath = shortPath.Substring(0, shortPath.Length - 4);
                        listBox1.Items.Add(shortPath);
                        playList.Add(shortPath, fileName);
                        WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(fileName));
                        stream = new BlockAlignReductionStream(pcm);
                        var mp3File = TagLib.File.Create(fileName);
                        timer1.Enabled = true;
                    }
                    Previous.Enabled = true;
                    PlayPause.Enabled = true;
                    Next.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(@"Error: Could not read file from disk. " + ex.Message);
                }
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                nowplaying = listBox1.SelectedIndex;
                WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(playList[(string)listBox1.SelectedItem]));
                stream = new BlockAlignReductionStream(pcm);
                if (output == null)
                    output = new DirectSoundOut();
                output.Init(stream);
                output.Play();
                var mp3File = TagLib.File.Create(playList[(string)listBox1.SelectedItem]);
                label1.Text = String.Join(",", mp3File.Tag.Performers) + " - " + mp3File.Tag.Title + " \r(" + mp3File.Tag.Album + ", " + mp3File.Tag.Year + ")            " + mp3File.Properties.Duration.ToString("mm\\:ss");//+" "+mp3File.Tag.FirstGenre;
                timer1.Interval = (mp3File.Properties.Duration.Seconds + mp3File.Properties.Duration.Minutes * 60 + mp3File.Properties.Duration.Hours * 3600) * 1000;
            }
            else
            {
                Open_Click(sender, e);
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    nowplaying = listBox1.SelectedIndex;
                    WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(playList[(string)listBox1.SelectedItem]));
                    stream = new BlockAlignReductionStream(pcm);
                    if (output == null)
                        output = new DirectSoundOut();
                    output.Init(stream);
                    output.Play();
                    var mp3File = TagLib.File.Create(playList[(string)listBox1.SelectedItem]);
                    label1.Text = String.Join(",", mp3File.Tag.Performers) + " - " + mp3File.Tag.Title + " \r(" + mp3File.Tag.Album + ", " + mp3File.Tag.Year + ")            " + mp3File.Properties.Duration.ToString("mm\\:ss");//+" "+mp3File.Tag.FirstGenre;
                    timer1.Interval = (mp3File.Properties.Duration.Seconds + mp3File.Properties.Duration.Minutes * 60 + mp3File.Properties.Duration.Hours * 3600) * 1000;
                }
                if (e.KeyCode == Keys.Delete)
                {
                    index = listBox1.SelectedIndex;
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                    listBox1.SelectedIndex = index;
                }
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                if (listBox1.SelectedIndex != listBox1.Items.Count - 1)
                {
                    //listBox1.SetSelected(listBox1.SelectedIndex + 1, true);
                    if (nowplaying > 0)
                    {
                        listBox1.SelectedIndex = nowplaying;
                        WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(playList[(string)listBox1.SelectedItem + 1]));
                        stream = new BlockAlignReductionStream(pcm);
                        if (output == null)
                            output = new DirectSoundOut();
                        output.Init(stream);
                        output.Play();
                    }
                    nowplaying++;
                }
                else
                {
                    listBox1.SetSelected(0, true);
                    listBox1_MouseDoubleClick(sender, (MouseEventArgs)e);
                }
            }
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                if (listBox1.SelectedIndex !=0)
                {
                    timer1.Interval = dur;
                    listBox1.SetSelected(listBox1.SelectedIndex -1, true);
                    listBox1_MouseDoubleClick(sender, (MouseEventArgs)e);
                }
                else
                {
                    listBox1.SetSelected(listBox1.Items.Count - 1, true);
                    listBox1_MouseDoubleClick(sender, (MouseEventArgs)e);
                }
            }
        }

        private void PlayPause_Click(object sender, EventArgs e)
        {
            if (output != null)
            {
                var mp3File = TagLib.File.Create(playList[(string)listBox1.SelectedItem]);
                label1.Text = String.Join(",", mp3File.Tag.Performers) + " - " + mp3File.Tag.Title + " \r(" + mp3File.Tag.Album + ", " + mp3File.Tag.Year + ")            " + mp3File.Properties.Duration.ToString("mm\\:ss");//+" "+mp3File.Tag.FirstGenre;
                timer1.Interval = (mp3File.Properties.Duration.Seconds + mp3File.Properties.Duration.Minutes * 60 + mp3File.Properties.Duration.Hours * 3600) * 1000;
                if (output.PlaybackState == PlaybackState.Playing) { output.Pause(); timer1.Enabled = false; }
                else if (output.PlaybackState == PlaybackState.Paused) { output.Play(); timer1.Enabled = true; }
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

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Location = new System.Drawing.Point(this.Location.X + (e.X - x), this.Location.Y + (e.Y - y));
            }
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     