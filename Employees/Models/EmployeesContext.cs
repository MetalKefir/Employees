using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Employees.Models
{
    public class EmployeesContext : DbContext
    {
        static EmployeesContext()
        {
            Database.SetInitializer(new MyContextInitializer());
        }

        public EmployeesContext() : base("name=Model") { }

        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<Salary> Salary { get; set; }
}
}
