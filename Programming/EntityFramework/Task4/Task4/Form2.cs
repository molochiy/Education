using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            using (var db = new UsersData())
            {
                var query = from c in db.Certificates
                            select c.Name;
                foreach (var item in query)
                {
                    listBoxCertificateFound.Items.Add(item);
                }
                listBoxCertificateFound.Width = 80;
                listBoxCertificateFound.Height = 80;
                listBoxResultFound.Width = 80;
                listBoxResultFound.Height = 80;
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            listBoxResultFound.Items.Clear();
            using (var db = new UsersData())
            {

                var subQuerry1 = (from c in db.Certificates
                                where c.Name==listBoxCertificateFound.Text
                                select c.ID).ToList()[0];

                var subQuerry2 = (from r in db.Relations
                                  where r.CertificateID == subQuerry1
                                  select r.UserID).ToList();
                if (subQuerry2.Count == 0)
                {
                    MessageBox.Show("Працівників з таким сертифікатом не знайдено.");
                }
                else
                {
                    for (int i = 0; i < subQuerry2.Count; i++)
                    {
                        var temp = subQuerry2[i];
                        var query = from u in db.Users
                                    where u.ID == temp
                                    select u.Name;

                        foreach (var item2 in query)
                        {
                            this.listBoxResultFound.Items.Add(item2);
                        }
                    }
                }                                
            }
        }
    }
}
