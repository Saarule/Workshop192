using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.Security
{
    public class Security
    {
        public static bool CheckPasswordSecurity(string password)
        {
            if (CheckLength(password) && CheckNumbers(password))
                return true;
            return false;
        }

        private static bool CheckLength(string password)
        {
            if (password.Length < 5)
                return false;
            return true;
        }

        private static bool CheckNumbers(string password)
        {
            foreach (char c in password)
                if (c >= '0' && c <= '9')
                    return true;
            return false;
        }
    }
}
