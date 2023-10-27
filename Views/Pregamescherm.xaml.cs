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
using System.Text.RegularExpressions;
using Game_Interaction;
using System.Windows.Markup;
using Game_Interaction.Views;

namespace GameSportschoolKees.Views
{
    /// <summary>
    /// Interaction logic for Pregamescherm.xaml
    /// </summary>
    public partial class Pregamescherm : Window
    {
        public Pregamescherm()
        {
            InitializeComponent();
        }

        private void StartKnop_Click(object sender, RoutedEventArgs e)
        {
            Speelscherm speelScherm = new Speelscherm();
            speelScherm.Show();
            this.Close();
        }  
    }
}
