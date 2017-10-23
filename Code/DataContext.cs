using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using SfaisWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SfaisWeb.Code
{
    public class DataContext
    {
        public static string ConString { get { return ConfigurationManager.ConnectionStrings["con"].ConnectionString; } }
        public static MongoUrl Url { get { return new MongoUrl(ConString); } }
        public static MongoClient Client { get { return new MongoClient(Url); } }
        public static MongoServer Server { get { return Client.GetServer(); } }
        public static MongoDatabase Database { get { return Server.GetDatabase(Url.DatabaseName); } }

        static DataContext()
        {
            if (!Database.CollectionExists("Sfais_Users"))
            {
              var result=  Database.CreateCollection("Sfais_Users");
                var m = result;
            }
        }
        public DataContext()
        {

        }
        public static IEnumerable<User> GetUsers()
        {
         
            var collection = Database.GetCollection<User>("Sfais_Users");
            var Users = collection.FindAll();

            return  Users.ToList();
          
        }

        public MongoCursor<User> GetUserByEmial(string email)
        {
            IMongoQuery query = Query.EQ("Emial", email);
           var user= Database.GetCollection<User>("Sfais_Users").Find(query);

            return user;
        }
        public static void InsertUser(User user)
        {
            try
            {
               var collection= Database.GetCollection<User>("Sfais_Users").Insert<User>(user);
                var col = collection;
            }
            catch(Exception ex) {
                throw ex;
            }
        }

        public static void UpdateUser(User user)
        {
            var collection = Database.GetCollection<User>("Sfais_Users");
        
            IMongoQuery query = Query.EQ("Id", user.Id);
            IMongoUpdate update = MongoDB.Driver.Builders.Update
                .Set("FirstName", user.FirstName)
                .Set("LastName", user.LastName)
                .Set("Email", user.Email)
                .Set("DOB", user.DOB)
                .Set("PhoneNumber", user.PhoneNumber)
                .Set("Level", user.Level)
                .Set("Password", user.Password);

          var result=  collection.Update(query,update);
            var d = result;
        }

        public static void DeleteUser(ObjectId Id)
        {
            var collection = Database.GetCollection<User>("Sfais_Users");
            IMongoQuery query = Query.EQ("Id", Id);
            collection.Remove(query);
        }
    }
}