using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            var tmpFile = await _storageFolder.TryGetItemAsync("db.json");

            _dbFile = await _storageFolder.CreateFileAsync("db.json", CreationCollisionOption.OpenIfExists);

            if (tmpFile == null)
            {
                var list = new List<User>
                {
                    new User()
                    {
                        Name = "Joe Doe",
                        Password = "secret",
                        CheckingAccount = new CheckingAccount()
                        {
                            Number = "123456789",
                            Balance = 5000
                        },
                        SavingsAccount = new SavingsAccount()
                        {
                            Number = "987654321",
                            Balance = 5000
                        },
                        CreditCard = new CreditCard()
                        {
                            Number = "4242424242424242",
                            Balance = 5000
                        }
                    },
                    new User()
                    {
                        Name = "Jane Doe",
                        Password = "secret",
                        CheckingAccount = new CheckingAccount()
                        {
                            Number = "012345678",
                            Balance = 6000
                        },
                        SavingsAccount = new SavingsAccount()
                        {
                            Number = "098765432",
                            Balance = 5500
                        },
                        CreditCard = new CreditCard()
                        {
                            Number = "3232323232323232",
                            Balance = 3000
                        }
                    }
                };
                var json = JsonConvert.SerializeObject(list);
                await FileIO.WriteTextAsync(_dbFile, json);

                _dbFile = await _storageFolder.CreateFileAsync("db.json", CreationCollisionOption.OpenIfExists);
            }
        }

        private async void LoadDb()
        {
            await CreateFile();

            var db = await FileIO.ReadTextAsync(_dbFile);

            if (string.IsNullOrEmpty(db))
            {
                _db = new List<User>();
            }
            else
            {
                var deserializeObject = JsonConvert.DeserializeObject<List<User>>(db);
                _db = deserializeObject;
            }
        }

        public async Task CleanFile()
        {
            await _dbFile.DeleteAsync();
            _instance = null;
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

        public async Task Save()
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
