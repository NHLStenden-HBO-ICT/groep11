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
            string naamSpeler1 = NaamSpeler1.Text.Trim();
            string emailSpeler1 = E_mailSpeler1.Text.Trim();
            int? leeftijdSpeler1 = LeeftijdSpeler1.SelectedItem as int?;
            string? postcodeSpeler1 = PostcodeSpeler1.Text.Trim();

            // Haal de waarden uit de TextBoxes voor Speler 2
            string naamSpeler2 = NaamSpeler2.Text.Trim();
            string emailSpeler2 = E_mailSpeler2.Text.Trim();
            int? leeftijdSpeler2 = LeeftijdSpeler2.SelectedItem as int?;
            string? postcodeSpeler2 = PostcodeSpeler2.Text.Trim();

            // Controleer of gegevens speler 1 (correct) zijn ingevuld
            
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
                MessageBox.Show("Voer a.u.b. een geldig e-mailadres in voor Speler 1.");
                return;
            }

            // Check of postcode is ingevuld, als dit zo is checken of het een geldige postcode is
            if (!string.IsNullOrEmpty(postcodeSpeler1))
            {
                if (!Validations.IsNederlandsePostcode(postcodeSpeler1))
                {
                    MessageBox.Show("Voer a.u.b. een geldige Nederlandse postcode in voor speler 1.");
                    return;
                }
            }


            // Controleer of gegevens speler 2 (correct) zijn ingevuld
            
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
                MessageBox.Show("Voer a.u.b. een geldig e-mailadres in voor Speler 2.");
                return;
            }

            // Check of postcode is ingevuld, als dit zo is checken of het een geldige postcode is
            if (!string.IsNullOrEmpty(postcodeSpeler2))
            {
                if (!Validations.IsNederlandsePostcode(postcodeSpeler2))
                {
                    MessageBox.Show("Voer a.u.b. een geldige Nederlandse postcode in voor speler 1.");
                    return;
                }
            }

            // Als alles klopt, voeg de ingevulde waarden toe aan CSV file
            // Als de ingevulde waarden al in de csv file bestaan, niet toevoegen
            
            string path = @"..\..\..\Data\Player_info.csv";


            // Spelers uit CSV file lezen en variabelen voor spelers aanmaken
            // Spelers komen in een list met index 0: Naam, 1: E-mail, 2: Postcode, 3: Leeftijd, 4: Aantal wins
            List<List<object>> spelersUitCV = DataMethods.LeesSpelersUitCSV(path);
            List<object> speler1 = null;
            List<object> speler2 = null;

            // Loop door alle spelers die in het bestand staan
            // Als er een speler bestaat met de ingevulde naam en email combinatie wordt variabele 'speler1' gevuld met deze info
            foreach (List<object> speler in spelersUitCV)
            {
                if (speler[0].ToString() == naamSpeler1 && speler[1].ToString() == emailSpeler1)
                {
                    speler1 = speler;
                    break;
                }
            }

            // Als na de loop speler1 nog steeds null is (er is dus geen speler met deze naam en email combinatie) nieuwe speler aanmaken
            // en deze toevoegen aan CSV file
            if (speler1 == null) 
            {
                speler1 = new List<object> { naamSpeler1, emailSpeler1, postcodeSpeler1, leeftijdSpeler1, 0 };        
                spelersUitCV.Add(speler1);
            }

            // Loop door alle spelers die in het bestand staan (nu voor speler 2)
            // Als er een speler bestaat met de ingevulde naam en email combinatie wordt variabele 'speler1' gevuld met deze info
            foreach (List<object> speler in spelersUitCV)
            {
                if (speler[0].ToString() == naamSpeler2 && speler[1].ToString() == emailSpeler2)
                {
                    speler2 = speler;
                    break;
                }
            }

            // Als na de loop speler1 nog steeds null is (er is dus geen speler met deze naam en email combinatie) nieuwe speler aanmaken
            // en deze toevoegen aan CSV file
            if (speler2 == null)
            {
                speler2 = new List<object> { naamSpeler2, emailSpeler2, postcodeSpeler2, leeftijdSpeler2, 0 };
                spelersUitCV.Add(speler2);
            }
            spelersUitCV.Add(speler2);
            

            // Bijgewerkte lijst terugschrijven naar CSV
            DataMethods.SchrijfSpelersNaarCSV(spelersUitCV, path);



        }

        private void LeeftijdSpeler1_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 14; i <= 100; i++)
            {
                LeeftijdSpeler1.Items.Add(i);
            }
        }

        private void LeeftijdSpeler2_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 14; i <= 100; i++)
            {
                LeeftijdSpeler2.Items.Add(i);
            }
        }
    }
}
