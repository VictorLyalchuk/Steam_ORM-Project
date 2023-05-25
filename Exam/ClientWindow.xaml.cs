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

    public partial class ClientWindow : Window
    {
        public static int MYclientID { get; set; }
        SteamContext steam = new SteamContext();
        public ClientWindow(int ID)
        {
            MYclientID = ID;
            InitializeComponent();
            LoadGame();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DateTime week = DateTime.Now.AddDays(-30);
            var Show = steam.Games.Where(g => g.ReleaseDate >= week).Include(g => g._Publisher).Include(g => g._Developer).Include(g => g._Genre).Include(g => g._SupportedLanguages).Include(g => g._Tag);
            DataGRID.ItemsSource = Show.ToList();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var Show = steam.Games.OrderByDescending(g => g.CountOfSell).Take(7).Include(g => g._Publisher).Include(g => g._Developer).Include(g => g._Genre).Include(g => g._SupportedLanguages).Include(g => g._Tag);
            DataGRID.ItemsSource = Show.ToList();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var Show = steam.Games.OrderByDescending(g => g.Raiting).Take(3).Include(g => g._Publisher).Include(g => g._Developer).Include(g => g._Genre).Include(g => g._SupportedLanguages).Include(g => g._Tag);
            DataGRID.ItemsSource = Show.ToList();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            DateTime week = DateTime.Now.AddDays(-7);
            foreach (var result91 in steam.Games.Where(a => a.ReleaseDate >= week).GroupBy(a => a.GenreID).Select(a2 => new
            {
                IDG = a2.Key,
                Count = a2.Count()
            }).OrderByDescending(b => b.Count).Take(1))
                MyClass.a = result91.IDG;

            var Show = steam.Games.Where(g => g.GenreID == MyClass.a && g.ReleaseDate >= week).Include(g => g._Publisher).Include(g => g._Developer).Include(g => g._Genre).Include(g => g._SupportedLanguages).Include(g => g._Tag);
            DataGRID.ItemsSource = Show.ToList();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            DateTime month = DateTime.Now.AddMonths(-1);
            foreach (var result91 in steam.Games.Where(a => a.ReleaseDate >= month).GroupBy(a => a.GenreID).Select(a2 => new
            {
                IDG = a2.Key,
                Count = a2.Count()
            }).OrderByDescending(b => b.Count).Take(1))
                MyClass.a = result91.IDG;
            var Show = steam.Games.Where(g => g.GenreID == MyClass.a && g.ReleaseDate >= month).Include(g => g._Publisher).Include(g => g._Developer).Include(g => g._Genre).Include(g => g._SupportedLanguages).Include(g => g._Tag);
            DataGRID.ItemsSource = Show.ToList();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            DateTime year = DateTime.Now.AddYears(-1);
            foreach (var result91 in steam.Games.Where(a => a.ReleaseDate >= year).GroupBy(a => a.GenreID).Select(a2 => new
            {
                IDG = a2.Key,
                Count = a2.Count()
            }).OrderByDescending(b => b.Count).Take(1))
                MyClass.a = result91.IDG;
            var Show = steam.Games.Where(g => g.GenreID == MyClass.a && g.ReleaseDate >= year).Include(g => g._Publisher).Include(g => g._Developer).Include(g => g._Genre).Include(g => g._SupportedLanguages).Include(g => g._Tag);
            DataGRID.ItemsSource = Show.ToList();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            List <Game> res = steam.ClientGame.Include(a => a._Game).ThenInclude(g => g._Publisher).
                                               Include(a => a._Game).ThenInclude(g => g._Developer).
                                               Include(a => a._Game).ThenInclude(g => g._Genre).
                                               Include(a => a._Game).ThenInclude(g => g._Tag).
                                               Include(a => a._Game).ThenInclude(g => g._SupportedLanguages).
                                               Where(a => a.ClientID == MYclientID).Select(a => a._Game).ToList();
            List<Game> Show = new List<Game>();
            foreach (var item in res)
            {
                Show.Add(item);
            }
            DataGRID.ItemsSource = Show.ToList();
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            var res2 = (Game)DataGRID.SelectedItem;
            var searcgame = steam.ClientGame.FirstOrDefault(a => a.GameID == res2.ID && a.ClientID == MYclientID);
            if (searcgame == null)
            {
                steam.ClientGame.Add(new ClientGame
                {
                    ClientID = MYclientID,
                    GameID = res2.ID
                });
                res2.CountOfSell++;
                steam.SaveChanges();
            }
            else
            {
                MessageBox.Show($@"The game {res2.Name} is alredy in your collection", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            LoadGame();
        }

        private void DataGRID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BuyGame.IsEnabled = true;
        }
        public void LoadGame()
        {
            var Show = steam.Games.Include(g => g._Publisher).Include(g => g._Developer).Include(g => g._Genre).Include(g => g._SupportedLanguages).Include(g => g._Tag);
            DataGRID.ItemsSource = Show.ToList();
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            LoadGame();
        }

        private void TextBoxNameGame_TextChanged(object sender, TextChangedEventArgs e)
        {
            var Show = steam.Games.Where(g => g.Name.Contains(TextBoxNameGame.Text)).Include(g => g._Publisher).Include(g => g._Developer).Include(g => g._Genre).Include(g => g._SupportedLanguages).Include(g => g._Tag);
            DataGRID.ItemsSource = Show.ToList();
        }

        private void TextBoxNameDeveloper_TextChanged(object sender, TextChangedEventArgs e)
        {
            var Show = steam.Games.Where(g => g._Developer.Name.Contains(TextBoxNameDeveloper.Text)).Include(g => g._Publisher).Include(g => g._Developer).Include(g => g._Genre).Include(g => g._SupportedLanguages).Include(g => g._Tag);
            DataGRID.ItemsSource = Show.ToList();
        }

        private void TextBoxNameGenre_TextChanged(object sender, TextChangedEventArgs e)
        {
            var Show = steam.Games.Where(g => g._Genre.Name.Contains(TextBoxNameGenre.Text)).Include(g => g._Publisher).Include(g => g._Developer).Include(g => g._Genre).Include(g => g._SupportedLanguages).Include(g => g._Tag);
            DataGRID.ItemsSource = Show.ToList();
        }
    }
}
