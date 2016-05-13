using System;
using System.Windows.Forms;
using System.Threading;

namespace _6
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string nameStudent = "Татаринов С.В. 2016";
            int i = 0;
            timer1.Interval = 120;
            while (i < nameStudent.Length)
            {
                textBox1.Width++;
                textBox1.Text += nameStudent[i];
                textBox1.Update();
                Thread.Sleep(120);
                i++;
            }
            timer1.Enabled = false;
        }

        private void About_Shown(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1800;
        }
    }
}
