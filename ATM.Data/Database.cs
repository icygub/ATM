using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;

namespace ATM.Data
{
    public class Database
    {
        private List<User> _db = new List<User>();
        private readonly StorageFolder _storageFolder = ApplicationData.Current.LocalFolder;
        private StorageFile _dbFile;
        public bool Test { get; set; }
        private static Database _instance;

        private Database()
        {
            LoadDb();
        }

        public static Database GetInstance()
        {
            return _instance ?? (_instance = new Database());
        }

        private async Task CreateFile()
        {
            _dbFile = await _storageFolder.CreateFileAsync("db.json", CreationCollisionOption.OpenIfExists);
        }

        private async void LoadDb()
        {
            await CreateFile();

            var db = await FileIO.ReadTextAsync(_dbFile);
            Debug.WriteLine("Reading File");
            Debug.WriteLine(db);
            Debug.WriteLine(JsonConvert.DeserializeObject<List<User>>(db));

            if (string.IsNullOrEmpty(db))
            {
                Debug.WriteLine("Vazio");
                _db = new List<User>();
            }
            else
            {
                Debug.WriteLine("Serializou");
                var deserializeObject = JsonConvert.DeserializeObject<List<User>>(db);
                Debug.WriteLine(deserializeObject);

                _db = deserializeObject;
            }
        }

        public  async void CleanFile()
        {
            await FileIO.WriteTextAsync(_dbFile, "");
        }

        private async Task SaveToFile()
        {
            var json = JsonConvert.SerializeObject(_db);
            await FileIO.WriteTextAsync(_dbFile, json);
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return _db.First(u => u.Username == username && u.Password == password);
        }

        public async void Save()
        {
            await SaveToFile();
        }

        public void AddUser(User user)
        {
            _db.Add(user);
        }

        public List<User> GetUsers()
        {
            return _db;
        }
    }
}
