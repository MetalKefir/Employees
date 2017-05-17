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
    /// Логика взаимодействия для PositionWin.xaml
    /// </summary>
    public partial class PositionWin : Window
    {
        Models.EmployeesContext DB;

        public PositionWin()
        {
            InitializeComponent();

            DB = new Models.EmployeesContext();
            DB.Positions.Load(); // загружаем данные
            PositionsGrid.ItemsSource = DB.Positions.Local.ToBindingList(); // устанавливаем привязку к кэшу

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
            if (PositionsGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < PositionsGrid.SelectedItems.Count; i++)
                {
                    if (PositionsGrid.SelectedItems[i] is Models.Positions position)
                    {
                        DB.Positions.Remove(position);
                    }
                }
            }
            DB.SaveChanges();
        }

        private void EmployeeToList(object sender, RoutedEventArgs e)
        {
            Models.Positions pos= DB.Positions.Find((PositionsGrid.SelectedItem as Models.Positions).ID);
            EmployeeList.ItemsSource = pos.Employees.ToList();

        }
    }
}
