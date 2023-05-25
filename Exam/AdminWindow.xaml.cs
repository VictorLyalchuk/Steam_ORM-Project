using Data_Access_Entity;
using Data_Access_Entity.Entities;
using Exam;
using Microsoft.EntityFrameworkCore;
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
    public partial class AdminWindow : Window
    {
        SteamContext steam = new SteamContext();
        public AdminWindow()
        {
            InitializeComponent();
            LoadGame();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DiscountWindow discountWindow = new DiscountWindow();
            discountWindow.Show();
            Close();

/*            var Show = steam.Games.Include(g => g._Publisher).Include(g => g._Developer).Include(g => g._Genre).Include(g => g._SupportedLanguages).Include(g => g._Tag);
            DataGRID.ItemsSource = Show.ToList();*/
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            steam.SaveChanges();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AddGame addGame = new AddGame();
            addGame.Show();
            Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var res2 = (Game)DataGRID.SelectedItem;
            steam.Games.Remove(res2);
            steam.SaveChanges();
            DataGRID.SelectedItem = null;
            var Show = steam.Games.Include(g => g._Publisher).Include(g => g._Developer).Include(g => g._Genre).Include(g => g._SupportedLanguages).Include(g => g._Tag);
            DataGRID.ItemsSource = Show.ToList();
            DeleteGame.IsEnabled = false;
        }
        private void DataGRID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DeleteGame.IsEnabled = true;
            steam.SaveChanges();

        }
        public void LoadGame()
        {
            var Show = steam.Games.Include(g => g._Publisher).Include(g => g._Developer).Include(g => g._Genre).Include(g => g._SupportedLanguages).Include(g => g._Tag);
            DataGRID.ItemsSource = Show.ToList();
        }

    }
}
