using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class PasswordChecker
    {
        public static bool ValidateUser(string password,string login)
        {
            if (password == null || login == null)
            { 
                return false; 
            }
            else if (password == "1" && login == "1")
            {
                return true;
            }
            return false;
        }

        public static bool ValidateBack(bool click)
        {
            if (click == true)
            {
                return true;
            }
            return false;
        }

        public static bool ValidatePrice(string price)
        {
            if (int.TryParse(price, out var result))
            {
                return false;
            }
            return true;
        }
    }
}
