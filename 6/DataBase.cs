using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace _6
{
    public partial class DataBase : Form
    {

        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        SqlConnection con = new SqlConnection();
        public DataBase()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter(@"Select * From "+textBox1.Text, con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void DataBase_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "audio_libDataSet.Group_of_songer". При необходимости она может быть перемещена или удалена.
            this.group_of_songerTableAdapter.Fill(this.audio_libDataSet.Group_of_songer);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "audio_libDataSet.Songer". При необходимости она может быть перемещена или удалена.
            this.songerTableAdapter.Fill(this.audio_libDataSet.Songer);
            con.ConnectionString = @"Data Source=.;Initial Catalog=Audio_lib; Integrated Security=true";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter(@"Insert Into Songer Values('BBB','rty',12346)", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
