using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Models
{
    class MyContextInitializer : DropCreateDatabaseIfModelChanges<EmployeesContext>
    {
        protected override void Seed(EmployeesContext db)
        {
            Positions p1 = new Positions { Name = "Алкаш" };
            Positions p2 = new Positions { Name = "Кодер"};

            db.Positions.Add(p1);
            db.Positions.Add(p2);
            db.SaveChanges();
        }
    }
}
