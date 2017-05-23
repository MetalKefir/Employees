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
using System.Collections.ObjectModel;
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

            Closing += Window_Closing;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DB.SaveChanges();
            DB.Dispose();
        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            AddEmployee win = new AddEmployee() {OwnerDB= DB };
            win.Show();

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
        }

        private void EditButton(object sender, RoutedEventArgs e)
        {
            EditEmployee win = new EditEmployee() { Employee = (EmployeesView.SelectedItem as Models.Employees), OwnerDB = DB };
            win.EmployeeEdit.DataContext = (EmployeesView.SelectedItem as Models.Employees);
            win.Show();
        }


        private void AddContact(object sender, RoutedEventArgs e)
        {
            if (EmployeesView.SelectedItem == null)
            {
                MessageBox.Show("Выберите элемент");
                return;
            }

            if ((EmployeesView.SelectedItem as Models.Employees).Contact != null)
            {
                MessageBox.Show("У данного работника уже есть контакт");
                return;
            }

            AddContact win = new AddContact() { EmpoyeeID = (EmployeesView.SelectedItem as Models.Employees).ID, OwnerDB = DB };
            win.Show();
        }

        private void DeleteContact(object sender, RoutedEventArgs e)
        {
   
            if ((EmployeesView.SelectedItem as Models.Employees).Contact == null)
            {
                MessageBox.Show("Контактов нет");
                return;
            }

            (EmployeesView.SelectedItem as Models.Employees).Contact = null;
        }

        private void ViewContact(object sender, RoutedEventArgs e)
        {
            Models.Contacts contact = (EmployeesView.SelectedItem as Models.Employees).Contact;

            if (contact == null)
            {
                ViewConact.Text = null;
                MessageBox.Show("Контактов нет");
                return;
            }

            ViewConact.Text = contact.ToString();
        }


        private void Update_Click(object sender, RoutedEventArgs e)
        {
            DB.SaveChanges();
        }
    }
}
