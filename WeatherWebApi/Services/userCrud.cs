using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using WeatherWebApi.Data;
using WeatherWebApi.Models;

namespace WeatherWebApi.Services
{
    public interface IuserCrud
    {
        List<user> Get();
        user GetUser(string id);
        user Create(user book);
        void Update(string id, user user);
        void Remove(user user);
        void Remove(string id);
    }

    public class userCrud: IuserCrud
    {
        private readonly IMongoCollection<user> _users;
        public userCrud(IWeatherStationDBSettings settings)
        {
            var client = new MongoClient("mongodb://127.0.0.1:27017/");
            var database = client.GetDatabase("WeatherforecastDb");

            _users = database.GetCollection<user>(settings.userCollection);
        }

        public List<user> Get() =>
           _users.Find(user => true).ToList();

        public user GetUser(string id) =>
            _users.Find<user>(u => u.UserName == id).FirstOrDefault();

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
