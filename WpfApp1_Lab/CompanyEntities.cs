using System;
using System.Data.Entity;
using System.Linq;
using WpfApp1_Lab.Model;

namespace WpfApp1_Lab
{
    public class CompanyEntities : DbContext
    {
        public CompanyEntities() : base("name=CompanyEntities")
        {
        }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Person> Persons { get; set; }

    }
}