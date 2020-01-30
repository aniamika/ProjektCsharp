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
        List<Contact> contacts;

        public MainWindow()
        {
            InitializeComponent();
            contacts = new List<Contact>();
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

            using(SQLite.SQLiteConnection connect = new SQLite.SQLiteConnection(App.databasePath))
            {
                connect.CreateTable<Contact>();
                // add method which gives me a list of contacts and order them
                contacts = connect.Table<Contact>().ToList().OrderBy(c => c.Name).ToList();
            }

            // create new object - add new element to items 
            if(contacts != null)
            {
                contactsList.ItemsSource = contacts;
            }

        }

        // check if the text changed
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;
            // where method allowes to filtered - make them 2 uppercase to compare the same
            var listFiltered = contacts.Where(c => c.Name.ToUpper().Contains(searchTextBox.Text.ToUpper())).ToList();
            contactsList.ItemsSource = listFiltered;

        }
    }
}
