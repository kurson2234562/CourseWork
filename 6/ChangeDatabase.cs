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
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            dateTimePicker3.Visible = false;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowButton.Enabled = true;
            textBox3.Visible = true;
            textBox6.Visible = true;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            dateTimePicker3.Visible = false;
            ShowButton_Click(sender, e);
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
                    textBox3.Visible = false;
                    dateTimePicker1.Visible = true;
                    dateTimePicker1.Format = DateTimePickerFormat.Custom;
                    dateTimePicker1.CustomFormat = "dd.MM.yyyy HH:mm:ss";
                    dateTimePicker1.Top = 90;
                    dateTimePicker1.Left = 74;
                    dateTimePicker1.Width = 140;
                    break;
                case "Participation":
                    textBox1.Enabled = true;
                    dateTimePicker1.Visible = true;
                    dateTimePicker2.Visible = true;
                    dateTimePicker1.ShowUpDown = false;
                    dateTimePicker2.ShowUpDown = false;
                    dateTimePicker1.Format = DateTimePickerFormat.Long;
                    dateTimePicker2.Format = DateTimePickerFormat.Long;
                    textBox3.Visible = false;
                    textBox4.Visible = false;
                    dateTimePicker1.Top = 65;
                    dateTimePicker1.Width = 120;
                    dateTimePicker1.Left = 94;
                    break;
                case "Song":
                    textBox1.Enabled = false;
                    dateTimePicker1.Visible = true;
                    dateTimePicker1.Format = DateTimePickerFormat.Time;
                    dateTimePicker1.ShowUpDown = true;
                    dateTimePicker1.Top = 65;
                    dateTimePicker1.Width = 120;
                    dateTimePicker1.Left = 94;
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
                    case "Composition_Album":
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
            textBox3.Visible = false;
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
            int CNT = 0, get = 0, get1 = 0;
            DateTime get2;
            bool add = false, add1 = false, dadd = true;
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
                                add = true;
                        }
                        if (add)
                            if (int.Parse(textBox3.Text) <= 2016)
                                sda = new SqlDataAdapter(@"Insert Into Album_Info Values('" + textBox2.Text + "','" + textBox3.Text + "'," + textBox4.Text + ")", con);
                            else MessageBox.Show("Этот год ещё не наступил", "Ошибка!");
                        else MessageBox.Show("Такого исполнителя не существует");
                    }
                    else MessageBox.Show("Введите данные в каждое поле");
                    break;
                case "Composition_Album":
                    add = true; add1 = true; dadd = true;
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
                                add = false;
                        }
                        sda = new SqlDataAdapter(@"Select * From Song", con);
                        dt = new DataTable();
                        sda.Fill(dt);
                        CNT = dt.Rows.Count;
                        for (int j = 0; j < CNT; j++)
                        {
                            get1 = dt.Rows[j].Field<int>("ID_Song");
                            if (get1.ToString() == textBox2.Text.ToString())
                                add1 = false;
                        }
                        sda = new SqlDataAdapter(@"Select * From Composition_album", con);
                        dt = new DataTable();
                        sda.Fill(dt);
                        CNT = dt.Rows.Count;
                        for (int j = 0; j < CNT; j++)
                        {
                            get = dt.Rows[j].Field<int>("ID_Album");
                            get1 = dt.Rows[j].Field<int>("ID_Song");
                            if ((get.ToString() == textBox1.Text.ToString()) && (get1.ToString() == textBox2.Text.ToString()))
                            {
                                dadd = false;
                            }
                        }

                        if (!add && !add1 && dadd)
                            sda = new SqlDataAdapter(@"Insert Into Composition_Album Values(" + textBox1.Text + "," + textBox2.Text + ")", con);
                        else if (add)
                            MessageBox.Show("Такого альбома не существует");
                        else if (add1)
                            MessageBox.Show("Такой песни не существует");
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
                        sda = new SqlDataAdapter(@"Insert Into Groups Values('" + textBox2.Text + "')", con);
                    else MessageBox.Show("Введите данные в каждое поле");
                    break;
                case "Listening":
                    add = false; add1 = false; dadd = true;
                    if ((textBox1.Text != "") && (textBox2.Text != "") && (dateTimePicker1.Value != null))
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
                                add1 = true;
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
                            if ((get.ToString() == textBox1.Text.ToString()) && (get1.ToString() == textBox2.Text.ToString()) && (get2.ToString() == dateTimePicker1.Value.ToString())) 
                            {
                                dadd = false;
                            }
                        }

                        if (add && add1 && dadd) 
                            sda = new SqlDataAdapter(@"Insert Into Listening Values(" + textBox1.Text + "," + textBox2.Text + ",'" + dateTimePicker1.Value + "')", con);
                        else if (!add)
                            MessageBox.Show("Такой песни не существует");
                        else if (!add1)
                            MessageBox.Show("Такого исполнителя не существует");
                        else if (!dadd)
                            MessageBox.Show("Такая запись уже существует");
                    }
                    else MessageBox.Show("Введите данные в каждое поле");
                    break;
                case "Participation":
                    add = true;  add1 = true; dadd = true;
                    if ((textBox1.Text != "") && (textBox2.Text != "") && (dateTimePicker1.Value!= null) && (dateTimePicker2.Value!=null))
                    {
                        if (dateTimePicker1.Value <= dateTimePicker2.Value)
                        {
                            if (dateTimePicker1.Value <= DateTime.Now)
                            {
                                if (dateTimePicker2.Value <= DateTime.Now)
                                {
                                    sda = new SqlDataAdapter(@"Select * From Groups", con);
                                    dt = new DataTable();
                                    sda.Fill(dt);
                                    CNT = dt.Rows.Count;
                                    for (int j = 0; j < CNT; j++)
                                    {
                                        get = dt.Rows[j].Field<int>("ID_Group");
                                        if (get.ToString() == textBox1.Text.ToString())
                                            add = false;
                                    }
                                    sda = new SqlDataAdapter(@"Select * From Songer", con);
                                    dt = new DataTable();
                                    sda.Fill(dt);
                                    CNT = dt.Rows.Count;
                                    for (int j = 0; j < CNT; j++)
                                    {
                                        get1 = dt.Rows[j].Field<int>("ID_Songer");
                                        if (get1.ToString() == textBox2.Text.ToString())
                                            add1 = false;
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
                                    if (!add && !add1 && dadd)
                                        sda = new SqlDataAdapter(@"Insert Into Participation Values(" + textBox1.Text + "," + textBox2.Text + ",'" + dateTimePicker1.Value + "','" + dateTimePicker2.Value + "','" + textBox5.Text + "')", con);
                                    else if (add)
                                        MessageBox.Show("Такой группы не существует");
                                    else if (add1)
                                        MessageBox.Show("Такого исполнителя не существует");
                                    else if (!dadd)
                                        MessageBox.Show("Такая запись уже существует");
                                }
                                else MessageBox.Show("Исполнитель не может выйти из группы в, максимум - сегодня");
                            }
                            else MessageBox.Show("Исполнитель не может вступить группу в будущем, максимум - сегодня");
                        }
                        else MessageBox.Show("Исполнитель не мог выйти из группы раньше, чем войти");
                    }
                    else MessageBox.Show("Введите данные в каждое поле");
                    break;
                case "Song":
                    DateTime t1= new DateTime(1,1,1,0,0,0);
                    add = true; add1 = true; dadd = true;
                    if ((textBox2.Text != "") && (textBox4.Text != "") && (dateTimePicker1.Value != null))
                    {
                        if ((dateTimePicker1.Value.Hour != t1.Hour) && (dateTimePicker1.Value.Minute != t1.Minute) && (dateTimePicker1.Value.Second != t1.Second))
                        {
                            sda = new SqlDataAdapter(@"Select * From Genre", con);
                            dt = new DataTable();
                            sda.Fill(dt);
                            CNT = dt.Rows.Count;
                            for (int j = 0; j < CNT; j++)
                            {
                                get = dt.Rows[j].Field<int>("ID_Genre");

                                if (get.ToString() == textBox4.Text.ToString())
                                {
                                    add = false;
                                }
                            }
                            if (!add)
                                sda = new SqlDataAdapter(@"Insert Into Song Values('" + textBox2.Text + "','" + dateTimePicker1.Value + "'," + textBox4.Text + ")", con);
                            else
                                MessageBox.Show("Такого жанра не существует");
                        }
                        else MessageBox.Show("Длительность не может быть нулевой");
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
            if (comboBox1.SelectedItem.ToString() == "Listening")
            {
                textBox3.Visible = false;
            }
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

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if ((numericUpDown1.Value <= dt.Rows.Count) && (numericUpDown1.Value != 0))
                switch (comboBox1.SelectedItem.ToString())
                {
                    case "Participation":
                        sda = new SqlDataAdapter(@"DELETE FROM " + comboBox1.SelectedItem.ToString() + " Where " + dt.Columns[0] + " IN (Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[0] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + "= Test." + dt.Columns[0] + " WHERE SrNo = " + numericUpDown1.Value + ") and " + dt.Columns[1] + " IN (Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[1] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[1] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[1] + "= Test." + dt.Columns[1] + " WHERE SrNo = " + numericUpDown1.Value + ")", con);
                        break;
                    case "Listening":
                        sda = new SqlDataAdapter(@"DELETE FROM " + comboBox1.SelectedItem.ToString() + " Where " + dt.Columns[0] + " IN (Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[0] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + "= Test." + dt.Columns[0] + " WHERE SrNo = " + numericUpDown1.Value + ") and " + dt.Columns[1] + " IN (Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[1] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[1] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[1] + "= Test." + dt.Columns[1] + " WHERE SrNo = " + numericUpDown1.Value + ")", con);
                        break;
                    case "Composition_Album":
                        sda = new SqlDataAdapter(@"DELETE FROM " + comboBox1.SelectedItem.ToString() + " Where " + dt.Columns[0] + " IN (Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[0] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + "= Test." + dt.Columns[0] + " WHERE SrNo = " + numericUpDown1.Value + ") and " + dt.Columns[1] + " IN (Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[1] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[1] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[1] + "= Test." + dt.Columns[1] + " WHERE SrNo = " + numericUpDown1.Value + ")", con);
                        break;
                    default:
                        sda = new SqlDataAdapter(@"DELETE FROM " + comboBox1.SelectedItem.ToString() + " Where " + dt.Columns[0] + " =(Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[0] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + "= Test." + dt.Columns[0] + " WHERE SrNo = " + numericUpDown1.Value + ")", con);
                        break;
                }
            else MessageBox.Show("Записи с таким индексом не существует","Error!");
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            ShowButton_Click(sender, e);
            if (comboBox1.SelectedItem.ToString() == "Listening")
            {
                textBox3.Visible = false;
            }
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
            if (comboBox3.SelectedItem.ToString() == "DateTime_Listening")
            {
                dateTimePicker3.Visible = true;
                dateTimePicker3.Format = DateTimePickerFormat.Custom;
                dateTimePicker3.CustomFormat = "dd.MM.yyyy HH:mm:ss";
                textBox6.Visible = false;
            }
            else if (comboBox3.SelectedItem.ToString() == "Date_in" || comboBox3.SelectedItem.ToString() == "Date_out")
            {
                dateTimePicker3.Visible = true;
                dateTimePicker3.ShowUpDown = false;
                dateTimePicker3.Format = DateTimePickerFormat.Long;
                textBox6.Visible = false;
            }
            else if (comboBox3.SelectedItem.ToString() == "Duration")
            {
                dateTimePicker3.Visible = true;
                dateTimePicker3.Format = DateTimePickerFormat.Time;
                dateTimePicker3.ShowUpDown = true;
                textBox6.Visible = false;
            }
            else
            {
                dateTimePicker3.Visible = false;
                textBox6.Visible = true;
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            int i = 0, I = 0;
            int CNT = 0, get = 0, get1 = 0;
            DateTime get2;
            string get3="";
            bool add = false, add1 = false, dadd = true;
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
            if (((textBox6.Text != "") || dateTimePicker3.Value != null) && ((comboBox2.SelectedItem.ToString() != "") && (comboBox3.SelectedItem.ToString() != ""))) 
            {
                switch (comboBox1.SelectedItem.ToString())
                {
                    case "Album_Info":
                        switch (comboBox3.SelectedItem.ToString())
                        {
                            case "ID_Songer":
                                add = false;
                                sda = new SqlDataAdapter(@"Select * From Songer", con);
                                dt = new DataTable();
                                sda.Fill(dt);
                                CNT = dt.Rows.Count;
                                for (int j = 0; j < CNT; j++)
                                {
                                    get = dt.Rows[j].Field<int>("ID_Songer");
                                    if (get.ToString() == textBox6.Text.ToString())
                                        add = true;
                                }
                                if (add)
                                {
                                    sda = new SqlDataAdapter(@"UPDATE Album_INFO SET ID_Songer = " + textBox6.Text + " Where ID_Album = (Select Album_Info.ID_Album FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, ID_Album FROM Album_Info) as Test INNER JOIN Album_Info ON Album_Info.ID_Album= Test.ID_Album WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                                }
                                else MessageBox.Show("Такого исполнителя не существует");
                                break;
                            case "Year_of_issue":
                                if (int.Parse(textBox6.Text) <= 2016)
                                    sda = new SqlDataAdapter(@"UPDATE Album_INFO SET Year_of_issue = " + textBox6.Text + " Where ID_Album = (Select Album_Info.ID_Album FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, ID_Album FROM Album_Info) as Test INNER JOIN Album_Info ON Album_Info.ID_Album= Test.ID_Album WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                                else MessageBox.Show("Этот год ещё не наступил", "Ошибка!");
                                break;
                            default:
                                MessageBox.Show("UPDATE Album_INFO SET " + comboBox3.SelectedItem.ToString() + " = " + textBox6.Text + " Where ID_Album = (Select Album_Info.ID_Album FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, ID_Album FROM Album_Info) as Test INNER JOIN Album_Info ON Album_Info.ID_Album= Test.ID_Album WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")");
                                sda = new SqlDataAdapter(@"UPDATE Album_INFO SET " + comboBox3.SelectedItem.ToString() + " = '" + textBox6.Text + "' Where ID_Album = (Select Album_Info.ID_Album FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, ID_Album FROM Album_Info) as Test INNER JOIN Album_Info ON Album_Info.ID_Album= Test.ID_Album WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                                break;

                        }
                        break;
                    case "Composition_Album":
                        add = true; add1 = false; dadd = true;
                        switch (comboBox3.SelectedItem.ToString())
                        {
                            case "ID_Album":
                                sda = new SqlDataAdapter(@"Select * From Album_info", con);
                                dt = new DataTable();
                                sda.Fill(dt);
                                CNT = dt.Rows.Count;
                                for (int j = 0; j < CNT; j++)
                                {
                                    get = dt.Rows[j].Field<int>("ID_Album");
                                    if (get.ToString() == textBox6.Text.ToString())
                                        add = false;
                                }
                                sda = new SqlDataAdapter(@"Select * From Composition_album", con);
                                dt = new DataTable();
                                sda.Fill(dt);
                                CNT = dt.Rows.Count;
                                for (int j = 0; j < CNT; j++)
                                {
                                    get = dt.Rows[j].Field<int>("ID_Album");
                                    get1 = dt.Rows[j].Field<int>("ID_Song");
                                    if ((get.ToString() == textBox6.Text.ToString()) && (get1.ToString() == dt.Rows[comboBox2.SelectedIndex][1].ToString()))
                                    {
                                        dadd = false;
                                    }
                                }
                                if (!add && !add1 && dadd)
                                    sda = new SqlDataAdapter(@"UPDATE Composition_album SET ID_Album=" + textBox6.Text + " Where ID_Album IN (Select Composition_album.ID_Album FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, ID_Album FROM Composition_album) as Test INNER JOIN Composition_album ON Composition_album.ID_Album= Test.ID_Album WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ") and ID_Song IN (Select Composition_album.ID_Song FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, ID_Song FROM Composition_album) as Test INNER JOIN Composition_album ON Composition_album.ID_Song= Test.ID_Song WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                                else if (add)
                                    MessageBox.Show("Такого альбома не существует");
                                else if (!dadd)
                                    MessageBox.Show("Такая запись уже существует");
                                break;
                            case "ID_Song":
                                add = true; add1 = false; dadd = true;
                                sda = new SqlDataAdapter(@"Select * From Song", con);
                                dt = new DataTable();
                                sda.Fill(dt);
                                CNT = dt.Rows.Count;
                                for (int j = 0; j < CNT; j++)
                                {
                                    get = dt.Rows[j].Field<int>("ID_Song");
                                    if (get.ToString() == textBox6.Text.ToString())
                                        add = false;
                                }
                                sda = new SqlDataAdapter(@"Select * From Composition_album", con);
                                dt = new DataTable();
                                sda.Fill(dt);
                                CNT = dt.Rows.Count;
                                for (int j = 0; j < CNT; j++)
                                {
                                    get1 = dt.Rows[j].Field<int>("ID_Album");
                                    get = dt.Rows[j].Field<int>("ID_Song");
                                    if ((get.ToString() == textBox6.Text.ToString()) && (get1.ToString() == dt.Rows[comboBox2.SelectedIndex][0].ToString()))
                                    {
                                        dadd = false;
                                    }
                                }
                                if (!add && !add1 && dadd)
                                    sda = new SqlDataAdapter(@"UPDATE Composition_album SET ID_Song=" + textBox6.Text + " Where ID_Album IN (Select Composition_album.ID_Album FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, ID_Album FROM Composition_album) as Test INNER JOIN Composition_album ON Composition_album.ID_Album= Test.ID_Album WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ") and ID_Song IN (Select Composition_album.ID_Song FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, ID_Song FROM Composition_album) as Test INNER JOIN Composition_album ON Composition_album.ID_Song= Test.ID_Song WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                                else if (add)
                                    MessageBox.Show("Такой песни не существует");
                                else if (!dadd)
                                    MessageBox.Show("Такая запись уже существует");
                                break;
                        }
                        break;
                    case "Listening":
                        add = true; add1 = false; dadd = true;
                        switch (comboBox3.SelectedItem.ToString())
                        {
                            case "ID_Songer":
                                sda = new SqlDataAdapter(@"Select * From Songer", con);
                                dt = new DataTable();
                                sda.Fill(dt);
                                CNT = dt.Rows.Count;
                                for (int j = 0; j < CNT; j++)
                                {
                                    get = dt.Rows[j].Field<int>("ID_Songer");
                                    if (get.ToString() == textBox6.Text.ToString())
                                    {
                                        MessageBox.Show("2");
                                        add = false;
                                    }
                                }
                                sda = new SqlDataAdapter(@"Select * From Listening", con);
                                dt = new DataTable();
                                sda.Fill(dt);
                                CNT = dt.Rows.Count;
                                for (int j = 0; j < CNT; j++)
                                {
                                    get1 = dt.Rows[j].Field<int>("ID_Song");
                                    get = dt.Rows[j].Field<int>("ID_Songer");
                                    get2 = dt.Rows[j].Field<DateTime>("DateTime_Listening");
                                    if ((get.ToString() == textBox6.Text.ToString()) && (get1.ToString() == dt.Rows[comboBox2.SelectedIndex][0].ToString())&& (get2.ToString()==dt.Rows[comboBox2.SelectedIndex][2].ToString()))
                                        dadd = false;
                                }
                                if (!add && !add1 && dadd)
                                    sda = new SqlDataAdapter(@"UPDATE Listening SET ID_Songer=" + textBox6.Text + " Where ID_Songer IN (Select Listening.ID_Songer FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, ID_Songer FROM Listening) as Test INNER JOIN Listening ON Listening.ID_Songer = Test.ID_Songer WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ") and ID_Song IN (Select Listening.ID_Song FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, ID_Song FROM Listening) as Test INNER JOIN Listening ON Listening.ID_Song = Test.ID_Song WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ") and DateTime_Listening IN(Select Listening.DateTime_Listening FROM(Select ROW_NUMBER() OVER(order by(select 1)) as srNO, DateTime_Listening From Listening) as Test INNER JOIN Listening ON Listening.DateTime_Listening = Test.DateTime_Listening Where srNO = " + comboBox2.SelectedItem.ToString() + ")", con);
                                else if (add)
                                    MessageBox.Show("Такого исполнителя не существует");
                                else if (!dadd)
                                    MessageBox.Show("Такая запись уже существует");
                                break;
                            case "ID_Song":
                                add = true; add1 = false; dadd = true;
                                sda = new SqlDataAdapter(@"Select * From Song", con);
                                dt = new DataTable();
                                sda.Fill(dt);
                                CNT = dt.Rows.Count;
                                for (int j = 0; j < CNT; j++)
                                {
                                    get = dt.Rows[j].Field<int>("ID_Song");
                                    if (get.ToString() == textBox6.Text.ToString())
                                        add = false;
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
                                    if ((get.ToString() == textBox6.Text.ToString()) && (get1.ToString() == dt.Rows[comboBox2.SelectedIndex][0].ToString()))
                                    {
                                        dadd = false;
                                    }
                                }
                                if (!add && !add1 && dadd)
                                    sda = new SqlDataAdapter(@"UPDATE Listening SET ID_Song=" + textBox6.Text + " Where ID_Songer IN (Select Listening.ID_Songer FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, ID_Songer FROM Listening) as Test INNER JOIN Listening ON Listening.ID_Songer = Test.ID_Songer WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ") and ID_Song IN (Select Listening.ID_Song FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, ID_Song FROM Listening) as Test INNER JOIN Listening ON Listening.ID_Song = Test.ID_Song WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ") and DateTime_Listening IN(Select Listening.DateTime_Listening FROM(Select ROW_NUMBER() OVER(order by(select 1)) as srNO, DateTime_Listening From Listening) as Test INNER JOIN Listening ON Listening.DateTime_Listening = Test.DateTime_Listening Where srNO = " + comboBox2.SelectedItem.ToString() + ")", con);
                                else if (add)
                                    MessageBox.Show("Такой песни не существует");
                                else if (!dadd)
                                    MessageBox.Show("Такая запись уже существует");
                                break;
                            default:
                                sda = new SqlDataAdapter(@"UPDATE Listening SET DateTime_Listening = '" + dateTimePicker3.Value + "' Where ID_Songer IN (Select Listening.ID_Songer FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, ID_Songer FROM Listening) as Test INNER JOIN Listening ON Listening.ID_Songer = Test.ID_Songer WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ") and ID_Song IN (Select Listening.ID_Song FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, ID_Song FROM Listening) as Test INNER JOIN Listening ON Listening.ID_Song = Test.ID_Song WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                                MessageBox.Show("UPDATE Listening SET DateTime_Listening = '" + dateTimePicker3.Value + "' Where ID_Songer IN (Select Listening.ID_Songer FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, ID_Songer FROM Listening) as Test INNER JOIN Listening ON Listening.ID_Songer = Test.ID_Songer WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ") and ID_Song IN (Select Listening.ID_Song FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, ID_Song FROM Listening) as Test INNER JOIN Listening ON Listening.ID_Song = Test.ID_Song WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")");
                                break;
                        }
                        break;
                    case "Participation":
                        switch (comboBox3.SelectedItem.ToString())
                        {
                            case "ID_Songer":
                                add = true; add1 = false; dadd = true;
                                sda = new SqlDataAdapter(@"Select * From Songer", con);
                                dt = new DataTable();
                                sda.Fill(dt);
                                CNT = dt.Rows.Count;
                                for (int j = 0; j < CNT; j++)
                                {
                                    get = dt.Rows[j].Field<int>("ID_Songer");
                                    if (get.ToString() == textBox6.Text.ToString())
                                        add = false;
                                }
                                sda = new SqlDataAdapter(@"Select * From Participation", con);
                                dt = new DataTable();
                                sda.Fill(dt);
                                CNT = dt.Rows.Count;
                                for (int j = 0; j < CNT; j++)
                                {
                                    get1 = dt.Rows[j].Field<int>("ID_Group");
                                    get = dt.Rows[j].Field<int>("ID_Songer");
                                    if ((get.ToString() == textBox6.Text.ToString()) && (get1.ToString() == dt.Rows[comboBox2.SelectedIndex][1].ToString()))
                                    {
                                        dadd = false;
                                    }
                                }
                                if (!add && !add1 && dadd)
                                    sda = new SqlDataAdapter(@"UPDATE Participation SET ID_Songer=" + textBox6.Text + " Where ID_Songer IN (Select Participation.ID_Songer FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, ID_Songer FROM Participation) as Test INNER JOIN Participation ON Participation.ID_Songer = Test.ID_Songer WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ") and ID_Group IN (Select Participation.ID_Group FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, ID_Group FROM Participation) as Test INNER JOIN Participation ON Participation.ID_Group = Test.ID_Group WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                                else if (add)
                                    MessageBox.Show("Такого исполнителя не существует");
                                else if (!dadd)
                                    MessageBox.Show("Такая запись уже существует");
                                break;
                            case "ID_Group":
                                add = true; add1 = false; dadd = true;
                                sda = new SqlDataAdapter(@"Select * From Groups", con);
                                dt = new DataTable();
                                sda.Fill(dt);
                                CNT = dt.Rows.Count;
                                for (int j = 0; j < CNT; j++)
                                {
                                    get = dt.Rows[j].Field<int>("ID_Group");
                                    if (get.ToString() == textBox6.Text.ToString())
                                        add = false;
                                }
                                sda = new SqlDataAdapter(@"Select * From Participation", con);
                                dt = new DataTable();
                                sda.Fill(dt);
                                CNT = dt.Rows.Count;
                                for (int j = 0; j < CNT; j++)
                                {
                                    get = dt.Rows[j].Field<int>("ID_Group");
                                    get1 = dt.Rows[j].Field<int>("ID_Songer");
                                    if ((get.ToString() == textBox6.Text.ToString()) && (get1.ToString() == dt.Rows[comboBox2.SelectedIndex][1].ToString()))
                                    {
                                        dadd = false;
                                    }
                                }
                                if (!add && !add1 && dadd)
                                    sda = new SqlDataAdapter(@"UPDATE Participation SET ID_Group=" + textBox6.Text + " Where ID_Songer IN (Select Participation.ID_Songer FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, ID_Songer FROM Participation) as Test INNER JOIN Participation ON Participation.ID_Songer = Test.ID_Songer WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ") and ID_Group IN (Select Participation.ID_Group FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, ID_Group FROM Participation) as Test INNER JOIN Participation ON Participation.ID_Group = Test.ID_Group WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                                else if (add)
                                    MessageBox.Show("Такой группы не существует");
                                else if (!dadd)
                                    MessageBox.Show("Такая запись уже существует");
                                break;
                            case "Role_in_group":
                                sda = new SqlDataAdapter(@"UPDATE Participation SET " + comboBox3.SelectedItem.ToString() + "='" + textBox6.Text + "' Where ID_Songer IN (Select Participation.ID_Songer FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, ID_Songer FROM Participation) as Test INNER JOIN Participation ON Participation.ID_Songer = Test.ID_Songer WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ") and ID_Group IN (Select Participation.ID_Group FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, ID_Group FROM Participation) as Test INNER JOIN Participation ON Participation.ID_Group = Test.ID_Group WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                                break;
                            default:
                                sda = new SqlDataAdapter(@"UPDATE Participation SET " + comboBox3.SelectedItem.ToString() + "='" + dateTimePicker3.Value + "' Where ID_Songer IN (Select Participation.ID_Songer FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, ID_Songer FROM Participation) as Test INNER JOIN Participation ON Participation.ID_Songer = Test.ID_Songer WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ") and ID_Group IN (Select Participation.ID_Group FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, ID_Group FROM Participation) as Test INNER JOIN Participation ON Participation.ID_Group = Test.ID_Group WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                                break;
                        }
                        break;
                    case "Song":
                        switch (comboBox3.SelectedItem.ToString())
                        {
                            case "ID_Genre":
                                add = true; add1 = false; dadd = true;
                                sda = new SqlDataAdapter(@"Select * From Genre", con);
                                dt = new DataTable();
                                sda.Fill(dt);
                                CNT = dt.Rows.Count;
                                for (int j = 0; j < CNT; j++)
                                {
                                    get = dt.Rows[j].Field<int>("ID_Genre");
                                    if (get.ToString() == textBox6.Text.ToString())
                                        add = false;
                                }
                                if (!add)
                                    sda = new SqlDataAdapter(@"UPDATE Song SET ID_Genre = " + textBox6.Text + " Where ID_Song = (Select Song.ID_Song FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, ID_Song FROM Song) as Test INNER JOIN Song ON Song.ID_Song = Test.ID_Song WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                                else MessageBox.Show("Такого жанра не существует");
                                break;
                            case "Duration":
                                add = false; add1 = false; dadd = true;
                                sda = new SqlDataAdapter(@"UPDATE Song SET Duration = '" + dateTimePicker3.Value + "' Where ID_Song = (Select Song.ID_Song FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, ID_Song FROM Song) as Test INNER JOIN Song ON Song.ID_Song = Test.ID_Song WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                                break;
                            default:
                                sda = new SqlDataAdapter(@"UPDATE Song SET " + comboBox3.SelectedItem.ToString() + " = '" + textBox6.Text + "' Where ID_Song = (Select Song.ID_Song FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, ID_Song FROM Song) as Test INNER JOIN Song ON Song.ID_Song = Test.ID_Song WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                                break;
                        }
                        break;
                    case "Songer":
                        switch (comboBox3.SelectedItem.ToString())
                        {
                            case "FIO":
                                add = true; add1 = false; dadd = true;
                                sda = new SqlDataAdapter(@"Select * From Songer", con);
                                dt = new DataTable();
                                sda.Fill(dt);
                                CNT = dt.Rows.Count;
                                for (int j = 0; j < CNT; j++)
                                {
                                    get3 = dt.Rows[j].Field<string>("FIO");
                                    MessageBox.Show(get3.ToString());
                                    if (get3.ToString() == textBox6.Text.ToString())
                                    {
                                        add = false;
                                    }
                                }
                                if (add)
                                    sda = new SqlDataAdapter(@"UPDATE Songer SET FIO = '" + textBox6.Text + "' Where ID_Songer = (Select Songer.ID_Songer FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, ID_Songer FROM Songer) as Test INNER JOIN Songer ON Songer.ID_Songer = Test.ID_Songer WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                                else MessageBox.Show("Такого исполнитель уже существует");
                                break;
                            default:
                                sda = new SqlDataAdapter(@"UPDATE Songer SET " + comboBox3.SelectedItem.ToString() + " = '" + textBox6.Text + "' Where ID_Songer = (Select Songer.ID_Songer FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, ID_Songer FROM Songer) as Test INNER JOIN Songer ON Songer.ID_Songer = Test.ID_Songer WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                                break;
                        }
                        break;
                    default:
                        sda = new SqlDataAdapter(@"UPDATE " + comboBox1.SelectedItem.ToString() + " SET " + comboBox3.SelectedItem.ToString() + "='" + textBox6.Text + "'  Where " + dt.Columns[0] + " IN (Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[0] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + "= Test." + dt.Columns[0] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                        break;
                }
                /*switch (comboBox3.SelectedItem.ToString())
                {
                    case "Year_of_issue":
                        if (int.Parse(textBox3.Text) <= 2016)
                            sda = new SqlDataAdapter(@"UPDATE " + comboBox1.SelectedItem.ToString() + " SET " + comboBox3.SelectedItem.ToString() + "=" + textBox6.Text + "  Where " + dt.Columns[0] + "IN (Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[0] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + "= Test." + dt.Columns[0] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")and " + dt.Columns[1] + " IN(Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[1] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[1] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[1] + " = Test." + dt.Columns[1] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                        else MessageBox.Show("Этот год ещё не наступил", "Ошибка!");
                        break;
                    case "ID_Songer":
                        sda = new SqlDataAdapter(@"UPDATE " + comboBox1.SelectedItem.ToString() + " SET " + comboBox3.SelectedItem.ToString() + "=" + textBox6.Text + "  Where " + dt.Columns[0] + " IN (Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[0] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + "= Test." + dt.Columns[0] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")and " + dt.Columns[1] + " IN(Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[1] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[1] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[1] + " = Test." + dt.Columns[1] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                        break;
                    case "ID_Album":
                        sda = new SqlDataAdapter(@"UPDATE " + comboBox1.SelectedItem.ToString() + " SET " + comboBox3.SelectedItem.ToString() + "=" + textBox6.Text + "  Where " + dt.Columns[0] + " IN (Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[0] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + "= Test." + dt.Columns[0] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ") and "+ dt.Columns[1] + " IN(Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[1] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[1] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[1] + " = Test." + dt.Columns[1] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                        break;
                    case "ID_Song":
                        sda = new SqlDataAdapter(@"UPDATE " + comboBox1.SelectedItem.ToString() + " SET " + comboBox3.SelectedItem.ToString() + "=" + textBox6.Text + "  Where " + dt.Columns[0] + " IN (Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[0] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + "= Test." + dt.Columns[0] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")and " + dt.Columns[1] + " IN(Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[1] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[1] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[1] + " = Test." + dt.Columns[1] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                        break;
                    case "DateTime_Listening":
                        sda = new SqlDataAdapter(@"UPDATE " + comboBox1.SelectedItem.ToString() + " SET " + comboBox3.SelectedItem.ToString() + "='" + dateTimePicker3.Value + "'  Where " + dt.Columns[0] + " IN (Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[0] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + "= Test." + dt.Columns[0] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")and " + dt.Columns[1] + " IN(Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[1] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[1] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[1] + " = Test." + dt.Columns[1] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                        break;
                    case "Date_in":
                        sda = new SqlDataAdapter(@"UPDATE " + comboBox1.SelectedItem.ToString() + " SET " + comboBox3.SelectedItem.ToString() + "='" + dateTimePicker3.Value + "'  Where " + dt.Columns[0] + " IN (Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[0] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + "= Test." + dt.Columns[0] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")and " + dt.Columns[1] + " IN(Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[1] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[1] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[1] + " = Test." + dt.Columns[1] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                        break;
                    case "Date_out":
                        sda = new SqlDataAdapter(@"UPDATE " + comboBox1.SelectedItem.ToString() + " SET " + comboBox3.SelectedItem.ToString() + "='" + dateTimePicker3.Value + "'  Where " + dt.Columns[0] + " IN (Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[0] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + "= Test." + dt.Columns[0] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")and " + dt.Columns[1] + " IN(Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[1] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[1] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[1] + " = Test." + dt.Columns[1] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                        break;
                    case "ID_Genre":
                        sda = new SqlDataAdapter(@"UPDATE " + comboBox1.SelectedItem.ToString() + " SET " + comboBox3.SelectedItem.ToString() + "=" + textBox6.Text + "  Where " + dt.Columns[0] + " IN (Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[0] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + "= Test." + dt.Columns[0] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")and " + dt.Columns[1] + " IN(Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[1] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[1] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[1] + " = Test." + dt.Columns[1] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                        break;
                    case "Duration":
                        sda = new SqlDataAdapter(@"UPDATE " + comboBox1.SelectedItem.ToString() + " SET " + comboBox3.SelectedItem.ToString() + "='" + dateTimePicker3.Value + "'  Where " + dt.Columns[0] + " IN (Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[0] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + "= Test." + dt.Columns[0] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")and " + dt.Columns[1] + " IN(Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[1] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[1] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[1] + " = Test." + dt.Columns[1] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                        break;
                    default:
                        sda = new SqlDataAdapter(@"UPDATE " + comboBox1.SelectedItem.ToString() + " SET " + comboBox3.SelectedItem.ToString() + "=" + textBox6.Text + "'  Where " + dt.Columns[0] + " IN (Select " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS SrNo, " + dt.Columns[0] + " FROM " + comboBox1.SelectedItem.ToString() + ") as Test INNER JOIN " + comboBox1.SelectedItem.ToString() + " ON " + comboBox1.SelectedItem.ToString() + "." + dt.Columns[0] + "= Test." + dt.Columns[0] + " WHERE SrNo = " + comboBox2.SelectedItem.ToString() + ")", con);
                        break;
                }*/
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                ShowButton_Click(sender, e);
                if (comboBox1.SelectedItem.ToString() == "Listening")
                {
                    textBox3.Visible = false;
                }
            }
            else
                MessageBox.Show("Введите верные данные для изменения!", "Ошибка");
            textBox6.Clear();
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