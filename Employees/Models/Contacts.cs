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

        public virtual Employees EmployeesOf { get; set; }

        public override string ToString()
        {
            string str = " Страна:"+Country+"\n"+
                            "Регион:"+Region+"\n"+
                            "Область:"+Area+"\n"+
                            "Населеный пункт:"+Locality+"\n"+
                            "Улица:"+Street +"\n" +
                            "Дом:"+House +"\n"+
                            "Корпус:"+Housing+"\n"+
                            "Квартира:"+Apartment+"\n"+
                            "Телефон:"+Phone+"\n";
            return str;
        }
    }
}
