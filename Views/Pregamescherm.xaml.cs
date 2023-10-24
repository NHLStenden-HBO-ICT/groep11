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
            string leeftijdSpeler1 = LeeftijdSpeler1.Text.Trim();
            string postcodeSpeler1 = PostcodeSpeler1.Text.Trim();

            // Haal de waarden uit de TextBoxes voor Speler 2
            string naamSpeler2 = NaamSpeler2.Text.Trim();
            string emailSpeler2 = E_mailSpeler2.Text.Trim();
            string leeftijdSpeler2 = LeeftijdSpeler2.Text.Trim();
            string postcodeSpeler2 = PostcodeSpeler2.Text.Trim();

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
            
            // Instance van Speler aanmaken om uit CSV bestand te kunnen lezen en in de list te zetten.
            List<Speler> spelersUitCV = Speler.LeesSpelersUitCSV(path);
            Speler speler1 = null;
            Speler speler2 = null;

            // Loop door alle spelers die in het bestand staan
            // Als er een speler bestaat met de ingevulde naam en email combinatie wordt variabele 'speler1' gevuld met deze info
            foreach (Speler speler in spelersUitCV)

            {
                if (speler.Naam == naamSpeler1 && speler.Email == emailSpeler1)
                {
                    speler1 = speler;
                    break;
                }
            }

            // Als na de loop speler1 nog steeds null is (er is dus geen speler met deze naam en email combinatie) nieuwe speler aanmaken
            // en deze toevoegen aan CSV file
            if (speler1 == null) 
            {
                speler1 = new Speler
                {
                    Naam = naamSpeler1,
                    Email = emailSpeler1,
                    Postcode = postcodeSpeler1,
                    Leeftijd = int.Parse(leeftijdSpeler1),
                    Wins = 0
                };
                spelersUitCV.Add(speler1);
            }

            // Loop door alle spelers die in het bestand staan (nu voor speler 2)
            // Als er een speler bestaat met de ingevulde naam en email combinatie wordt variabele 'speler1' gevuld met deze info
            foreach (Speler speler in spelersUitCV)

            {
                if (speler.Naam == naamSpeler1 && speler.Email == emailSpeler1)
                {
                    speler2 = speler;
                    break;
                }
            }

            // Als na de loop speler1 nog steeds null is (er is dus geen speler met deze naam en email combinatie) nieuwe speler aanmaken
            // en deze toevoegen aan CSV file
            if (speler2 == null)
            {
                speler2 = new Speler
                {
                    Naam = naamSpeler1,
                    Email = emailSpeler1,
                    Postcode = postcodeSpeler1,
                    Leeftijd = int.Parse(leeftijdSpeler1),
                    Wins = 0
                };
                spelersUitCV.Add(speler2);
            }

            // Bijgewerkte lijst terugschrijven naar CSV
            Speler.SchrijfSpelersNaarCSV(spelersUitCV, path);



        }
    }
}
