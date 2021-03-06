﻿using ATM.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATM.UnitTest
{
    [TestClass]
    public class DatabaseTest
    {

        [TestMethod]
        public void Get_DB_Information()
        {
            var db = new Database{Test = true};
            
            db.Users.Add(new User{Name = "Joe Doe"});
            db.Save();

            Assert.AreEqual(1, db.Users.Count);
        }

    }
}
