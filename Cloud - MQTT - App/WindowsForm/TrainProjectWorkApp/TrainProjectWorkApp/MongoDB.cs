using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Net.NetworkInformation;
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
                return MongoDB.Client.GetDatabase("trainProjectWork").RunCommandAsync((Command<JsonDocument>)"{ping:1}").Wait(3000);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return false;
            }
        }
    }
}
