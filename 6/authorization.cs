using System;
using System.Windows.Forms;

namespace _6
{
    public partial class authorization : Form
    {
        public authorization()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool admin = false;
            if((textBox1.Text=="admin") && (maskedTextBox1.Text == "admin"))
            {
                admin = true;
            }
            Form DataBase = new DataBase();
            DataBase.Show();
        }
    }
}
