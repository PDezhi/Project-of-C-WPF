using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace CSharpProject
{
    /// <summary>
    /// Interaction logic for NewProduct.xaml
    /// </summary>
    public partial class NewProduct : Window
    {
        public NewProduct()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxTitle.Text.Length == 0)
            {
                errormessage.Text = "Enter a Title.";
                textBoxTitle.Focus();
            }
            else if (textBoxCategory.Text.Length == 0)
            {
                errormessage.Text = "Enter a Category.";
                textBoxCategory.Focus();
            }
            else if (textBoxPrice.Text.Length == 0)
            {
                errormessage.Text = "Enter a Price.";
                textBoxPrice.Focus();
            }
            else if (textBoxDescription.Text.Length == 0)
            {
                errormessage.Text = "Enter a Description.";
                textBoxDescription.Focus();
            }
            else
            {
                string title = textBoxTitle.Text;
                string category = textBoxCategory.Text;
                string description = textBoxDescription.Text;
                decimal price = default;
                if (!decimal.TryParse(textBoxPrice.Text, out price))
                {
                    errormessage.Text = "The price you entered is not legal. Please enter a new Price.";
                    textBoxPrice.Focus();
                }
                else
                {
                    string ConStr = ConfigurationManager.ConnectionStrings["shopOnlineDatabase"].ConnectionString;

                    SqlConnection con = new SqlConnection(ConStr);

                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Products.Products(title,category,price,description) values('" + title + "','" + category + "','" + price + "','" + description + "');", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    errormessage.Text = "You have added a new production successfully.";
                    Reset();
                }
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Close();
         }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Reset();

        }
        public void Reset()
        {
            textBoxTitle.Text = "";
            textBoxCategory.Text = "";
            textBoxPrice.Text = "";
            textBoxDescription.Text = "";

        }
    }
}
