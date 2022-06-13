using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Text.Json;

namespace TrainProjectWorkApp
{
    class MongoDB
    {
        public static MongoClient Client = new MongoClient("mongodb://127.0.0.1:27017");

        public static bool IsConnected()
        {
            try
            {
                return MongoDB.Client.GetDatabase("yugiohCardDb").RunCommandAsync((Command<JsonDocument>)"{ping:1}").Wait(2000);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
