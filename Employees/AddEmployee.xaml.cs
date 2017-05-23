using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.Entity;

namespace Employees
{
    /// <summary>
    /// Логика взаимодействия для AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        public Models.Employees Employee { get; set; }
        public Models.EmployeesContext OwnerDB { get; set; }

        public AddEmployee()
        {
            InitializeComponent();

            Employee = new Models.Employees();
            EmployeeAdd.DataContext = Employee;

            Models.EmployeesContext DB = new Models.EmployeesContext();

            Department.ItemsSource = DB.Departments.ToList();
            
            Position.ItemsSource = DB.Positions.ToList();

            DB.Dispose();
                        
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(Validation.GetHasError(Name) || Validation.GetHasError(Surname) || Validation.GetHasError(Patronymic)
                || Validation.GetHasError(INN) || Validation.GetHasError(Salary) || Position.SelectedItem ==null || Department.SelectedItem == null)
            {
                MessageBox.Show("Ошибки при заполнение полей");
                return;
            }



            Employee.DataBirth = DateBirth.DisplayDate;
            Employee.PositionsID = (Position.SelectedItem as Models.Positions).ID;
            Employee.DepartmentsID = (Department.SelectedItem as Models.Departments).ID;
            Employee.Salary = new Models.Salary() { Pay = Convert.ToInt16(Salary.Text) };

            OwnerDB.Employees.Add(Employee);
            OwnerDB.SaveChanges();
            

            Close();
        }
    }
}
