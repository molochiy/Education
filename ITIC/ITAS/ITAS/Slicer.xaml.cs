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
    /// Interaction logic for Slicer.xaml
    /// </summary>
    public partial class Slicer : Window
    {
        public Slicer()
        {
            InitializeComponent();
            LoadTable();
            ButtonSelectContent.Content ="Select content for\nselected fields\nof table";
            TablesOfDB.IsEnabled = true;
        }
        static public List<CheckBox> checkBoxes = new List<CheckBox>();
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
        static public string nameOfTable = string.Empty;
        private void ButtonSelectTable_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.connection.Open();
                nameOfTable = TablesOfDB.SelectedItem.ToString();
                SqlCommand command = new SqlCommand("select COLUMN_NAME from INFORMATION_SCHEMA.columns where TABLE_NAME=N'" + nameOfTable + "'", MainWindow.connection);
                SqlDataReader reader = command.ExecuteReader();
                checkBoxes.Clear();
                while (reader.Read())
                {                    
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        CheckBox item = new CheckBox();
                        item.Content = reader[i].ToString();
                        ListBoxFieldsOfTable.Items.Add(item);
                        checkBoxes.Add(item);
                    }                    
                }
                TablesOfDB.IsEnabled = false;
            }
            catch(SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                MainWindow.connection.Close();
            }
        }

        private void ButtonSaveAsTable_Click(object sender, RoutedEventArgs e)
        {

        }
        static public List<List<string>> infoAboutSelectedFields = new List<List<string>>();
        static public List<CheckBox> contentOfFields = new List<CheckBox>();
        static public int amount = 0;
        private void ButtonSelectContent_Click(object sender, RoutedEventArgs e)
        {            
            for (int i = 0; i < checkBoxes.Count; i++)
            {
                amount = 0;
                if ((bool)checkBoxes[i].IsChecked)
                {
                    infoAboutSelectedFields.Add(new List<string>());
                    infoAboutSelectedFields[amount].Add(checkBoxes[i].Content.ToString());
                    SelectContentForItems sc = new SelectContentForItems();
                    sc.Show();
                    sc.Topmost = true;                    
                }
            }
        }

        private void ButtonShowSlicer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.connection.Open();
                DataTable dt = new DataTable();
                string selectWhat = string.Empty;
                string selectWhere = string.Empty;
                for (int i = 0; i < infoAboutSelectedFields.Count; i++)
                {
                    selectWhat += infoAboutSelectedFields[i][0];
                    if ((i + 1) < infoAboutSelectedFields.Count)
                    {
                        selectWhat += ", ";
                    }
                    else
                    {
                        selectWhat += " ";
                    }
                    for(int j = 1; j < infoAboutSelectedFields[i].Count; j++)
                    {
                        selectWhere += infoAboutSelectedFields[i][0] + "='" + infoAboutSelectedFields[i][j]+"'";
                        if ((i + 1) < infoAboutSelectedFields.Count || (j+1) < infoAboutSelectedFields[i].Count)
                        {
                            selectWhere += ", ";
                        }                        
                    }
                }
                SqlDataAdapter da = new SqlDataAdapter(@"SELECT "+ selectWhat + " From [" + this.TablesOfDB.SelectedItem.ToString() + "] WHERE " + selectWhere, MainWindow.connection);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);

                da.Fill(dt);

                this.DataGridSlicer.ItemsSource = dt.DefaultView;
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
