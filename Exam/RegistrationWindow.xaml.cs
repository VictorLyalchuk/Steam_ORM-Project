using Data_Access_Entity;
using Data_Access_Entity.Entities;
using Exam;
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

namespace WPF_Exam
{
    public partial class RegistrationWindow : Window
    {
        SteamContext steam = new SteamContext();

        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxLogin.Text == "" || TextBoxPassword.Text == "" || TextBoxName.Text == "" || TextBoxEmail.Text == "")
            {
                MessageBox.Show("Username and password cannot be empty");
            }
                var searchlogin = steam.Clients.FirstOrDefault(a => a.Login == TextBoxLogin.Text);
            if (searchlogin != null)
            {
                MessageBox.Show(@$"Your login {TextBoxLogin.Text}" + "\nis alredy use in the database\nPlease, enter new login", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (searchlogin == null && TextBoxLogin.Text != "" && TextBoxPassword.Text != "" && TextBoxName.Text != "" && TextBoxEmail.Text != "")
            {
                steam.Clients.Add(new Client()
                {
                    FullName = TextBoxName.Text,
                    Email = TextBoxEmail.Text,
                    Login = TextBoxLogin.Text,
                    Password = TextBoxPassword.Text,
                });
                steam.SaveChanges();
                MessageBox.Show("Registration is complete", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
