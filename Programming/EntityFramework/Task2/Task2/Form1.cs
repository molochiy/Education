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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.dataGridViewAnimals.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewAnimals.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewAnimals.Columns.Add("Name", "Ім'я");
            this.dataGridViewAnimals.Columns.Add("Breed", "Порода");
            this.dataGridViewAnimals.Columns.Add("Sex", "Стать");
            this.dataGridViewAnimals.Columns[0].Width = 90;
            this.dataGridViewAnimals.Columns[1].Width = 90;
            this.dataGridViewAnimals.Columns[2].Width = 90;
            this.dataGridViewAnimals.ReadOnly = true;
            
        }
        static public int amount = 0;
        private void buttonDisplay_Click(object sender, EventArgs e)
        {
            this.dataGridViewAnimals.Rows.Add();
            this.dataGridViewAnimals.Rows[amount].Cells[0].Value = this.textBoxName.Text.ToString();
            this.dataGridViewAnimals.Rows[amount].Cells[1].Value = this.textBoxBreed.Text.ToString();
            if (this.radioButtonMale.Checked == true)
            {
                this.dataGridViewAnimals.Rows[amount].Cells[2].Value = "Чоловік";
            }
            else
            {
                this.dataGridViewAnimals.Rows[amount].Cells[2].Value = "Жінка";
            }
            this.textBoxName.Clear();
            this.textBoxBreed.Clear();
            this.radioButtonMale.Checked = false;
            this.radioButtonFemale.Checked = false;
            amount++;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using(var db = new Animals())
            {
                for (int i = 0; i < amount; i++)
                {
                    var animal = new Animal { Name = this.dataGridViewAnimals.Rows[i].Cells[0].Value.ToString(), Breed = this.dataGridViewAnimals.Rows[i].Cells[1].Value.ToString(), Sex = this.dataGridViewAnimals.Rows[i].Cells[2].Value.ToString()};
                    db.AnimalSet.Add(animal);
                    db.SaveChanges();
                }                
            }
            dataGridViewAnimals.Rows.Clear();
            dataGridViewAnimals.Columns.Clear();
            this.dataGridViewAnimals.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewAnimals.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewAnimals.Columns.Add("Name", "Ім'я");
            this.dataGridViewAnimals.Columns.Add("Breed", "Порода");
            this.dataGridViewAnimals.Columns.Add("Sex", "Стать");
            this.dataGridViewAnimals.Columns[0].Width = 90;
            this.dataGridViewAnimals.Columns[1].Width = 90;
            this.dataGridViewAnimals.Columns[2].Width = 90;
            this.dataGridViewAnimals.ReadOnly = true;
            amount = 0;
        }

        

        private void пошукToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }
    }
}
