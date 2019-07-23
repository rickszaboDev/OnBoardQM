using System.Text.RegularExpressions;
using System;

namespace OnBoard.Utils
{
    public class Validation
    {
        public static bool ValidateEmail(string email, string regexKey)
        {
            //(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|"(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])
            var regex = new Regex(regexKey);
            return regex.IsMatch(email);
        }

        public static bool ValidatePasswordLength(string value)
        {
            if(value.Length >= 6)
            {
                return true;
            }
            return false;
        }

        public static bool ValidatePasswordConfirmation(string password, string confirmPassword)
        {
            if (password.Equals(confirmPassword))
            {
                return true;
            }
            return false;
        }

        public static bool ValidateAgeToSignIn(DateTime date)
        {
            int age = DateTime.Today.Year - date.Year;

            if (date > DateTime.Today.AddYears(-age))
            {
                age--;
            }

            return age >= 18;
        }
    }
}