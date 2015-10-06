using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataGridAnimals.AutoGenerateColumns = true;
            this.DataGridAnimals.IsReadOnly = true;
            this.ComboBoxSexFind.Visibility = Visibility.Hidden;
            this.TextBoxBreedFind.Visibility = Visibility.Hidden;
            this.TextBoxNameFind.Visibility = Visibility.Hidden;
        }

        public static int amount = 0;
        public static List<AnimalSet> animal = new List<AnimalSet>();
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (amount == 0) this.DataGridAnimals.ItemsSource = null;
            animal.Add(new AnimalSet{ Id = amount, Name = this.TextBoxName.Text, Breed = this.TextBoxBreed.Text, Sex = this.ComboBoxSex.Text });
            amount++;
            DataGridAnimals.ItemsSource = animal;
            DataGridAnimals.Items.Refresh();
            this.TextBoxName.Clear();
            this.TextBoxBreed.Clear();
            this.ComboBoxSex.SelectedIndex = -1;
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new Entities())
            {
                for (int i = 0; i < amount; i++)
                {
                    var animalToAdd = new AnimalSet { Name = animal[i].Name, Breed = animal[i].Breed, Sex = animal[i].Sex};
                    db.AnimalSet.Add(animalToAdd);
                    db.SaveChanges();
                }                
            }
            animal.Clear();
            amount = 0;
            this.DataGridAnimals.ItemsSource = null;
        }

        private void ButtonFind_Click(object sender, RoutedEventArgs e)
        {
            if (this.RadioButtonFindByName.IsChecked == true)
            {
                using (var db = new Entities())
                {
                    var query = from animal in db.AnimalSet
                                where animal.Name == this.TextBoxNameFind.Text
                                select animal;
                    if (query.Count<AnimalSet>() == 0)
                    {
                        MessageBox.Show("Тварин з таким іменем не знайдено.");
                        this.DataGridAnimals.ItemsSource = null;
                    }
                    else
                    {
                        List<AnimalSet> findedAnimal = new List<AnimalSet>();
                        foreach (var item in query)
                        {
                            findedAnimal.Add(item);
                        }
                        this.DataGridAnimals.ItemsSource = findedAnimal;
                        this.DataGridAnimals.Items.Refresh();
                    }
                }
            }
            else
            {
                if (this.RadioButtonFindByGreed.IsChecked == true)
                {
                    using (var db = new Entities())
                    {
                        var query = from animal in db.AnimalSet
                                    where animal.Breed == this.TextBoxBreedFind.Text
                                    select animal;
                        if (query.Count<AnimalSet>() == 0)
                        {
                            MessageBox.Show("Тварин з такою породою не знайдено.");
                            this.DataGridAnimals.ItemsSource = null;
                        }
                        else
                        {
                            List<AnimalSet> findedAnimal = new List<AnimalSet>();
                            foreach (var item in query)
                            {
                                findedAnimal.Add(item);
                            }
                            this.DataGridAnimals.ItemsSource = findedAnimal;
                            this.DataGridAnimals.Items.Refresh();
                        }
                    }
                }
                else
                {
                    if (this.RadioButtonFindBySex.IsChecked == true)
                    {
                        using (var db = new Entities())
                        {
                            var query = from animal in db.AnimalSet
                                        where animal.Sex == this.ComboBoxSexFind.Text
                                        select animal;
                            if (query.Count<AnimalSet>() == 0)
                            {
                                MessageBox.Show("Тварин з такою статтю не знайдено.");
                                this.DataGridAnimals.ItemsSource = null;
                            }
                            else
                            {
                                List<AnimalSet> findedAnimal = new List<AnimalSet>();
                                foreach (var item in query)
                                {
                                    findedAnimal.Add(item);
                                }
                                this.DataGridAnimals.ItemsSource = findedAnimal;
                                this.DataGridAnimals.Items.Refresh();
                            }
                        }
                    }
                }
            }
        }

        private void RadioButtonFindByName_Checked(object sender, RoutedEventArgs e)
        {
            this.ComboBoxSexFind.Visibility = Visibility.Hidden;
            this.TextBoxBreedFind.Visibility = Visibility.Hidden;
            this.TextBoxNameFind.Visibility = Visibility.Visible;
            animal.Clear();
        }

        private void RadioButtonFindByGreed_Checked(object sender, RoutedEventArgs e)
        {
            this.ComboBoxSexFind.Visibility = Visibility.Hidden;
            this.TextBoxBreedFind.Visibility = Visibility.Visible;
            this.TextBoxNameFind.Visibility = Visibility.Hidden;
            animal.Clear();
        }

        private void RadioButtonFindBySex_Checked(object sender, RoutedEventArgs e)
        {
            this.ComboBoxSexFind.Visibility = Visibility.Visible;
            this.TextBoxBreedFind.Visibility = Visibility.Hidden;
            this.TextBoxNameFind.Visibility = Visibility.Hidden;
            animal.Clear();
        }
    }
}
