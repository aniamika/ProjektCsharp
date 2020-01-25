using ContactsApplication.Classes;
using SQLite;
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

namespace ContactsApplication
{
    /// <summary>
    /// Interaction logic for AddContactWindow.xaml
    /// </summary>
    public partial class AddContactWindow : Window
    {
        public AddContactWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Save contact
            // Create new contact
            Contact contact = new Contact()
            {
                Name = name.Text,
                Email = email.Text,
                Phone = phoneNumber.Text
            };

            // connect to database by using statement
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                // create table with contact 
                // if table exist - nothing is going to happened
                connection.CreateTable<Contact>();
                // insert into a table - passed the object that need to be insert into table
                connection.Insert(contact);
            };
    
            // automatically close after click on save button (Close method is inherited from the Window Class)
            // close the connection
            Close();
        }
    }
}
