using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;


namespace Employees.Models
{
    public partial class Salary
    {
        [Key]
        [ForeignKey("EmployeesOf")]
        public int ID { get; set; }

        public int Pay { get; set; }

        public virtual Employees EmployeesOf { get; set; }
    }
}
