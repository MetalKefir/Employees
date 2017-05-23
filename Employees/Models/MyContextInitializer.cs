using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Models
{
    class MyContextInitializer : DropCreateDatabaseAlways<EmployeesContext>
    {
        protected override void Seed(EmployeesContext db)
        {
            Employees e1 = new Employees { Name = "Денис", Surname = "Морозов", Patronymic = "Алексеевич", DataBirth = new DateTime(1985,8,5), INN = "123587469851", Salary = new Salary() { Pay=null} };
            Employees e2 = new Employees { Name = "Димитрий", Surname = "Гатилов", Patronymic = "Вечеславович", DataBirth = new DateTime(1996, 3, 9), INN = "568942789513", Salary = new Salary() { Pay = null } };
            Employees e3 = new Employees { Name = "Никита", Surname = "Карпунин", Patronymic = null, DataBirth = new DateTime(1986, 7, 15), INN = "569845689851", Salary = new Salary() { Pay = null } };

            Positions p1 = new Positions { Name = "Алкаш" };
            Positions p2 = new Positions { Name = "Кодер" };

            Departments d1 = new Departments { Name = "ИТ" };
            Departments d2 = new Departments { Name = "Бухалтерия" };

            e1.Position = p1;
            e2.Position = p2;
            e3.Position = p2;

            e1.Department = d2;
            e2.Department = d1;
            e3.Department = d1;

            db.Employees.Add(e1);
            db.Employees.Add(e2);
            db.Employees.Add(e3);

            db.Positions.Add(p1);
            db.Positions.Add(p2);

            db.Departments.Add(d1);
            db.Departments.Add(d2);


            db.SaveChanges();
        }
    }
}
