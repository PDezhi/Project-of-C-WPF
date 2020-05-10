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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxUserName.Text.Length == 0)
            {
                errormessage.Text = "Enter User Name.";
                textBoxUserName.Focus();
            }

            else
            {
                string ConStr = ConfigurationManager.ConnectionStrings["shopOnlineDatabase"].ConnectionString;
                string userName = textBoxUserName.Text;
                string password = passwordBox.Password;
                SqlConnection con = new SqlConnection(ConStr);
                con.Open();
                SqlCommand cmd = new SqlCommand("Select password from Members.Users where userName='" + userName + "'", con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    if (password != dataSet.Tables[0].Rows[0]["password"].ToString())
                    {
                        errormessage.Text = "Your password is not matching.";

                    }
                    else
                    {
                        errormessage.Text = "Logining successes.";

                        Properties.Settings.Default.userName = textBoxUserName.Text;
                        Properties.Settings.Default.Save();
                        //string a  = Properties.Settings.Default.userName;

                    }

                }
                else
                {
                    errormessage.Text = "Sorry! Please enter existing emailid/password.";
                }
                con.Close();
            }

        }
    }
}
