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
            // Uitgebreidere regex patroon om een e-mailadres te valideren
            string pattern = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(\.[a-zA-Z]{2,})+$";

            return Regex.IsMatch(email, pattern);
        }
    }
}
