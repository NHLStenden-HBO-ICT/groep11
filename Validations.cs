using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Game_Interaction
{
    public class Validations
    {
        public static bool IsEmailValid(string email)
        {
            // Regex patroon om een e-mailadres te valideren
            string pattern = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(\.[a-zA-Z]{2,})+$";

            return Regex.IsMatch(email, pattern);
        }

        public static bool IsNederlandsePostcode(string postcode)
        {
            // Regex patroon voor Nederlandse postcodes
            string pattern = @"^\d{4}\s?[A-Za-z]{2}$";
           
            return Regex.IsMatch(postcode, pattern);
        }
    }
}
