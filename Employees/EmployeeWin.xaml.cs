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
    /// Логика взаимодействия для EmployeeWin.xaml
    /// </summary>
    public partial class EmployeeWin : Window
    {
        Models.EmployeesContext DB;

        public EmployeeWin()
        {
            InitializeComponent();

            DB = new Models.EmployeesContext();
            DB.Employees.Load(); // загружаем данные
            EmployeesView.ItemsSource = DB.Employees.Local.ToBindingList(); // устанавливаем привязку к кэшу

            Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DB.Dispose();
        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            DB.SaveChanges();
        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            if (EmployeesView.SelectedItems.Count > 0)
            {
                for (int i = 0; i < EmployeesView.SelectedItems.Count; i++)
                {
                    if (EmployeesView.SelectedItems[i] is Models.Employees empl)
                    {
                        DB.Employees.Remove(empl);
                    }
                }
            }
            DB.SaveChanges();
        }
    }
}
