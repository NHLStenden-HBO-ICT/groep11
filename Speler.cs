using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using CsvHelper;
using System.IO;
using System.Globalization;


namespace Game_Interaction
{
    public class Speler
    {
        public string Naam { get; set; }
        public string Email { get; set; }
        public string? Postcode { get; set; } //Niet verplicht dus nullable
        public int? Leeftijd { get; set; } //Niet verplicht dus nullable
        public int Wins { get; set; }
    

        public static List<Speler> LeesSpelersUitCSV(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<Speler>().ToList();
            }
        }

        public static void SchrijfSpelersNaarCSV(List<Speler> spelers, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(spelers);
            }
        }

        public void SpelerGewonnen()
        {
            this.Wins++;
        }


    }




}
