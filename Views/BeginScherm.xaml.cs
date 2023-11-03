using Game_interaction.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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

namespace Game_Interaction.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class BeginScherm : Window
    {
        public BeginScherm()
        {
            InitializeComponent();
        }
        //gaat naar het volgende scherm
        private void StartClick(object sender, RoutedEventArgs e)
        {
            Pregamescherm pregamescherm = new Pregamescherm();
            pregamescherm.Show();
            this.Close();
        }
        
        private void BClick(object sender, RoutedEventArgs e)
        {
            Besturingscherm besturingscherm = new Besturingscherm();
            besturingscherm.Show();
            this.Close();
        }


      private void LeaderboardClick(object sender, RoutedEventArgs e)
        {
           Leaderboard Lbs = new Leaderboard();
            Lbs.Show();
            this.Close();
        } 

        private void QuitClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}


