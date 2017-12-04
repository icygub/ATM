using System;

namespace ATM.Business.Exceptions
{
    public class AuthenticationException:Exception
    {
        public AuthenticationException(string message): base(message) { }
    }
}
