using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleMqttMongoDb
{
    public class MongoDb
    {
        //public static MongoClient Client = new MongoClient("mongodb://127.0.0.1:27017");
        public static MongoClient Client = new MongoClient("mongodb+srv://simonezoppelletto:test000@simulazioneesame.2eprc.mongodb.net/test?readPreference=primary");

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
