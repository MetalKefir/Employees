using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Employees.Models
{
    public partial class Employees
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime DataBirth { get; set; }
        public string INN { get; set; }

        public int PositionsID {get; set;}
        public Positions Position { get; set; }

        public int? DepartmentsID { get; set; }
        public Departments Department { get; set; }

        public ICollection<PlacePreviousWork> PlacePreviousWork { get; set; }


        public Salary Salary { get; set; }
        public Contacts Contact { get; set; }


        public Employees()
        {
            PlacePreviousWork = new List<PlacePreviousWork>();
        }
    }
}
