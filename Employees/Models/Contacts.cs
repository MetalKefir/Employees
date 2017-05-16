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
    public partial class Contacts
    {
        [Key]
        [ForeignKey("EmployeesOf")]
        public int ID { get; set; }
        public string Country{get; set;}
        public string Region { get; set;}
        public string Area { get; set;}
        public string Locality { get; set;}
        public string Street { get; set;}
        public string House { get; set; }
        public string Housing { get; set; }
        public string Apartment { get; set; }
        public string Phone { get; set; }

        public Employees EmployeesOf { get; set; }
    }
}
