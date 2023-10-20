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
            // Haal de waarden uit de TextBoxes voor Speler 1
            string naamSpeler1 = NaamSpeler1.Text;
            string emailSpeler1 = E_mailSpeler1.Text;
            string leeftijdSpeler1 = LeeftijdSpeler1.Text;
            string postcodeSpeler1 = PostcodeSpeler1.Text;

            // Haal de waarden uit de TextBoxes voor Speler 2
            string naamSpeler2 = NaamSpeler2.Text;
            string emailSpeler2 = E_mailSpeler2.Text;
            string leeftijdSpeler2 = LeeftijdSpeler2.Text;
            string postcodeSpeler2 = PostcodeSpeler2.Text;

            // Controleer de waarden voor Speler 1 (dit is slechts een voorbeeld)
            if (string.IsNullOrEmpty(naamSpeler1))
            {
                MessageBox.Show("Voer a.u.b. een naam in voor Speler 1.");
                return;
            }

            if (string.IsNullOrEmpty(emailSpeler1))
            {
                MessageBox.Show("Voer a.u.b. een e-mailadres in voor Speler 1.");
                return;
            }

            // Voeg hier eventuele verdere validatie toe voor de andere TextBoxes van Speler 1...

            // Controleer de waarden voor Speler 2 (dit is slechts een voorbeeld)
            if (string.IsNullOrEmpty(naamSpeler2))
            {
                MessageBox.Show("Voer a.u.b. een naam in voor Speler 2.");
                return;
            }

            if (string.IsNullOrEmpty(emailSpeler2))
            {
                MessageBox.Show("Voer a.u.b. een e-mailadres in voor Speler 2.");
                return;
            }

            // Voeg hier eventuele verdere validatie toe voor de andere TextBoxes van Speler 2...
        }
    }
}
