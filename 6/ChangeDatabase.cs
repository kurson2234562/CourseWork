using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _6
{
    public partial class ChangeDatabase : Form
    {
        SqlDataAdapter sda;
        BindingSource bs1 = new BindingSource();
        DataTable dt;
        SqlConnection con = new SqlConnection();
        private int x = 0, y = 0;
        public ChangeDatabase()
        {
            InitializeComponent();
        }

        private void ChangeDatabase_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != "")
            {
                sda = new SqlDataAdapter(@"Select * From " + comboBox1.SelectedItem.ToString(), con);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            dataGridView1.Width = dataGridView1.Columns.Count * dataGridView1.Columns[1].Width + 50;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void ChangeDatabase_Load(object sender, EventArgs e)
        {
            this.songerTableAdapter.Fill(this.audio_libDataSet.Songer);
            con.ConnectionString = @"Data Source=.;Initial Catalog=Audio_lib; Integrated Security=true";
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            button2.Enabled = false;
        }

        private void ChangeDatabase_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Location = new System.Drawing.Point(this.Location.X + (e.X - x), this.Location.Y + (e.Y - y));
            }
        }
    }
}
