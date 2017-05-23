using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Employees.Models
{
    public partial class Contacts : IDataErrorInfo
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
            string str = " Страна: "+Country+"\n"+
                            "Регион: "+Region+"\n"+
                            "Область: "+Area+"\n"+
                            "Населеный пункт: "+Locality+"\n"+
                            "Улица: "+Street +"\n" +
                            "Дом: "+House +"\n"+
                            "Корпус: "+Housing+"\n"+
                            "Квартира: "+Apartment+"\n"+
                            "Телефон: "+Phone+"\n";
            return str;
        }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Country":
                        if (Country != null && Regex.Match(Country, @"[^A-Za-zА-яа-я]").Success || Country == "")
                            return "Страна не может содержать цифры или спецсимволы";
                        break;

                    case "Region":
                        if (Region != null && Regex.Match(Region, @"[^A-Za-zА-яа-я]").Success || Region == "")
                            return "Регион не может содержать цифры или спецсимволы";
                        break;

                    case "Area":
                        if (Area != null && Regex.Match(Area, @"[^A-Za-zА-яа-я]").Success || Area == "")
                            return "Область не может содержать цифры или спецсимволы";
                        break;

                    case "Locality":
                        if (Locality != null && Regex.Match(Locality, @"[^A-Za-zА-яа-я]").Success || Locality == "")
                            return "Населенный пункт не может содержать цифры или спецсимволы";
                        break;

                    case "Street":
                        if (Street != null && Regex.Match(Street, @"[^A-Za-zА-яа-я]").Success || Street == "")
                            return "Улица не может содержать цифры или спецсимволы";
                        break;

                    case "House":
                        if (House != null && Regex.Match(House, @"[^0-9]").Success || House == "")
                            return "Номер дома должен быть числом";
                        break;

                    case "Housing":
                        if (Housing != null && Regex.Match(Housing, @"[^0-9]").Success)
                            return "Корпус должен быть числом";
                        break;

                    case "Apartment":
                        if (Apartment != null && Regex.Match(Apartment, @"[^0-9]").Success || Apartment == "")
                            return "Квартира должна быть числом";
                        break;

                    case "Phone":
                        if (Phone != null && !Regex.Match(Phone, @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$").Success || Phone == "")
                            return "Не верный формат номера";
                        break;
                }
                return error;
            }
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }
    }
}
