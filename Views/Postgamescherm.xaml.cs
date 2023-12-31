﻿using Game_interaction.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Interaction logic for Postgamescherm.xaml
    /// </summary>
    public partial class Postgamescherm : Window
    {
        private Dictionary<string, object> spelerData1;
        public Postgamescherm(Dictionary<string, object> spelerData, string winnaar)
        {
            InitializeComponent();
            spelerData1 = spelerData;
            SpelerWin.Content = winnaar + " heeft gewonnen!";
        }

        private void HerstartKnop(object sender, RoutedEventArgs e) //Button om de game te herstarten
        {
            Speelscherm speelscherm = new Speelscherm(spelerData1);
            speelscherm.Show();
            this.Close();
        }

        private void LeaderbordKnop(object sender, RoutedEventArgs e) //Button om naar de leaderbord te gaan
        {
            // Leaderbordscherm lb = new Leaderbordscherm();
            //lb.Show();
            //this.Close();
        }

        private void HoofdmenuKnop(object sender, RoutedEventArgs e) //Button om terug te gaan naar het hoofdmenu
        {
            BeginScherm bs = new BeginScherm();
            bs.Show();
            this.Close();
        }

        private void AfsluitenKnop(object sender, RoutedEventArgs e) //Button om alle windows af te sluiten
        {
            Application.Current.Shutdown();
        }
    }
}
