using GameSportschoolKees.Views;
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
    /// Interaction logic for Besturingscherm.xaml
    /// </summary>
    public partial class Besturingscherm : Window
    {
        MainWindow main;
        public Besturingscherm(MainWindow main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void TerugNaarHoofdmenu(object sender, RoutedEventArgs e) //button om terug te gaan naar het hoofdmenu
        {
            Close();
        }
        private void KeyIsEsc(object sender, KeyEventArgs e)
        {
            switch (e.Key) 
            {
                //Esc knop sluit window af
                case Key.Escape: Close(); break;
            }
        }
    }
}