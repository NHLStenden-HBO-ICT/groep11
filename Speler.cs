using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Interaction
{
    public class Speler
    {
        public string Naam { get; set; }
        public string Email { get; set; }
        public string? Postcode { get; set; } //Niet verplicht dus nullable
        public int? Leeftijd { get; set; } //Niet verplicht dus nullable
        public int Wins { get; set; }
    }
}
