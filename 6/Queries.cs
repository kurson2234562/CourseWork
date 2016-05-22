using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace _6
{
    public partial class Queries : Form
    {
        SqlDataAdapter sda;
        DataTable dt;
        SqlConnection con = new SqlConnection();
        private int x = 0, y = 0;
        public Queries()
        {
            InitializeComponent();
        }

        private void Queries_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new System.Drawing.Point(this.Location.X + (e.X - x), this.Location.Y + (e.Y - y));
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    sda = new SqlDataAdapter(@"Select Name_genre, Name_song , Duration, FIO as Artist, case when Song.ID_Song IN (Select ID_Song From Composition_Album) then Name_Album else 'NULL' end as Album, DateTime_Listening From ((((Genre INNER JOIN Song ON Song.ID_Genre=Genre.ID_Genre) INNER JOIN Listening ON Listening.ID_Song=Song.ID_Song) INNER JOIN Songer ON Songer.ID_Songer=Listening.ID_Songer) LEFT JOIN Composition_Album ON Composition_Album.ID_Song=Song.ID_Song) LEFT JOIN Album_Info ON Album_Info.ID_Album=Composition_Album.ID_Album ORDER BY DateTime_Listening" , con);
                    dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    break;
                case 1:
                    sda = new SqlDataAdapter(@"Select Name_genre, Name_song , Duration, FIO as Artist, case when Song.ID_Song IN (Select ID_Song From Composition_Album) then Name_Album else 'NULL' end as Album, DateTime_Listening From ((((Genre INNER JOIN Song ON Song.ID_Genre=Genre.ID_Genre) INNER JOIN Listening ON Listening.ID_Song=Song.ID_Song) INNER JOIN Songer ON Songer.ID_Songer=Listening.ID_Songer) LEFT JOIN Composition_Album ON Composition_Album.ID_Song=Song.ID_Song) LEFT JOIN Album_Info ON Album_Info.ID_Album=Composition_Album.ID_Album WHERE DateTime_Listening = (Select Max(DateTime_Listening) From Listening);", con);
                    dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    break;
                case 2:
                    sda = new SqlDataAdapter(@"Select TOP 10 Count(*) as Количество_прослушиваний, FIO From Listening INNER JOIN Songer ON Listening.ID_Songer=Songer.ID_Songer Group BY FIO Order by 1 DESC", con);
                    dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    break;
                case 3:
                    sda = new SqlDataAdapter(@"Select TOP 10 Count(*) as Количество_прослушиваний, Name_Song, FIO, Name_Album From (((Listening INNER JOIN Song ON Listening.ID_Song=Song.ID_Song) INNER JOIN Composition_Album ON Composition_Album.ID_Song=Song.ID_Song) INNER JOIN Album_Info ON Album_Info.ID_Album=Composition_Album.ID_Album) INNER JOIN Songer ON Listening.ID_Songer=Songer.ID_Songer Group BY Song.ID_Song, Name_Song, Name_Album, FIO Order by 1 DESC", con);
                    dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    break;
                case 4:
                    sda = new SqlDataAdapter(@"Select TOP 10 Count(*) as Количество_прослушиваний, Name_Album, FIO From  (((Listening INNER JOIN Song ON Listening.ID_Song=Song.ID_Song)INNER JOIN Composition_Album ON Composition_Album.ID_Song=Song.ID_Song) INNER JOIN Album_Info ON Album_Info.ID_Album=Composition_Album.ID_Album) INNER JOIN Songer ON Songer.ID_Songer=Album_Info.ID_Songer Group BY Name_Album, FIO Order by 1 DESC", con);
                    dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    break;
                case 5:
                    sda = new SqlDataAdapter(@"Select TOP 5 Count(*) as Количество_прослушиваний, Name_Genre From  (Listening INNER JOIN Song ON Listening.ID_Song=Song.ID_Song)INNER JOIN Genre ON Genre.ID_Genre= Song.ID_Genre Group BY Name_genre Order by 1 DESC", con);
                    dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    break;
                default:
                    break;
            }

        }

        private void Queries_Load(object sender, EventArgs e)
        {
            con.ConnectionString = @"Data Source=.;Initial Catalog=Audio_lib; Integrated Security=true";
            con.Open();
            sda = new SqlDataAdapter(@"Select Count(*) as Count_Listening From Listening", con);
            dt = new DataTable();
            sda.Fill(dt);
            //dataGridView1.DataSource = dt;
            int get = dt.Rows[0].Field<int>("Count_Listening");
            label1.Text +=": "+get;

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txt = (TextBox)e.Control;
            txt.ReadOnly = true;
        }

        private void Queries_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }
    }
}
