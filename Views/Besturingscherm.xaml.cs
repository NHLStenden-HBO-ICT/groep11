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
    /// Interaction logic for Besturingscherm.xaml
    /// </summary>
    public partial class Besturingscherm : Window
    {
        
        public Besturingscherm()
        {
            InitializeComponent();
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void TerugNaarHoofdmenu(object sender, RoutedEventArgs e) //button om terug te gaan naar het hoofdmenu
        {
            BeginScherm bs = new BeginScherm();
            bs.Show();
            this.Close();
        }
        private void HandleEsc(object sender, KeyEventArgs e) //Esc toets sluit besturingscherm af
        {
            if (e.Key == Key.Escape) 
            {
                BeginScherm bs = new BeginScherm();
                bs.Show();
                this.Close();
            }
        }
    }
}