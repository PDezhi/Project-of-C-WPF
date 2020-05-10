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
using System.Windows.Shapes;

namespace CSharpProject
{
    /// <summary>
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers : Window
    {
        string ConStr = ConfigurationManager.ConnectionStrings["shopOnlineDatabase"].ConnectionString;

        public Customers()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxEmail.Text.Length == 0)
            {
                errormessage.Text = "Enter an email.";
                textBoxEmail.Focus();
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Enter a valid email.";
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
            }
            else
            {
                string name = textBoxName.Text;
                string address = textBoxAddress.Text;
                string email = textBoxEmail.Text;
                string zip = textBoxZip.Text;
                string phone = textBoxPhone.Text;
                string userName = textBoxUserName.Text;
                string password = passwordBox1.Password;
                if (passwordBox1.Password.Length == 0)
                {
                    errormessage.Text = "Enter password.";
                    passwordBox1.Focus();
                }
                else if (passwordBoxConfirm.Password.Length == 0)
                {
                    errormessage.Text = "Enter Confirm password.";
                    passwordBoxConfirm.Focus();
                }
                else if (passwordBox1.Password != passwordBoxConfirm.Password)
                {
                    errormessage.Text = "Confirm password must be same as password.";
                    passwordBoxConfirm.Focus();
                }
                else
                {

                    errormessage.Text = "";
                    SqlConnection con = new SqlConnection(ConStr);
                    con.Open();
                    //SqlCommand cmd = new SqlCommand("Insert into Members.Customers (name,address,Email,zip,phone) values('" + name + "','" + address + "','" + email + "','" + zip + "','" + phone + "');Insert into Members.Users(userName, password, customerId) values('" + userName + "', '" + password + "', '"+ " SELECT SCOPE_IDENTITY()" + "')", con);
                    SqlCommand cmd = new SqlCommand("Insert into Members.Customers (name,address,Email,zip,phone) values('" + name + "','" + address + "','" + email + "','" + zip + "','" + phone + "'); select SCOPE_IDENTITY()", con);
                    int customerId = Convert.ToInt32(cmd.ExecuteScalar());
                    SqlCommand cmd1 = new SqlCommand("Insert into Members.Users(userName, password, customerId) values('" + userName + "', '" + password + "', '"+ customerId + "')", con);
                    cmd1.CommandType = CommandType.Text;
                    cmd1.ExecuteNonQuery();
 
                    con.Close();
                    errormessage.Text = "You have Registered successfully.";
                    Reset();

                }
              
            }
        }
        public void Reset()
        {
            textBoxName.Text = "";
            textBoxAddress.Text = "";
            textBoxEmail.Text = "";
            textBoxZip.Text = "";
            textBoxPhone.Text = "";
            textBlockUserName.Text = "";
            passwordBox1.Clear();
            passwordBoxConfirm.Clear();

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
