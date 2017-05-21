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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;

namespace Employees
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PositionsButton(object sender, RoutedEventArgs e)
        {
            PositionWin win = new PositionWin();
            win.Show();
        }

        private void DepartmentsButton(object sender, RoutedEventArgs e)
        {
            DepartmentWin win = new DepartmentWin();
            win.Show();
        }

        private void EmployeesButton(object sender, RoutedEventArgs e)
        {
            EmployeeWin win = new EmployeeWin();
            win.Show();
        }

    }
}
