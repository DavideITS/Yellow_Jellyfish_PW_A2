using MongoDB.Driver;
using System;
using System.Text.Json;

namespace TrainProjectWorkWebApp
{
    public class MongoDb
    {
        //public static MongoClient Client = new MongoClient("mongodb://127.0.0.1:27017");      //test in locale
        public static MongoClient Client = new MongoClient(System.IO.File.ReadAllText("..//..//MongoDbConnectionString.txt"));

        public static bool IsConnected()
        {
            try
            {
                return MongoDb.Client.GetDatabase("trainProjectWork").RunCommandAsync((Command<JsonDocument>)"{ping:1}").Wait(2000);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
