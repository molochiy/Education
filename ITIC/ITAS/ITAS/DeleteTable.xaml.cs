using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ITAS
{
    /// <summary>
    /// Interaction logic for DeleteTable.xaml
    /// </summary>
    public partial class DeleteTable : Window
    {
        public void LoadTable()
        {
            MainWindow.connection.Open();
            ListBoxTables.Items.Clear();
            SqlCommand command = new SqlCommand();
            command.Connection = MainWindow.connection;
            command.CommandText = @" SELECT TABLE_NAME FROM information_schema.TABLES ";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    ListBoxTables.Items.Add(reader[i].ToString());
                }
            }
            MainWindow.connection.Close();
        }

        public DeleteTable()
        {
            InitializeComponent();
            LoadTable();
        }

        private void ButtonRefreshTable_Click(object sender, RoutedEventArgs e)
        {
            LoadTable();
        }

        private void ButtonDeleteTable_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.connection.Open();
            SqlCommand cmdDropTable = new SqlCommand("DROP TABLE [" + this.ListBoxTables.SelectedItem.ToString() + "]", MainWindow.connection);
            try
            {
                cmdDropTable.ExecuteNonQuery();
                MessageBox.Show("Table deleted.");
            }
            catch
            {
                MessageBox.Show("Error while deleting table.");
                return;
            }
            finally
            {
                MainWindow.connection.Close();
            }
        }
    }
}
