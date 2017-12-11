﻿using ATM.Data.Exceptions;
using System.Linq;

namespace ATM.Data
{
    public static class Authentication
    {
        public static User Login(string accountNumber, string password)
        {
            //var db = Database.GetInstance();
            //var users = db.GetUsers();

            //var user = users.First(u => u.CheckingAccount.Number.Equals(accountNumber) && u.Password.Equals(password));

            //if (user == null)
            //{
            //    throw new AuthenticationException("Account number or password invalid");
            //}

            if (accountNumber != "123456" || accountNumber == null || password != "secret" || password == null)
            {
                throw new AuthenticationException("Account number or password invalid");
            }

            var user = new User();

            user.Logged = true;
            return user;
        }
    }
}
