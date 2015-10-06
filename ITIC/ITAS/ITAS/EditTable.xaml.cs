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
    /// Interaction logic for EditTable.xaml
    /// </summary>
    public partial class EditTable : Window
    {
        DataTable dt = new DataTable();
        public void LoadTable()
        {
            try
            {
                MainWindow.connection.Open();
                TablesOfDB.Items.Clear();
                SqlCommand command = new SqlCommand();
                command.Connection = MainWindow.connection;
                command.CommandText = @" SELECT TABLE_NAME FROM information_schema.TABLES ";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        TablesOfDB.Items.Add(reader[i].ToString());
                    }
                }
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                MainWindow.connection.Close();
            }
        }

        public EditTable()
        {
            InitializeComponent();
            LoadTable();
            DataGridShowTable.CanUserAddRows = true;
            DataGridShowTable.CanUserDeleteRows = true;
        }

        private void ButtonSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.connection.Open();

                SqlDataAdapter da = new SqlDataAdapter(@"SELECT * From [" + this.TablesOfDB.SelectedItem.ToString() + "];", MainWindow.connection);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);

                da.UpdateCommand = cb.GetUpdateCommand();
                da.Update(dt);
                MessageBox.Show("Table saved.");                
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                MainWindow.connection.Close();
            }
        }

        private void ButtonResresh_Click(object sender, RoutedEventArgs e)
        {
            LoadTable();
        }

        private void ShowTable_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.connection.Open();
                dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(@"SELECT * From [" + this.TablesOfDB.SelectedItem.ToString() + "];", MainWindow.connection);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Fill(dt);
                this.DataGridShowTable.ItemsSource = dt.DefaultView;                
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                MainWindow.connection.Close();
            }
        }        
    }
}
