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
        void ClearComp()
        {
            label1.Text = null;
            label2.Text = null;
            label3.Text = null;
            label4.Text = null;
            label5.Text = null;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            groupBox1.Visible = false;
        }
        public ChangeDatabase()
        {
            InitializeComponent();
        }

        private void ChangeDatabase_Load(object sender, EventArgs e)
        {
            ClearComp();
            this.songerTableAdapter.Fill(this.audio_libDataSet.Songer);
            con.ConnectionString = @"Data Source=.;Initial Catalog=Audio_lib; Integrated Security=true";
            con.Open();
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            ShowButton.Enabled = false;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowButton.Enabled = true;
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Album_Info":
                    textBox1.Enabled = false;
                    break;
                case "Composition_Album":
                    textBox1.Enabled = true;
                    break;
                case "Genre":
                    textBox1.Enabled = false;
                    break;
                case "Groups":
                    textBox1.Enabled = false;
                    break;
                case "Listening":
                    textBox1.Enabled = true;
                    break;
                case "Participation":
                    textBox1.Enabled = true;
                    break;
                case "Song":
                    textBox1.Enabled = false;
                    break;
                case "Songer":
                    textBox1.Enabled = false;
                    break;
            }
        }

        private void ChangeDatabase_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Location = new System.Drawing.Point(this.Location.X + (e.X - x), this.Location.Y + (e.Y - y));
            }
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != "")
            {
                sda = new SqlDataAdapter(@"Select * From " + comboBox1.SelectedItem.ToString(), con);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                ClearComp();
                int i = 0;
                int cnt = dt.Columns.Count;
                groupBox1.Visible = true;
                foreach (Control c in groupBox1.Controls)
                {
                    if (i < cnt)
                    {
                        if (c is Label)
                        {
                            (c as Label).Text = dt.Columns[i].ToString();
                            i++;
                        }
                    }
                }
                i = 0;
                foreach (Control c in groupBox1.Controls)
                {
                    if (i < cnt)
                    {
                        if (c is TextBox)
                        {
                            (c as TextBox).Visible = true;
                            i++;
                        }
                    }
                }
                dataGridView1.Width = (dataGridView1.Columns.Count + 1) * dataGridView1.Columns[1].Width - 39;
            }
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Album_Info":
                    if ((textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != ""))
                        sda = new SqlDataAdapter(@"Insert Into Album_Info Values('" + textBox2.Text + "','" + textBox3.Text + "'," + textBox4.Text + ")", con);
                    else MessageBox.Show("Введите данные в каждое поле");
                    break;
                case "Composition_album":
                    if ((textBox1.Text != "") && (textBox2.Text != ""))
                        sda = new SqlDataAdapter(@"Insert Into Composition_Album Values(" + textBox1.Text + "," + textBox2.Text + ")", con);
                    else MessageBox.Show("Введите данные в каждое поле");
                    break;
                case "Genre":
                    if (textBox2.Text != "")
                        sda = new SqlDataAdapter(@"Insert Into Genre Values('" + textBox2.Text + "')", con);
                      else MessageBox.Show("Введите данные в каждое поле");
                    break;
                case "Groups":
                    if (textBox2.Text != "")
                        sda = new SqlDataAdapter(@"Insert Into Groups Values('" + textBox2.Text + "'", con);
                      else MessageBox.Show("Введите данные в каждое поле");
                    break;
                case "Listening":
                    if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "")) 
                        sda = new SqlDataAdapter(@"Insert Into Listening Values(" + textBox1.Text + "," + textBox2.Text + ",'" + textBox3.Text + "')", con);
                      else MessageBox.Show("Введите данные в каждое поле");
                    break;
                case "Participation":
                    if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") && (textBox5.Text != ""))
                        sda = new SqlDataAdapter(@"Insert Into Participation Values(" + textBox1.Text + "," + textBox2.Text + ",'" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", con);
                      else MessageBox.Show("Введите данные в каждое поле");
                    break;
                case "Song":
                    if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != ""))
                        sda = new SqlDataAdapter(@"Insert Into Song Values('" + textBox2.Text + "','" + textBox3.Text + "'," + textBox4.Text + ")", con);
                      else MessageBox.Show("Введите данные в каждое поле");
                    break;
                case "Songer":
                    if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") && (textBox5.Text != ""))
                        sda = new SqlDataAdapter(@"Insert Into Songer Values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", con);
                      else MessageBox.Show("Введите данные в каждое поле");
                    break;
            }
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            ShowButton_Click(sender, e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Composition_album":
                    if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                        e.Handled = true;
                    break;
                case "Listening":
                    if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                        e.Handled = true;
                    break;
                case "Participation":
                    if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                        e.Handled = true;
                    break;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Album_Info")
                if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                    e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Album_Info":
                    if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                        e.Handled = true;
                    break;
                case "Song":
                    if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                        e.Handled = true;
                    break;
            }
        }

        private void ChangeDatabase_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }
    }
}