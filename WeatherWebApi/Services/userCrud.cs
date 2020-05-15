using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using WeatherWebApi.Models;

namespace WeatherWebApi.Services
{
    public interface IUserCrud
    {
        List<user> Get();
        Task<user> GetUser(string id);
        user Create(user book);
        void Update(string id, user user);
        void Remove(user user);
        void Remove(string id);
    }

    public class UserCrud: IUserCrud
    {
        private readonly IMongoCollection<user> _users;
        public UserCrud(IWeatherDatabaseSettings settings)
        {
            var client = new MongoClient("mongodb://127.0.0.1:27017/");
            var database = client.GetDatabase("WeatherforecastDb");

            _users = database.GetCollection<user>("user");
        }

        public List<user> Get() =>
           _users.Find(user => true).ToList();

        public async Task<user> GetUser(string id)
        { 
            var user = await _users.Find<user>(u => u.UserName == id).ToListAsync();
           return user.FirstOrDefault();
        }
            

        public user Create(user User)
        {
            _users.InsertOne(User);
            return User;
        }

        public void Update(string id, user User) =>
            _users.ReplaceOne(u => u.UserName == id, User);

        public void Remove(user User) =>
            _users.DeleteOne(wo => wo.UserName == User.UserName);

        public void Remove(string id) =>
            _users.DeleteOne(u => u.UserName == id);
    }
}
