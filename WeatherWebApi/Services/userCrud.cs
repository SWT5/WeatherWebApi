using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var client = new MongoClient(settings.connectionString);
            var database = client.GetDatabase(settings.DBName);

            _users = database.GetCollection<user>(settings.userCollection);
        }

        public List<user> Get() =>
           _users.Find(book => true).ToList();

        public user Get(string id) =>
            _users.Find<user>(u => u.UserName == id).FirstOrDefault();

        public user Create(user book)
        {
            _users.InsertOne(book);
            return book;
        }

        public void Update(string id, user User) =>
            _users.ReplaceOne(u => u.UserName == id, User);

        public void Remove(user User) =>
            _users.DeleteOne(wo => wo.UserName == User.UserName);

        public void Remove(string id) =>
            _users.DeleteOne(u => u.UserName == id);
    }
}
