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
        public Models.EmployeesContext OwnerDB { get; set; }

        public EditEmployee()
        {
            InitializeComponent();

            Models.EmployeesContext DB = new Models.EmployeesContext();

            Department.ItemsSource = DB.Departments.ToList();
            Position.ItemsSource = DB.Positions.ToList();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (Name.ToolTip != null || Surname.ToolTip != null || Patronymic.ToolTip != null
                || INN.ToolTip != null || Salary.ToolTip != null || Position.SelectedItem == null || Department.SelectedItem == null)
            {
                MessageBox.Show("Ошибки при заполнение полей");
                return;
            }


            var employee = OwnerDB.Employees.Find(Employee.ID);

            employee.Name = Name.Text;
            employee.Surname = Surname.Text;
            employee.Patronymic = Patronymic.Text;
            employee.INN = INN.Text;
            employee.DataBirth = DateBirth.DisplayDate;
            employee.PositionsID = (Position.SelectedItem as Models.Positions).ID;
            employee.DepartmentsID = (Department.SelectedItem as Models.Departments).ID;
            employee.Salary.Pay = Salary.Text ==""? 0 : Convert.ToInt16( Salary.Text);

            OwnerDB.SaveChanges();

            Close();
        }
    }
}
