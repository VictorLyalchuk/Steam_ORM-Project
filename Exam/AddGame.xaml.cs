using Data_Access_Entity;
using Data_Access_Entity.Entities;
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
    public partial class AddGame : Window
    {
        SteamContext steam = new SteamContext();
        public AddGame()
        {
            InitializeComponent();
            GetOriginalGame();
            GetDeveloper();
            GetPublisher();
            GetGeenre();
            GetTag();
            SetRaiting();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (TextBoxName.Text != "" && TextBoxCostPrice.Text != "" && TextBoxPrice.Text != "" && ComboBoxRaiting.Text != "" && DataPickerDate.SelectedDate != null
                && ComboBoxGenre.Text != "" && ComboBoxDeveloper.Text != "" && ComboBoxPublisher.Text != "" && ComboBoxTag.Text != "")
            {
                string res1 = steam.Games.Where(a => a.Name == TextBoxName.Text).Select(a =>a.Name).FirstOrDefault();
                if (res1 == null)
                {
                    var genre = steam.Genres.FirstOrDefault(g => g.Name == ComboBoxGenre.Text);
                    var developer = steam.Developers.FirstOrDefault(d => d.Name == ComboBoxDeveloper.Text);
                    var publisher = steam.Publishers.FirstOrDefault(p => p.Name == ComboBoxPublisher.Text);
                    var tag = steam.Tags.FirstOrDefault(t => t.Name == ComboBoxTag.Text);

                    steam.Games.Add(
                    new Game()
                    {
                        Name = TextBoxName.Text,
                        CostPrice = int.Parse(TextBoxCostPrice.Text),
                        Price = int.Parse(TextBoxPrice.Text),
                        Raiting = int.Parse(ComboBoxRaiting.Text),
                        ReleaseDate = DataPickerDate.SelectedDate.Value,
                        CountOfSell = 0,
                        DeveloperID = developer.ID,
                        PublisherID = publisher.ID,
                        GenreID = genre.ID,
                        TagID = tag.ID,
                        OriginalGame = ComboBoxOriginalGame.Text,
                    });
                    steam.SaveChanges();
                    MessageBox.Show("Game added", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    Close();
                }
                else
                    MessageBox.Show($@"This game {TextBoxName.Text} alredy in your database", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
                MessageBox.Show("Please fill in all values", "Error", MessageBoxButton.OK, MessageBoxImage.Error);


        }
        public void GetOriginalGame()
        {
            var originalgame = steam.Games;
            foreach (var game in originalgame)
            {
                ComboBoxOriginalGame.Items.Add(game.Name);
            };
        }
        public void GetDeveloper()
        {
            var developer = steam.Developers;
            foreach (var dev in developer)
            {
                ComboBoxDeveloper.Items.Add(dev.Name);
            };
        }
        public void GetPublisher()
        {
            var publisher = steam.Publishers;
            foreach (var pub in publisher)
            {
                ComboBoxPublisher.Items.Add(pub.Name);
            };
        }
        public void GetGeenre()
        {
            var genre = steam.Genres;
            foreach (var gen in genre)
            {
                ComboBoxGenre.Items.Add(gen.Name);
            };
        }
        public void GetTag()
        {
            var tag = steam.Tags;
            foreach (var t in tag)
            {
                ComboBoxTag.Items.Add(t.Name);
            };
        }
        public void SetRaiting()
        {
            for (int a = 1; a <= 10; a++)
            {
                ComboBoxRaiting.Items.Add(a);

            }
        }
    }
}
