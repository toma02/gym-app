using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public static class InputValidator
    {
        public static bool ValidateName(string name)
        {
            // First name should be between 2 and 50 characters
            if (name.Length < 2 || name.Length > 50)
            {
                return false;
            }

            // First name cannot contain special characters
            if (name.Any(ch => !char.IsLetter(ch)))
            {
                return false;
            }

            return true;
        }

        public static bool ValidateUsername(string username)
        {
            // First name should be between 2 and 50 characters
            if (username.Length < 3 || username.Length > 20)
            {
                return false;
            }

            // First name cannot contain special characters

            Regex rgx = new Regex("^[a-zA-Z0-9_]*$");
            return rgx.IsMatch(username);
        }

        public static bool ValidateEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";
            if (System.Text.RegularExpressions.Regex.IsMatch(email, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidatePassword(string password)
        {
            // First name should be between 2 and 50 characters
            if (password.Length < 6 || password.Length > 100)
            {
                return false;
            }
            return true;
        }

        public static bool isValidAge(string providedAge)
        {
            if (int.TryParse(providedAge, out int age))
            {
                if (age >= 0 && age <= 120)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        public static bool IsValidHeight(string heightString)
        {
            int intHeight;
            double doubleHeight = 0;
            if (int.TryParse(heightString, out intHeight) || double.TryParse(heightString, out doubleHeight))
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public static bool IsValidWeight(string weightString)
        {
            int intWeight; 
            double doubleWeight = 0;
            if (int.TryParse(weightString, out intWeight) || double.TryParse(weightString, out doubleWeight))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool HasNeededBMRData(User user)
        {
            if(user.weight==null||user.height==null||user.age==null)
                return false;
            return true;
        }
    }
}
