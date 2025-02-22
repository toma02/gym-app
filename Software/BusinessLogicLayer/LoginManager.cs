using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public static class LoginManager
    {
        private static int loginAttempts = 0;
        private static int MAX_LOGIN_ATTEMPTS = 3;

        public static void IncreaseLoginAttemptCounter() { loginAttempts++; }

        public static bool MaxLoginAttemptsReached()
        {
            return loginAttempts > MAX_LOGIN_ATTEMPTS;
        }

        public static void ClearLoginAttempts()
        {
            loginAttempts = 0;
        }
    }
}
