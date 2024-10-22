using System;
using System.Collections.Generic;
using System.Data;
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

namespace Simple_Sql_Example
{
    /// <summary>
    /// PersonPage.xaml etkileşim mantığı
    /// </summary>
    public partial class PersonPage : Page
    {
        private DatabaseManager _databaseManager;
        public PersonPage()
        {
            InitializeComponent();
            _databaseManager = new DatabaseManager();
            LoadData();

        }

        private void AddPersons_Click_Handler(object sender, RoutedEventArgs e)
        {
            string name = Name.Text;
            string lastName = LastName.Text;
            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(lastName))
            {
                _databaseManager.InsertIntoPersons("name", name, "lastName", lastName);
                LoadData();
                Name.Clear();
                LastName.Clear();
            }
            else
            {
                MessageBox.Show("Gereceli veriler mevcut degil.");
            }

        }
        private void LoadData()
        {
            // Verileri veritabanından al
            DataTable personsData = _databaseManager.GetDataFromPersons();
            PersonsDataGrid.ItemsSource = personsData.DefaultView;
        }


        private void PersonDel_Click_Handler(object sender, RoutedEventArgs e)
        {
            if (PersonsDataGrid.SelectedItem is DataRowView selectedRow)
            {
                string name = selectedRow["name"].ToString();
                string lastname = selectedRow["lastName"].ToString();

                _databaseManager.DeletePerson(name, lastname);

                LoadData();
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir satır seçin.");
            }
        }

    }
}
