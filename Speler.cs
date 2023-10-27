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
    public class DataMethods
    {
        // Spelers komen in een list met index 0: Naam, 1: E-mail, 2: Postcode, 3: Leeftijd, 4: Aantal wins
        public static List<List<object>> LeesSpelersUitCSV(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<List<object>>().ToList();
            }
        }

        public static void SchrijfSpelersNaarCSV(List<List<object>> spelers, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(spelers);
            }
        }

        public void SpelerGewonnen(List<object> speler)
        {
            speler[4] = (int)speler[4] + 1;
        }


    }




}
