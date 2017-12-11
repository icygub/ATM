using System;
using System.Threading.Tasks;
using Windows.Media.Audio;
using ATM.Data;
using Windows.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATM.Test
{
    [TestClass]
    public class DatabaseTest
    {
        [TestMethod]
        public void Get_DB_Information()
        {
            var db = Database.GetInstance();

            db.AddUser(new User {Name = "Joe Doe"});

            db.Save();

            var users = db.GetUsers();

            Assert.AreEqual(1, users.Count);
        }
    }
}
