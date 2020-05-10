using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CSharpProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void RegisterUser_click(object sender, RoutedEventArgs e)
        {
            Customers customers = new Customers();
            customers.Show();
        }

        private void SignIn_click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
        }

        private void NewProduct_click(object sender, RoutedEventArgs e)
        {
            NewProduct newproduct = new NewProduct();
            newproduct.Show();
        }

        private void ListProduct_click(object sender, RoutedEventArgs e)
        {
            ListProduct listProduct = new ListProduct();
            listProduct.Show();
        }

        private void Cart_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
