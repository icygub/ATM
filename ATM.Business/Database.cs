using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ATM.Business
{
    public class Database
    {
        private List<User> _db = new List<User>();
        private readonly string _dbFile = $"{Environment.CurrentDirectory}\\db.json";
        public List<User> Users => _db;

        public Database()
        {
            LoadDb();
        }


        private void LoadDb()
        {
            if (!File.Exists(_dbFile)) return;


            var db = File.ReadAllText(_dbFile);
            _db = string.IsNullOrEmpty(db) ? new List<User>() : JsonConvert.DeserializeObject<List<User>>(db);
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return Users.First(u => u.Username == username && u.Password == password);
        }

        public void Save()
        {
            var json = JsonConvert.SerializeObject(_db);
            File.WriteAllText(_dbFile, json);
        }
    }
}
