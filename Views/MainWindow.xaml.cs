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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameSportschoolKees.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Bestruring_Click(object sender, RoutedEventArgs e)
        {
            Besturingscherm bs = new Besturingscherm(this);
            bs.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }
        public void QuitButton(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
