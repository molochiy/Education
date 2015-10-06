using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITIC
{
    public partial class Form1 : Form
    {
        public SqlCommand ConnectToData()
        {
            SqlConnection connection = new SqlConnection();//)
            //{
            string connect = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Mykola\Documents\Visual Studio 2012\Projects\ITIC\ITIC\NORTHWND.MDF;Integrated Security=True;Connect Timeout=30";
            connection.ConnectionString = connect;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            return command;
        }
        public SqlDataReader ExecuteCommand(string commandToExecute, SqlCommand command)
        {
                command.CommandText = commandToExecute;
                return command.ExecuteReader();
        }

        public Form1()
        {
            InitializeComponent();

            SqlDataReader reader = ExecuteCommand(" SELECT TABLE_NAME FROM information_schema.TABLES ", ConnectToData());
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    listBoxTables.Items.Add(reader[i].ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = ConnectToData();
            BindingSource bs = new BindingSource();
            bs.DataSource = ExecuteCommand("SELECT * From " + "["+listBoxTables.SelectedItem.ToString()+"];", command);
            dataGridViewTable.DataSource = bs;            
        }
    }
}
