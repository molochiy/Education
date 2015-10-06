using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.textBoxFindName.Visible = false;
            this.textBoxFindBreed.Visible = false;
            this.radioButtonFindFemale.Visible = false;
            this.radioButtonFindMale.Visible = false;
            this.dataGridViewFindAnimals.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.textBoxFindName.Visible = true;
            this.textBoxFindBreed.Visible = false;
            this.radioButtonFindFemale.Visible = false;
            this.radioButtonFindMale.Visible = false;
            this.dataGridViewFindAnimals.Visible = false;
            dataGridViewFindAnimals.Rows.Clear();
            dataGridViewFindAnimals.Columns.Clear();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.textBoxFindBreed.Visible = true;
            this.textBoxFindName.Visible = false;
            this.radioButtonFindFemale.Visible = false;
            this.radioButtonFindMale.Visible = false;
            this.dataGridViewFindAnimals.Visible = false;
            dataGridViewFindAnimals.Rows.Clear();
            dataGridViewFindAnimals.Columns.Clear();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.radioButtonFindMale.Visible = true;
            this.radioButtonFindFemale.Visible = true;
            this.textBoxFindName.Visible = false;
            this.textBoxFindBreed.Visible = false;
            this.dataGridViewFindAnimals.Visible = false;
            dataGridViewFindAnimals.Rows.Clear();
            dataGridViewFindAnimals.Columns.Clear();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            this.dataGridViewFindAnimals.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewFindAnimals.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewFindAnimals.Columns.Add("Name", "Ім'я");
            this.dataGridViewFindAnimals.Columns.Add("Breed", "Порода");
            this.dataGridViewFindAnimals.Columns.Add("Sex", "Стать");
            this.dataGridViewFindAnimals.Columns[0].Width = 90;
            this.dataGridViewFindAnimals.Columns[1].Width = 90;
            this.dataGridViewFindAnimals.Columns[2].Width = 90;
            this.dataGridViewFindAnimals.ReadOnly = true;

            if (radioButton1.Checked == true)
            {
                using (var db = new Animals())
                {
                    var query = from animal in db.AnimalSet
                                where animal.Name == textBoxFindName.Text
                                select animal;
                    if (query.Count<Animal>() == 0)
                    {
                        MessageBox.Show("Тварин з таким іменем не знайдено.");
                    }
                    else
                    {
                        dataGridViewFindAnimals.Visible = true;
                        int amountFinded = 0;
                        foreach (var item in query)
                        {
                            this.dataGridViewFindAnimals.Rows.Add();
                            this.dataGridViewFindAnimals.Rows[amountFinded].Cells[0].Value = item.Name;
                            this.dataGridViewFindAnimals.Rows[amountFinded].Cells[1].Value = item.Breed;
                            this.dataGridViewFindAnimals.Rows[amountFinded].Cells[2].Value = item.Sex;
                            amountFinded++;
                        }
                    }
                }
            }
            else
            {
                if (radioButton2.Checked == true)
                {
                    using (var db = new Animals())
                    {
                        var query = from animal in db.AnimalSet
                                    where animal.Breed == textBoxFindBreed.Text
                                    select animal;
                        if (query.Count<Animal>() == 0)
                        {
                            MessageBox.Show("Тварин з такою породою не знайдено.");
                        }
                        else
                        {
                            dataGridViewFindAnimals.Visible = true;
                            int amountFinded = 0;
                            foreach (var item in query)
                            {
                                this.dataGridViewFindAnimals.Rows.Add();
                                this.dataGridViewFindAnimals.Rows[amountFinded].Cells[0].Value = item.Name;
                                this.dataGridViewFindAnimals.Rows[amountFinded].Cells[1].Value = item.Breed;
                                this.dataGridViewFindAnimals.Rows[amountFinded].Cells[2].Value = item.Sex;
                                amountFinded++;
                            }
                        }
                    }
                }
                else
                {
                    if (radioButtonFindMale.Checked || radioButtonFindFemale.Checked)
                    {
                        using (var db = new Animals())
                        {
                            string sex = string.Empty;
                            if (this.radioButtonFindMale.Checked == true)
                            {
                                sex = "Чоловік";
                            }
                            else
                            {
                                sex = "Жінка";
                            }
                            var query = from animal in db.AnimalSet
                                        where animal.Sex == sex
                                        select animal;
                            if (query.Count<Animal>() == 0)
                            {
                                MessageBox.Show("Тварин з такою статтю не знайдено.");
                            }
                            else
                            {
                                dataGridViewFindAnimals.Visible = true;
                                int amountFinded = 0;
                                foreach (var item in query)
                                {
                                    this.dataGridViewFindAnimals.Rows.Add();
                                    this.dataGridViewFindAnimals.Rows[amountFinded].Cells[0].Value = item.Name;
                                    this.dataGridViewFindAnimals.Rows[amountFinded].Cells[1].Value = item.Breed;
                                    this.dataGridViewFindAnimals.Rows[amountFinded].Cells[2].Value = item.Sex;
                                    amountFinded++;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void radioButtonFindMale_CheckedChanged(object sender, EventArgs e)
        {
            dataGridViewFindAnimals.Rows.Clear();
            dataGridViewFindAnimals.Columns.Clear();
        }

        private void radioButtonFindFemale_CheckedChanged(object sender, EventArgs e)
        {
            dataGridViewFindAnimals.Rows.Clear();
            dataGridViewFindAnimals.Columns.Clear();
        }

        
    }
}
