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
            if((textBox1.Text=="admin") && (textBox2.Text == "admin"))
            {
                ;
            }
        }
    }
}
