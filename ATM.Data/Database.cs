using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;

namespace ATM.Data
{
    public class Database
    {
        private List<User> _db = new List<User>();
        private readonly StorageFolder _installationFolder = ApplicationData.Current.LocalFolder;
        private readonly string _dbFile = @"db.json";
        public List<User> Users => _db;
        public bool Test { get; set; }

        public Database()
        {
            LoadDb();
        }

        private async void LoadDb()
        {
            var file = await _installationFolder.CreateFileAsync(_dbFile, CreationCollisionOption.OpenIfExists);

            if( Test) await FileIO.WriteTextAsync(file, "");

            var db = await FileIO.ReadTextAsync(file);
            _db = string.IsNullOrEmpty(db) ? new List<User>() : JsonConvert.DeserializeObject<List<User>>(db);
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return Users.First(u => u.Username == username && u.Password == password);
        }

        public async Task Save()
        {
            var file = await _installationFolder.CreateFileAsync(_dbFile, CreationCollisionOption.OpenIfExists);
            var json = JsonConvert.SerializeObject(_db);
            await Windows.Storage.FileIO.WriteTextAsync(file, json);
        }
    }
}
