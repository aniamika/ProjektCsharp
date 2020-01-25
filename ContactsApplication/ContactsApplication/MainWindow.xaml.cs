using ContactsApplication.Classes;
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

namespace ContactsApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ReadData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddContactWindow AddContactWindow = new AddContactWindow();
            AddContactWindow.Show();

            // call ReadData method after other window has been closed
            ReadData();
        }

        // read information from the table
        void ReadData()
        {
            List<Contact> contacts;
            using(SQLite.SQLiteConnection connect = new SQLite.SQLiteConnection(App.databasePath))
            {
                connect.CreateTable<Contact>();
                // add method which gives me a list of contacts
                contacts = connect.Table<Contact>().ToList();
            }

            // create new object - add new element to items 
            if(contacts != null)
            {
                contactsList.ItemsSource = contacts;
            }

        }

    }
}
