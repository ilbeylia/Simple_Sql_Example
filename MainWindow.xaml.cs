using MySql.Data.MySqlClient;
using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DatabaseManager database;
        public MainWindow()
        {
            InitializeComponent();
            database = new DatabaseManager();
        }

        private void Home_Click_Handler(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new HomePage());
            MainTitle.Content = "Home Page";
        }

        private void CBS_Click_Handler(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CBSPage());
            MainTitle.Content = "CBS Page";

        }

        private void Person_Click_Handler(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PersonPage());
            MainTitle.Content = "Person Page";

        }
    }
}