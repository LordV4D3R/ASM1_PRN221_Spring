using ASM01BusinessObjects.Models;
using ASM01Services;
using Microsoft.Extensions.Configuration;
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

namespace ASM01Wpf
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private ICustomerService _customerService;
        private IConfiguration _configuration;
        public Login()
        {
            InitializeComponent();
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _customerService = new CustomerService();
        }

        private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtEmail.Focus();
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!string.IsNullOrEmpty(txtEmail.Text) && txtEmail.Text.Length > 0)
            {
                textEmail.Visibility = Visibility.Collapsed;
            }
            else
            {
                textEmail.Visibility = Visibility.Visible;
            }
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPassword.Focus();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Password) && txtPassword.Password.Length > 0)
            {
                textPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                textPassword.Visibility = Visibility.Visible;
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Signinbtn(object sender, RoutedEventArgs e)
        {
            Customer customer = _customerService.GetCustomerByEmail(txtEmail.Text.Trim());

            string username = txtEmail.Text.Trim();
            string password = txtPassword.Password.Trim();

            string adminUsername = _configuration["DefaultAdminAccount:Email"];
            string adminPassword = _configuration["DefaultAdminAccount:Password"];

            if (customer != null && txtPassword.Password.Trim().Equals(customer.Password))
            {
                var userInfo = new UserInfo();
                userInfo.Show();
                Close();
            }
            else if (username == adminUsername && password == adminPassword)
            {
                var mainAdmin = new MainAdmin();
                mainAdmin.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Invalid Email or Password. Please try again");
            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
