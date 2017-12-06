using System;

namespace ATM.Data.Exceptions
{
    public class AuthenticationException:Exception
    {
        public AuthenticationException(string message): base(message) { }
    }
}
