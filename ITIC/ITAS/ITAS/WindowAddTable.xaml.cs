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
    /// Interaction logic for WindowAddTable.xaml
    /// </summary>
    public partial class WindowAddTable : Window
    {
        public WindowAddTable()
        {
            InitializeComponent();
            TextBoxN.Visibility = System.Windows.Visibility.Hidden;
            DataGridFields.IsReadOnly = true;
        }

        static public List<InfoAboutField> fields = new List<InfoAboutField>();
        string TableName = string.Empty;

        private bool FindField(string name)
        {
            for (int i = 0; i < fields.Count; i++)
            {
                if (fields[i].Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        private bool findTable(string name)
        {
            try
            {
                MainWindow.connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = MainWindow.connection;
                command.CommandText = @" SELECT TABLE_NAME FROM information_schema.TABLES ";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (name == reader[i].ToString())
                        {
                            MainWindow.connection.Close();
                            return true;
                        }
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
            return false;
        }

        private void ButtonCreateTable_Click(object sender, RoutedEventArgs e)
        {
            TableName = TextBoxTableName.Text.ToString();
            if (TableName == string.Empty)
            {
                MessageBox.Show("Name is empty.");
            }
            else
            {
                if (findTable(TableName))
                {
                    MessageBox.Show("Table's name is exist in DB.");
                }
                else
                {
                    if (fields.Count == 0)
                    {
                        MessageBox.Show("Cannot create table without fields");
                    }
                    else
                    {
                        try
                        {
                            MainWindow.connection.Open();
                            string commandCrateTable = "CREATE TABLE " + TableName;
                            commandCrateTable += " (";
                            for (int i = 0; i < fields.Count; i++)
                            {
                                commandCrateTable += fields[i].Name.ToString();
                                if (((fields[i].Type.ToString() == "BINARY") || (fields[i].Type.ToString() == "VARCHAR") || (fields[i].Type.ToString() == "CHAR")) && (fields[i].InfoType != 0))
                                {
                                    commandCrateTable += " " + fields[i].Type.ToString() + "(" + fields[i].InfoType.ToString() + ")";
                                }
                                else
                                {
                                    commandCrateTable += " " + fields[i].Type.ToString();
                                }
                                if (fields[i].ISNOTNULL)
                                {
                                    commandCrateTable += " not null";
                                }
                                if (fields[i].ISPRIMERYKEY)
                                {
                                    commandCrateTable += " PRIMARY KEY";
                                }
                                if ((i + 1) < fields.Count)
                                {
                                    commandCrateTable += ", ";
                                }
                            }
                            commandCrateTable += ")";
                            SqlCommand cmdCreateTable = new SqlCommand(commandCrateTable, MainWindow.connection);
                            cmdCreateTable.ExecuteNonQuery();
                            MessageBox.Show("Table created.");
                            this.Close();

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
        }

        private void AddInfo(string name, string type, int n)
        {
            bool NOTNULL = false;
            if ((bool)CheckBoxNOTNULL.IsChecked)
            {
                NOTNULL = true;
            }
            if ((bool)CheckBoxKey.IsChecked && NOTNULL)
            {
                CheckBoxKey.Visibility = System.Windows.Visibility.Hidden;
                fields.Add(new InfoAboutField(name, type, n, NOTNULL, true));
                this.CheckBoxKey.IsChecked = false;

                MessageBox.Show("Field add.");

                DataGridFields.ItemsSource = null;
                DataGridFields.ItemsSource = fields;

                this.CheckBoxNOTNULL.IsChecked = false;
                this.TextBoxFieldName.Text = string.Empty;
                this.ComboBoxTypes.SelectedIndex = 0;
                this.TextBoxN.Visibility = System.Windows.Visibility.Hidden;
                this.TextBoxN.Text = string.Empty;
            }
            else
            {
                if (!(bool)CheckBoxKey.IsChecked)
                {
                    fields.Add(new InfoAboutField(name, type, n, NOTNULL, false));

                    MessageBox.Show("Field add.");

                    DataGridFields.ItemsSource = null;
                    DataGridFields.ItemsSource = fields;

                    this.CheckBoxNOTNULL.IsChecked = false;
                    this.TextBoxFieldName.Text = string.Empty;
                    this.ComboBoxTypes.SelectedIndex = 0;
                    this.TextBoxN.Visibility = System.Windows.Visibility.Hidden;
                    this.TextBoxN.Text = string.Empty;
                }
                else
                {
                    if ((bool)CheckBoxKey.IsChecked && !NOTNULL)
                    {
                        MessageBox.Show("Field with PRIMARY KEY must be NOT NULL.");
                    }
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
        }

        private void ButtonEnterField_Click(object sender, RoutedEventArgs e)
        {
            string name = string.Empty;
            string type = string.Empty;
            name = TextBoxFieldName.Text.ToString();
            type = ComboBoxTypes.Text.ToString();
            int n = 0;
            if (name == string.Empty)
            {
                MessageBox.Show("Name empty.");
            }
            else
            {
                if (FindField(name))
                {
                    MessageBox.Show("Name exist.");
                }
                else
                {
                    if ((type == "BINARY") || (type == "VARCHAR") || (type == "CHAR"))
                    {
                        if (TextBoxN.Text.ToString() == string.Empty)
                        {
                            AddInfo(name, type, n);
                        }
                        else
                        {
                            bool result = Int32.TryParse(TextBoxN.Text.ToString(), out n);
                            if (!result || n < 0)
                            {
                                MessageBox.Show("Number aren't number or less than zero.");
                            }
                            else
                            {
                                AddInfo(name, type, n); 
                            }
                        }
                    }
                    else
                    {
                        AddInfo(name, type, n);
                    }
                }
            }      
        }

        private void ComboBoxTypes_LostMouseCapture(object sender, MouseEventArgs e)
        {
            string type = ComboBoxTypes.Text.ToString();
            if ((type == "BINARY") || (type == "VARCHAR") || (type == "CHAR"))
            {
                TextBoxN.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                TextBoxN.Visibility = System.Windows.Visibility.Hidden;
            }
        }
    }
}
