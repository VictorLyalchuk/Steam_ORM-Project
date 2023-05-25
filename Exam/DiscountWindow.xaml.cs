using Data_Access_Entity;
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
using System.Windows.Shapes;

namespace WPF_Exam
{
    public partial class DiscountWindow : Window
    {
        SteamContext steam = new SteamContext();
        public DiscountWindow()
        {
            InitializeComponent();
            GetTag();
            SetDiscount();
        }
        public void GetTag()
        {
            var tag = steam.Tags;
            foreach (var t in tag)
            {
                ComboBoxTag.Items.Add(t.Name);
            };
        }
        public void SetDiscount()
        {
            for (int a = 1; a <= 100; a++)
            {
                ComboBoxDiscount.Items.Add(a);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ComboBoxTag.Text != "" && ComboBoxDiscount.Text != "")
            {

                var tag = steam.Tags.FirstOrDefault(t => t.Name == ComboBoxTag.Text);
                var res1 = steam.Games.Where(a => a.TagID == tag.ID);
                foreach (var games in res1)
                {
                    games.Price = games.Price - games.Price * int.Parse(ComboBoxDiscount.Text) / 100;
                }
                steam.SaveChanges();
                MessageBox.Show("Discount is set", "Information");
            }
            else
                MessageBox.Show("Select value", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

        }
    }
}
