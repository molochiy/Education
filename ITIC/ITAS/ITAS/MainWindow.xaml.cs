using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ITAS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Topmost = false;
        }

        static public SqlConnection connection = new SqlConnection();

        static public string pathToFile = string.Empty;

        public void CreateConnect()
        {
            connection.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" +
                                                pathToFile +
                                                ";Integrated Security=True;Connect Timeout=30";
            try
            {
                connection.Open();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void LoadTable()
        {
            try
            {
                connection.Open();
                TablesOfDB.Items.Clear();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
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
                connection.Close();
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            
            Nullable<bool> result = dlg.ShowDialog();
            
            if (result == true)
            {
                pathToFile = dlg.FileName;                
            }
            CreateConnect();
            LoadTable();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        

        private void ShowTable_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(@"SELECT * From [" + this.TablesOfDB.SelectedItem.ToString() + "];", connection);
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
                connection.Close();
            }
        }

        private void AddTable_Click(object sender, RoutedEventArgs e)
        {
            WindowAddTable w1 = new WindowAddTable();
            w1.Show();
            w1.Topmost = true;
        }

        private void EditTable_Click(object sender, RoutedEventArgs e)
        {
            EditTable et = new EditTable();
            et.Show();
            et.Topmost = true;
        }

        private void DeleteTable_Click(object sender, RoutedEventArgs e)
        {
            DeleteTable dt = new DeleteTable();
            dt.Show();
            dt.Topmost = true;
        }

        private void ButtonResresh_Click(object sender, RoutedEventArgs e)
        {
            LoadTable();
        }

        private void MenuItemSlicers_Click(object sender, RoutedEventArgs e)
        {
            Slicer cl = new Slicer();
            cl.Show();
            //cl.Topmost = true;
        }

        private void MenuItemPivotTable_Click(object sender, RoutedEventArgs e)
        {

        }        
    }
}
