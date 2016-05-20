using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace _6
{
    public partial class DataBase : Form
    {
        SqlDataAdapter sda;
        public bool adminthis;     
        BindingSource bs1 = new BindingSource();
        DataTable dt;
        SqlConnection con = new SqlConnection();
        public DataBase()
        {
            InitializeComponent();
        }

        private void DataBase_Load(object sender, EventArgs e)
        {
            this.songerTableAdapter.Fill(this.audio_libDataSet.Songer);
            con.ConnectionString = @"Data Source=.;Initial Catalog=Audio_lib; Integrated Security=true";
            bs1.DataSource = dt;
            dataGridView1.DataSource = bs1;
            button3.Visible = true;
            authorization main = this.Owner as authorization;
            if (main != null)
            {
                adminthis = main.admin;
            }
            if (!adminthis)
            {
                button3.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != "")
            {
                sda = new SqlDataAdapter(@"Select * From " + comboBox1.SelectedItem.ToString(), con);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            dataGridView1.Width = dataGridView1.Columns.Count * dataGridView1.Columns[1].Width+50;
            if(dataGridView1.Columns.Count * dataGridView1.Columns[1].Width + 50 > 430)
            this.Width = dataGridView1.Columns.Count * dataGridView1.Columns[1].Width+75;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form ChangeDatabase = new ChangeDatabase();
            ChangeDatabase.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txt = (TextBox)e.Control;
            txt.ReadOnly = true;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Queries form = new Queries();
            form.Show();
        }
    }
}
