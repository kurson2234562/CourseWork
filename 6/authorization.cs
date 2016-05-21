using System;
using System.Windows.Forms;

namespace _6
{
    public partial class authorization : Form
    {
        public bool admin;
        private int x = 0, y = 0;
        public authorization()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin = false;
            if((textBox1.Text=="admin") && (maskedTextBox1.Text == "admin"))
            {
                admin = true;
            }
            Form DataBase = new DataBase();
            DataBase.Owner = this;
            DataBase.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void authorization_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new System.Drawing.Point(this.Location.X + (e.X - x), this.Location.Y + (e.Y - y));
            }
        }

        private void authorization_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }
    }
}
