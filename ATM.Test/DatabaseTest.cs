using System.Threading.Tasks;
using ATM.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATM.Test
{
    [TestClass]
    public class DatabaseTest
    {

        [TestMethod]
        public async Task Get_DB_Information()
        {
            var db = new Database{Test = true};
            
            db.Users.Add(new User{Name = "Joe Doe"});
            await db.Save();

            Assert.AreEqual(1, db.Users.Count);
        }

    }
}
