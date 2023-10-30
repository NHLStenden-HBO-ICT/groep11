using Game_Interaction.Views;
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
    /// Interaction logic for BeginScherm.xaml
    /// </summary>
    public partial class BeginScherm : Window
    {
        public BeginScherm()
        {
            InitializeComponent();
        }

        private void Bestruring_Click(object sender, RoutedEventArgs e) //Button om naar het besturing scherm te gaan
        {
            Besturingscherm bs = new Besturingscherm(this);
            bs.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }
        public void QuitButton(object sender, RoutedEventArgs e) //Quit button sluit alle windows af
        {
            Application.Current.Shutdown();
        }

        private void PostGameClick(object sender, RoutedEventArgs e) //Button om naar post game scherm te gaan
        {
            PostGameScherm pgs = new PostGameScherm(this);
            pgs.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }
    }
}
