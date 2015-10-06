using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Task4
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Post { get; set; }
    }

    public class Certificate
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class Relation
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int CertificateID { get; set; }
    }

    public class UsersData : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Relation> Relations { get; set; }
    }
}
