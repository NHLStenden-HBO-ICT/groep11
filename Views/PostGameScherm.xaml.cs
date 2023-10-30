using Game_interaction.Views;
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

namespace Game_Interaction.Views
{
    /// <summary>
    /// Interaction logic for PostGameScherm.xaml
    /// </summary>
    public partial class PostGameScherm : Window
    {
        MainWindow main;
        public PostGameScherm(MainWindow main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void HerstartKnop(object sender, RoutedEventArgs e) //Button om de game te herstarten
        {
            Close();
            main.Visibility = Visibility.Visible;
        }

        private void LeaderbordKnop(object sender, RoutedEventArgs e) //Button om naar de leaderbord te gaan
        {
            Close();
            main.Visibility = Visibility.Visible; 
        }

        private void HoofdmenuKnop(object sender, RoutedEventArgs e) //Button om terug te gaan naar het hoofdmenu
        {
            Close();
            main.Visibility = Visibility.Visible;
        }

        private void AfsluitenKnop(object sender, RoutedEventArgs e) //Button om alle windows af te sluiten
        {
            Application.Current.Shutdown();
        }
    }
}
