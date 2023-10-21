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

            // Controleer of naam en e-mail speler 1 (correct) is ingevuld
            
            // Naam speler 1
            if (string.IsNullOrEmpty(naamSpeler1))
            {
                MessageBox.Show("Voer a.u.b. een naam in voor Speler 1.");
                return;
            }
            
            // email speler 1
            if (string.IsNullOrEmpty(emailSpeler1))
            {
                MessageBox.Show("Voer a.u.b. een e-mailadres in voor Speler 1.");
                return;

            }
            else if (!Validations.IsEmailValid(emailSpeler1))
            {
                MessageBox.Show("Voer a.u.b. een geldig e-mail in voor Speler 1.");
                return;
            }


            // Controleer of naam en e-mail speler 2 (correct) is ingevuld
            
            // Naam speler 2
            if (string.IsNullOrEmpty(naamSpeler2))
            {
                MessageBox.Show("Voer a.u.b. een naam in voor Speler 2.");
                return;
            }

            // E-mail speler 2
            if (string.IsNullOrEmpty(emailSpeler2))
            {
                MessageBox.Show("Voer a.u.b. een e-mailadres in voor Speler 2.");
                return;
            }
            else if (!Validations.IsEmailValid(emailSpeler2))
            {
                MessageBox.Show("Voer a.u.b. een geldig e-mail in voor Speler 2.");
                return;
            }



        }
    }
}
