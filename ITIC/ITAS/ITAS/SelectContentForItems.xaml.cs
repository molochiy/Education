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
    /// Interaction logic for SelectContentForItems.xaml
    /// </summary>
    public partial class SelectContentForItems : Window
    {
        public SelectContentForItems()
        {
            InitializeComponent();
            LabelInfo.Content = "Select content for field " + Slicer.infoAboutSelectedFields[Slicer.amount][0];
            try
            {
                MainWindow.connection.Open();
                SqlCommand command = new SqlCommand("select distinct "+ Slicer.infoAboutSelectedFields[Slicer.amount][0] + " from ["+ Slicer.nameOfTable + "]", MainWindow.connection);
                SqlDataReader reader = command.ExecuteReader();
                Slicer.contentOfFields.Clear();
                while (reader.Read())
                {                    
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        CheckBox item = new CheckBox();
                        item.Content = reader[i].ToString();
                        ListBoxContentForField.Items.Add(item);
                        Slicer.contentOfFields.Add(item);
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

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            for (int j = 0; j < Slicer.contentOfFields.Count; j++)
            {
                if ((bool)Slicer.contentOfFields[j].IsChecked)
                {
                    Slicer.infoAboutSelectedFields[Slicer.amount].Add(Slicer.contentOfFields[j].Content.ToString());
                }
            }
            Slicer.amount++;
            Close();
        }
    }
}
