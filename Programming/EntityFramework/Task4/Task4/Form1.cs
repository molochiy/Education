using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4
{
    public partial class Form1 : Form

    {
        public Form1()
        {
            InitializeComponent();
            //AddCertificates();
            DataGridInit();
        }

        public void DataGridInit()
        {
            this.dataGridViewUsersInfo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewUsersInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewUsersInfo.Columns.Add("Name", "Ім'я");
            this.dataGridViewUsersInfo.Columns.Add("Post", "Посада");
            this.dataGridViewUsersInfo.Columns.Add("Certificate", "Сертифікат");
            this.dataGridViewUsersInfo.Columns[0].Width = 90;
            this.dataGridViewUsersInfo.Columns[1].Width = 90;
            this.dataGridViewUsersInfo.Columns[2].Width = 270;
            this.dataGridViewUsersInfo.ReadOnly = true;
        }

        public void AddCertificates()
        {
            string line = "";
            using (var database = new UsersData())
            {
                StreamReader reader = new StreamReader(@"c:\users\mykola\documents\visual studio 2012\Projects\Task4\Task4\in.txt");
                while ((line = reader.ReadLine()) != null)
                {
                    Certificate certificate = new Certificate { Name = line };
                    database.Certificates.Add(certificate);
                    database.SaveChanges();
                }
                reader.Close();
            }
        }

        public static List<ListBox> listListsBox = new List<ListBox>();
      
        private void textBoxCertificate_TextChanged(object sender, EventArgs e)
        {            
            if (this.textBoxCertificate.Text != string.Empty)
            {
                for (int i = 0; i < listListsBox.Count; i++)
                {
                    this.Controls.Remove(listListsBox[i]);
                }
                listListsBox.Clear();

                int x = 20;
                int y = 200;
                int inter = 0;
                for (int i = 0; i < Convert.ToInt32(this.textBoxCertificate.Text); i++)
                {
                    ListBox newListBox = new ListBox();
                    
                    if (inter == 5)
                    {
                        y += 80;
                        x = 20;
                        inter = 0;
                    }
                    newListBox.Location = new Point(x + inter * 150, y);
                    inter++;
                    using (var db = new UsersData())
                    {
                        var query = from c in db.Certificates
                                    select c.Name;
                        foreach (var item in query)
                        {
                            newListBox.Items.Add(item);
                        }
                    }
                    newListBox.Width = 80;
                    newListBox.Height = 80;
                    listListsBox.Add(newListBox);
                    this.Controls.Add(newListBox);
                }
            }
        }

        private void findInDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 a = new Form2();
            a.ShowDialog();
        }
        
        static int amount = 0;

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.dataGridViewUsersInfo.Rows.Add();
            this.dataGridViewUsersInfo.Rows[amount].Cells[0].Value = this.textBoxName.Text;
            this.dataGridViewUsersInfo.Rows[amount].Cells[1].Value = this.textBoxPost.Text;
            this.dataGridViewUsersInfo.Rows[amount].Cells[2].Value = listListsBox[0].Text;
            for (int i = 1; i < listListsBox.Count; i++)
            {
                this.dataGridViewUsersInfo.Rows[amount].Cells[2].Value +=  ", " + listListsBox[i].Text;
            }
            amount ++;
            this.textBoxName.Clear();
            this.textBoxPost.Clear();
            this.textBoxCertificate.Clear();
            for (int i = 0; i < listListsBox.Count; i++)
            {
                this.Controls.Remove(listListsBox[i]);
            }
            listListsBox.Clear();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (var db = new UsersData())
            {
                for (int i = 0; i < amount; i++)
                {
                    var user = new User { Name = this.dataGridViewUsersInfo.Rows[i].Cells[0].Value.ToString(), Post = this.dataGridViewUsersInfo.Rows[i].Cells[1].Value.ToString() };                     
                    db.Users.Add(user);
                    db.SaveChanges();
                    string[] arr = this.dataGridViewUsersInfo.Rows[i].Cells[2].Value.ToString().Split(new char[] {' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    
                    for (int j = 0; j < arr.Length; j++)
                    {
                        var temp = arr[j];
                        var query = (from c in db.Certificates
                                    where c.Name == temp
                                    select c.ID).ToList()[0];

                        
                        var relation = new Relation { UserID = user.ID, CertificateID = query};
                        db.Relations.Add(relation);
                        db.SaveChanges();
                    }
                }
            }
            this.dataGridViewUsersInfo.Rows.Clear();
            this.dataGridViewUsersInfo.Columns.Clear();
            DataGridInit();
        }

        private void buttonCertificate_Click(object sender, EventArgs e)
        {

        }
    }
}
