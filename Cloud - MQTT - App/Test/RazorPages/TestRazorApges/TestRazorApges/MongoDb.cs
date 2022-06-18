using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Text.Json;

namespace TestRazorApges
{
    public class MongoDb
    {
        public static MongoClient Client = new MongoClient("mongodb://127.0.0.1:27017");

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
