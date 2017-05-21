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

namespace Employees
{
    /// <summary>
    /// Логика взаимодействия для EditEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Window
    {
        public Models.Employees Employee { get; set; }

        public EditEmployee()
        {
            InitializeComponent();

            Models.EmployeesContext DB = new Models.EmployeesContext();

            Department.ItemsSource = DB.Departments.ToList();
            Position.ItemsSource = DB.Positions.ToList();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Employee.Name = Name.Text;
            Employee.Surname = Surname.Text;
            Employee.Patronymic = Patronymic.Text;
            Employee.INN = INN.Text;
            Employee.DataBirth = DateBirth.DisplayDate;
            Employee.PositionsID = (Position.SelectedItem as Models.Positions).ID;
            Employee.DepartmentsID = (Department.SelectedItem as Models.Departments).ID;

            Close();
        }
    }
}
