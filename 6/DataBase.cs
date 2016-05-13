using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _6
{
    public partial class DataBase : Form
    {
        public DataBase()
        {
            InitializeComponent();
            CommandText:
            "SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax FROM Customers"
ConnectionString: "Data Source=.\SQLEXPRESS;AttachDbFilename="D:\ВМИ\For ADO\ BDTur_firmSQL.mdf'; 
Integrated Security = True; Connect Timeout = 30; User Instance = True"
            SqlDataAdapter dataAdapter = new SqlDataAdapter(CommandText, ConnectionString);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SqlCeCommand command = new SqlCeCommand(
                //"UPDATE wares SET ID = @ID, Name = @Name, Price=@Price " +
                //"WHERE (ID = @ID)");
            //command.Connection = songerTableAdapter.Connection;
            //songerTableAdapter.Adapter.UpdateCommand = command;
        }

        private void DataBase_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "audio_libDataSet.Songer". При необходимости она может быть перемещена или удалена.
            this.songerTableAdapter.Fill(this.audio_libDataSet.Songer);

        }
    }
}
