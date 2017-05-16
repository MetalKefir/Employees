using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Employees.Models
{
    public partial class PlacePreviousWork
    {
        [Key]
        public int ID { get; set; }
        public DateTime Hired { get; set; }
        public DateTime Dismissed { get; set; }
        public string GroundsDismissal{ get; set; }
        public string Organization { get; set; }

        public int EmployeesID { get; set; }
        public Employees Employee { get; set; }
    }
}
