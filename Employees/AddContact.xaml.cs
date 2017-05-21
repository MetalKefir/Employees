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
    /// Логика взаимодействия для AddContact.xaml
    /// </summary>
    public partial class AddContact : Window
    {
        private Models.EmployeesContext DB;
        public int EmpoyeeID { get; set; }
        Models.Contacts Contact { get; set; }
        public AddContact()
        {
            InitializeComponent();
            Contact = new Models.Contacts();
            
            DataContext = Contact;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            DB = new Models.EmployeesContext();
            var employee = DB.Employees.Find(EmpoyeeID);

            Contact.EmployeesOf = employee;
            DB.Contacts.Add(Contact);

            employee.Contact = Contact;

            DB.SaveChanges();
        }
    }

}
