using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Employees.Models
{


    public partial class Employees : IDataErrorInfo
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime? DataBirth { get; set; }
        public string INN { get; set; }

        public int? PositionsID {get; set;}
        public virtual Positions Position { get; set; }

        public int? DepartmentsID { get; set; }
        public virtual Departments Department { get; set; }


        public virtual Salary Salary { get; set; }
        public virtual Contacts Contact { get; set; }

        public Employees()
        {
            Name=Surname=Patronymic=INN = "";
        }

        public override string ToString()
        {
            return Name + " " + Surname;
        }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Name":
                        if (Regex.Match(Name, @"[^A-Za-zА-яа-я]").Success || Name == "")
                            return "Имя не может содержать цифры или спецсимволы";
                        break;
                    case "Surname":
                        if (Regex.Match(Surname, @"[^A-Za-zА-яа-я]").Success || Surname == "")
                            return "Фамилия не может содержать цифры или спецсимволы";
                        break;
                    case "Patronymic":
                        if (Patronymic != null && Regex.Match(Patronymic, @"[^A-Za-zА-яа-я]").Success || Patronymic == "")
                            return "Отчество не может содержать цифры или спецсимволы";
                        break;
                    case "INN":
                        if (Regex.Match(INN.ToString(), @"[^0-9]").Success || INN == "")
                            return "ИНН должен быть числом";
                        break;
                    case "Salary":
                        if (Regex.Match(Salary.Pay.ToString(), @"[^0-9]").Success || Salary.Pay.ToString() == "")
                            return "Зарплата должна быть числом";
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
