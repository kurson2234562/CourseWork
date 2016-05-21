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

        void showCountColumns(int i) {
            for (; i< dt.Columns.Count; i++){
                comboBox3.Items.Add(dt.Columns[i].ToString());
            }
        }

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
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new System.Drawing.Point(this.Location.X + (e.X - x), this.Location.Y + (e.Y - y));
            }
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != "")
            {
                groupBox3.Enabled = true;
                sda = new SqlDataAdapter(@"Select * From " + comboBox1.SelectedItem.ToString(), con);
                dt = new DataTable();
                //MessageBox.Show(dt.Rows[1].ToString());
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                ClearComp();
                int i = 0;
                int cnt = dt.Columns.Count;
                
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = true;
                comboBox3.Enabled = true;
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                if (dt.Rows.Count > 0)
                {
                    for (i = 0; i < dt.Rows.Count; i++)
                    {
                        comboBox2.Items.Add(i + 1);
                    }
                }
                else groupBox3.Enabled = false;
                i = 0;
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
                switch (comboBox1.SelectedItem.ToString())
                {
                    case "Album_Info":
                        showCountColumns(1);
                        break;
                    case "Composition_album":
                        showCountColumns(0);
                        break;
                    case "Genre":
                        showCountColumns(1);
                        break;
                    case "Groups":
                        showCountColumns(1);
                        break;
                    case "Listening":
                        showCountColumns(0);
                        break;
                    case "Participation":
                        showCountColumns(0);
                        break;
                    case "Song":
                        showCountColumns(1);
                        break;
                    case "Songer":
                        showCountColumns(1);
                        break;
                }
            }
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            int C = 0, I = 0;
            while (C < textBox2.Text.Length)
            {
                if (textBox2.Text[C] == '\'')
                {
                    I++;
                    if (C == 0)
                        textBox2.Text = "\'\'" + textBox2.Text.Substring(C + 1, textBox2.Text.Length - I);
                    if (C > 0 && C != textBox2.Text.Length - 1)
                        textBox2.Text = textBox2.Text.Substring(0, C) + "\'\'" + textBox2.Text.Substring(C + 1, textBox2.Text.Length - (I * 2));
                    if (C == textBox2.Text.Length - 1)
                        textBox2.Text = textBox2.Text.Substring(0, C) + "\'\'";
                    C++;
                }
                C++;
            }
            int CNT = 0, get = 0,get1=0;
            DateTime get2;
            bool add = false, dadd = true;
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Album_Info":
                    if ((textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != ""))
                    {
                        sda = new SqlDataAdapter(@"Select * From Songer", con);
                        dt = new DataTable();
                        sda.Fill(dt);
                        CNT = dt.Rows.Count;
                        for (int j=0;j< CNT; j++)
                        {
                            get = dt.Rows[j].Field <int> ("ID_Songer");
                            if (get.ToString() == textBox4.Text.ToString())
                                add = false;
                        }
                        if (!add)
                            sda = new SqlDataAdapter(@"Insert Into Album_Info Values('" + textBox2.Text + "','" + textBox3.Text + "'," + textBox4.Text + ")", con);
                        else
                            MessageBox.Show("Такого исполнителя не существует");
                    }
                    else MessageBox.Show("Введите данные в каждое поле");
                    break;
                case "Composition_Album":
                    add = false; dadd = true;
                    if ((textBox1.Text != "") && (textBox2.Text != ""))
                    {
                        sda = new SqlDataAdapter(@"Select * From Album_info", con);
                        dt = new DataTable();
                        sda.Fill(dt);
                        CNT = dt.Rows.Count;
                        for (int j = 0; j < CNT; j++)
                        {
                            get = dt.Rows[j].Field<int>("ID_Album");
                            if (get.ToString() == textBox1.Text.ToString())
                                add = true;
                        }
                        sda = new SqlDataAdapter(@"Select * From Song", con);
                        dt = new DataTable();
                        sda.Fill(dt);
                        CNT = dt.Rows.Count;
                        for (int j = 0; j < CNT; j++)
                        {
                            get1 = dt.Rows[j].Field<int>("ID_Song");
                            if (get1.ToString() == textBox2.Text.ToString())
                                add = true;
                        }
                        sda = new SqlDataAdapter(@"Select * From Composition_album", con);
                        dt = new DataTable();
                        sda.Fill(dt);
                        CNT = dt.Rows.Count;
                        for (int j = 0; j < CNT; j++)
                        {
                            get = dt.Rows[j].Field<int>("ID_Song");
                            get1 = dt.Rows[j].Field<int>("ID_Album");
                            if ((get.ToString() == textBox1.Text.ToString()) && (get1.ToString() == textBox2.Text.ToString()))
                            {
                                dadd = false;
                            }
                        }

                        if (add && dadd)
                            sda = new SqlDataAdapter(@"Insert Into Composition_Album Values(" + textBox1.Text + "," + textBox2.Text + ")", con);
                        else if (!add)
                            MessageBox.Show("Такого альбома или песни не существует");
                        else if (!dadd)
                            MessageBox.Show("Такая запись уже существует");
                        
                    }
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
                    add = false; dadd = true;
                    if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != ""))
                    {
                        sda = new SqlDataAdapter(@"Select * From Song", con);
                        dt = new DataTable();
                        sda.Fill(dt);
                        CNT = dt.Rows.Count;
                        for (int j = 0; j < CNT; j++)
                        {
                            get = dt.Rows[j].Field<int>("ID_Song");
                            if (get.ToString() == textBox1.Text.ToString())
                                add = true;
                        }
                        sda = new SqlDataAdapter(@"Select * From Songer", con);
                        dt = new DataTable();
                        sda.Fill(dt);
                        CNT = dt.Rows.Count;
                        for (int j = 0; j < CNT; j++)
                        {
                            get1 = dt.Rows[j].Field<int>("ID_Songer");
                            if (get1.ToString() == textBox2.Text.ToString())
                                add = true;
                        }
                        sda = new SqlDataAdapter(@"Select * From Listening", con);
                        dt = new DataTable();
                        sda.Fill(dt);
                        CNT = dt.Rows.Count;
                        for (int j = 0; j < CNT; j++)
                        {
                            get = dt.Rows[j].Field<int>("ID_Song");
                            get1 = dt.Rows[j].Field<int>("ID_Songer");
                            get2 = dt.Rows[j].Field<DateTime>("DateTime_Listening");
                            if ((get.ToString() == textBox1.Text.ToString()) && (get1.ToString() == textBox2.Text.ToString()) && (get2.ToString() == textBox3.Text.ToString())) 
                            {
                                dadd = false;
                            }
                        }

                        if (add && dadd)
                            sda = new SqlDataAdapter(@"Insert Into Listening Values(" + textBox1.Text + "," + textBox2.Text + ",'" + textBox3.Text + "')", con);
                        else if (!add)
                            MessageBox.Show("Такого исполнителя или песни не существует");
                        else if (!dadd)
                            MessageBox.Show("Такая запись уже существует");
                    }
                    else MessageBox.Show("Введите данные в каждое поле");
                    break;
                case "Participation":
                    add = false; dadd = true;
                    if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") && (textBox5.Text != ""))
                    {
                        sda = new SqlDataAdapter(@"Select * From Groups", con);
                        dt = new DataTable();
                        sda.Fill(dt);
                        CNT = dt.Rows.Count;
                        for (int j = 0; j < CNT; j++)
                        {
                            get = dt.Rows[j].Field<int>("ID_Group");
                            if (get.ToString() == textBox1.Text.ToString())
                                add = true;
                        }
                        sda = new SqlDataAdapter(@"Select * From Songer", con);
                        dt = new DataTable();
                        sda.Fill(dt);
                        CNT = dt.Rows.Count;
                        for (int j = 0; j < CNT; j++)
                        {
                            get1 = dt.Rows[j].Field<int>("ID_Songer");
                            if (get1.ToString() == textBox2.Text.ToString())
                                add = true;
                        }
                        sda = new SqlDataAdapter(@"Select * From Participation", con);
                        dt = new DataTable();
                        sda.Fill(dt);
                        CNT = dt.Rows.Count;
                        for (int j = 0; j < CNT; j++)
                        {
                            get = dt.Rows[j].Field<int>("ID_Group");
                            get1 = dt.Rows[j].Field<int>("ID_Songer");
                            if ((get.ToString() == textBox1.Text.ToString()) && (get1.ToString() == textBox2.Text.ToString()))
                            {
                                dadd = false;
                            }
                        }

                        if (add && dadd)
                            sda = new SqlDataAdapter(@"Insert Into Participation Values(" + textBox1.Text + "," + textBox2.Text + ",'" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", con);
                        else if (!add)
                            MessageBox.Show("Такого исполнителя или группы не существует");
                        else if (!dadd)
                            MessageBox.Show("Такая запись уже существует");
                    }
                    else MessageBox.Show("Введите данные в каждое поле");
                    break;
                case "Song":
                    add = true; dadd = true;
                    if ((textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != ""))
                    {
                        sda = new SqlDataAdapter(@"Select * From Genre", con);
                        dt = new DataTable();
                        sda.Fill(dt);
                        CNT = dt.Rows.Count;
                        for (int j = 0; j < CNT; j++)
                        {
                            get = dt.Rows[j].Field<int>("ID_Genre");
                            MessageBox.Show(get.ToString(), textBox4.Text.ToString());
                            if (get.ToString() == textBox4.Text.ToString())
                            {
                                add = false;
                                MessageBox.Show("now + "+add.ToString());
                            }
                        }
                        if (!add)
                            sda = new SqlDataAdapter(@"Insert Into Song Values('" + textBox2.Text + "','" + textBox3.Text + "'," + textBox4.Text + ")", con);
                        else
                            MessageBox.Show("Такого жанра не существует");
                    }
                    else MessageBox.Show("Введите данные в каждое поле");
                    break;
                case "Songer":
                    if ((textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") && (textBox5.Text != ""))
                        sda = new SqlDataAdapter(@"Insert Into Songer Values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", con);
                      else MessageBox.Show("Введите данные в каждое поле");
                    break;
            }
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            ShowButton_Click(sender, e);
            int i = 0;
            int cnt = dt.Columns.Count;
            foreach (Control c in groupBox1.Controls)
            {
                if (i < cnt)
                {
                    if (c is TextBox)
                    {
                        (c as TextBox).Clear();
                        i++;
                    }
                }
            }
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
            if(comboBox1.SelectedItem.ToString()=="Song")
                if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 58) && e.KeyChar != 46)
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

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if ((numericUpDown1.Value <= dt.Rows.Count) && (numericUpDown1.Value != 0))
                sda = new SqlDataAdapter(@"DELETE FROM " + comboBox1.SelectedItem.ToString() + " Where " + dt.Columns[0] + "=(Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[0] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + "= Test." + dt.Columns[0] + " WHERE SrNo = " + numericUpDown1.Value + ")", con);
            else MessageBox.Show("Записи с таким индексом не существует","Error!");
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            ShowButton_Click(sender, e);
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txt = (TextBox)e.Control;
            txt.ReadOnly = true;
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex < 0)
                MessageBox.Show("Выберите изменяемое поле", "Внимание");
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            int i = 0, I = 0;
            while (i < textBox6.Text.Length)
            {
                if (textBox6.Text[i] == '\'')
                {
                    I++;
                    if (i == 0)
                        textBox6.Text = "\'\'" + textBox6.Text.Substring(i + 1, textBox6.Text.Length - I);
                    if (i > 0 && i != textBox6.Text.Length-1) 
                        textBox6.Text = textBox6.Text.Substring(0, i) + "\'\'" + textBox6.Text.Substring(i + 1, textBox6.Text.Length - (I*2));
                    if (i == textBox6.Text.Length-1)
                        textBox6.Text = textBox6.Text.Substring(0, i) + "\'\'";
                    i++;
                }
                i++;
            }
            if ((textBox6.Text != "") && ((comboBox2.SelectedItem.ToString()!="")&&(comboBox3.SelectedItem.ToString()!="")))
            {
                switch (comboBox3.SelectedItem.ToString())
                {
                    case "Year_of_issue":
                        sda = new SqlDataAdapter(@"UPDATE " + comboBox1.SelectedItem.ToString() + " SET " + comboBox3.SelectedItem.ToString() + "=" + textBox6.Text + "  Where " + dt.Columns[0] + "=(Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[0] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + "= Test." + dt.Columns[0] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                        break;
                    case "ID_Songer":
                        sda = new SqlDataAdapter(@"UPDATE " + comboBox1.SelectedItem.ToString() + " SET " + comboBox3.SelectedItem.ToString() + "=" + textBox6.Text + "  Where " + dt.Columns[0] + "=(Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[0] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + "= Test." + dt.Columns[0] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                        break;
                    case "ID_Album":
                        sda = new SqlDataAdapter(@"UPDATE " + comboBox1.SelectedItem.ToString() + " SET " + comboBox3.SelectedItem.ToString() + "=" + textBox6.Text + "  Where " + dt.Columns[0] + "=(Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[0] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + "= Test." + dt.Columns[0] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                        break;
                    case "ID_Song":
                        sda = new SqlDataAdapter(@"UPDATE " + comboBox1.SelectedItem.ToString() + " SET " + comboBox3.SelectedItem.ToString() + "=" + textBox6.Text + "  Where " + dt.Columns[0] + "=(Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[0] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + "= Test." + dt.Columns[0] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                        break;
                    case "DateTime_Listening":
                        sda = new SqlDataAdapter(@"UPDATE " + comboBox1.SelectedItem.ToString() + " SET " + comboBox3.SelectedItem.ToString() + "=" + textBox6.Text + "  Where " + dt.Columns[0] + "=(Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[0] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + "= Test." + dt.Columns[0] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                        break;
                    case "Date_in":
                        sda = new SqlDataAdapter(@"UPDATE " + comboBox1.SelectedItem.ToString() + " SET " + comboBox3.SelectedItem.ToString() + "=" + textBox6.Text + "  Where " + dt.Columns[0] + "=(Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[0] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + "= Test." + dt.Columns[0] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                        break;
                    case "Date_out":
                        sda = new SqlDataAdapter(@"UPDATE " + comboBox1.SelectedItem.ToString() + " SET " + comboBox3.SelectedItem.ToString() + "=" + textBox6.Text + "  Where " + dt.Columns[0] + "=(Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[0] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + "= Test." + dt.Columns[0] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                        break;
                    case "ID_Genre":
                        sda = new SqlDataAdapter(@"UPDATE " + comboBox1.SelectedItem.ToString() + " SET " + comboBox3.SelectedItem.ToString() + "=" + textBox6.Text + "  Where " + dt.Columns[0] + "=(Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[0] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + "= Test." + dt.Columns[0] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                        break;
                    case "Duration":
                        sda = new SqlDataAdapter(@"UPDATE " + comboBox1.SelectedItem.ToString() + " SET " + comboBox3.SelectedItem.ToString() + "=" + textBox6.Text + "  Where " + dt.Columns[0] + "=(Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[0] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + "= Test." + dt.Columns[0] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                        break;
                    default:
                        sda = new SqlDataAdapter(@"UPDATE " + comboBox1.SelectedItem.ToString() + " SET " + comboBox3.SelectedItem.ToString() + "='" + textBox6.Text + "'  Where " + dt.Columns[0] + "=(Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[0] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + "= Test." + dt.Columns[0] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                        break;
                }
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                ShowButton_Click(sender, e);
            }
            else
                MessageBox.Show("Введите верные данные для изменения!", "Ошибка");
            textBox6.Clear();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == null && comboBox3.SelectedItem.ToString() == null)
                e.Handled = true;
                switch (comboBox3.SelectedItem.ToString())
                {
                    case "Year_of_issue":
                        if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                            e.Handled = true;
                        break;
                    case "ID_Songer":
                        if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                            e.Handled = true;
                        break;
                    case "ID_Album":
                        if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                            e.Handled = true;
                        break;
                    case "ID_Song":
                        if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                            e.Handled = true;
                        break;
                    case "DateTime_Listening":
                        if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 58) && e.KeyChar != 46)
                            e.Handled = true;
                        break;
                    case "Date_in":
                        if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 46)
                            e.Handled = true;
                        break;
                    case "Date_out":
                        if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                            e.Handled = true;
                        break;
                    case "ID_Genre":
                        if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                            e.Handled = true;
                        break;
                    case "Duration":
                        if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 58) && e.KeyChar != 46)
                            e.Handled = true;
                        break;
                }
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ChangeDatabase_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }
    }
}