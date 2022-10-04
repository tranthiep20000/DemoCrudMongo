using DemoMVC.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DemoMVC.Repositories
{
    public class DBContext : IDisposable
    {
        #region Feild

        private IMongoDatabase _database;
        private IMongoClient _client;

        #endregion Feild

        #region Contructor

        public DBContext(IOptions<Settings> settings)
        {
            _client = new MongoClient(settings.Value.ConnectionString);
            if (_client != null)
                _database = _client.GetDatabase(settings.Value.Database);
        }

        #endregion Contructor

        #region Method

        public IMongoCollection<Category> Categories
        {
            get
            {
                return _database.GetCollection<Category>("Categories");
            }
        }

        public void Dispose()
        {
            _client = null;
            _database = null;
        }

        #endregion Method
    }
}