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
    /// Логика взаимодействия для DepartmentWin.xaml
    /// </summary>
    public partial class DepartmentWin : Window
    {
        Models.EmployeesContext DB;

        public DepartmentWin()
        {
            InitializeComponent();

            DB = new Models.EmployeesContext();
            DB.Departments.Load(); // загружаем данные
            DepartmentsGrid.ItemsSource = DB.Departments.Local.ToBindingList(); // устанавливаем привязку к кэшу

            Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DB.Dispose();
        }

        private void UpdateButton(object sender, RoutedEventArgs e)
        {
            DB.SaveChanges();
        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            if (DepartmentsGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < DepartmentsGrid.SelectedItems.Count; i++)
                {
                    if (DepartmentsGrid.SelectedItems[i] is Models.Departments department)
                    {
                        DB.Departments.Remove(department);
                    }
                }
            }
            DB.SaveChanges();
        }

        private void EmployeeToList(object sender, RoutedEventArgs e)
        {
            Models.Departments depart = DB.Departments.Find((DepartmentsGrid.SelectedItem as Models.Departments).ID);
            EmployeeList.ItemsSource = depart.Employees.ToList();
           
        }
    }
}
