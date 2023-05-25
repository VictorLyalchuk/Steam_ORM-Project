using Data_Access_Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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
using WPF_Exam;

namespace Exam
{
    public partial class MainWindow : Window
    {
        SteamContext steam = new SteamContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(TextBoxLogin.Text == "" || TextBoxPassword.Password.ToString() == "")
            {
                MessageBox.Show("Username and password cannot be empty");
            }

            var searchaccount = steam.Clients.FirstOrDefault(a => a.Login == TextBoxLogin.Text && a.Password == TextBoxPassword.Password.ToString() && a._Account.ID == 1);
            var searchlogin = steam.Clients.FirstOrDefault(a => a.Login == TextBoxLogin.Text);
            var searchpassword = steam.Clients.FirstOrDefault(a => a.Password == TextBoxPassword.Password.ToString());
            if (searchaccount != null)
            {
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
                this.Close();
            }
            else if (searchlogin == null)
            {
                MessageBox.Show("User not found in database!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (searchpassword == null)
            {
                MessageBox.Show("Incorrect password!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (TextBoxLogin.Text != "" && TextBoxPassword.Password.ToString() != "")
            {
                int res = steam.Clients.Where(a => a.Login == TextBoxLogin.Text).Select(a => a.ID).FirstOrDefault();
                ClientWindow clientWindow = new ClientWindow(res);
                clientWindow.Show();
                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
