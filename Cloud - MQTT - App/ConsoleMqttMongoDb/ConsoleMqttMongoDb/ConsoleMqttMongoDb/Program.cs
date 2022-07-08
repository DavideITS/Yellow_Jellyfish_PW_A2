using MQTTnet;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Extensions.ManagedClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Telegram.Bot;

namespace ConsoleMqttMongoDb
{
    internal class Program
    {
        #region Dichiarazione Variabili

        #region MQTT

        //Client Mqtt
        static IManagedMqttClient _mqttClient;
        //Topic nel quale ricevere i messaggi
        static string topicToReceive = "trainProjectWork/+/liveData/#";
        //Tempo in secondi tra ogni tentativo di riconnessione
        static int timeMqttReconnect = 5;
        //Numero Porta di Mqtt
        //static int nPortMqtt = 707;
        static int nPortMqtt = 1883;
        //Ip del Server Mqtt
        //static string serverMqtt = "localhost";
        static string serverMqtt = "broker.hivemq.com";

        #endregion MQTT

        #endregion Dichiarazione Variabili

        #region Main

        static void Main(string[] args)
        {
            //Id randomico del Client
            string idNameClientMqtt = Guid.NewGuid().ToString("N");
            Console.Title = "Console to Send Live Data from Mqtt to MongoDb";

            #region Opzioni Client MQTT
            // Creates a new client
            MqttClientOptionsBuilder builder = new MqttClientOptionsBuilder()
                                                    .WithClientId("Console Mqtt-MongoDb " + idNameClientMqtt.ToString())
                                                    .WithTcpServer(serverMqtt, nPortMqtt)
                                                    .WithCredentials("Console Mqtt-MongoDb " + idNameClientMqtt.ToString(), "ConsolePassword000");

            // Create client options objects
            ManagedMqttClientOptions options = new ManagedMqttClientOptionsBuilder()
                                    .WithAutoReconnectDelay(TimeSpan.FromSeconds(timeMqttReconnect))
                                    .WithClientOptions(builder.Build())
                                    .Build();

            // Creates the client object
            //IManagedMqttClient _mqttClient = new MqttFactory().CreateManagedMqttClient();
            _mqttClient = new MqttFactory().CreateManagedMqttClient();

            // Set up handlers
            _mqttClient.ConnectedHandler = new MqttClientConnectedHandlerDelegate(OnConnected);
            _mqttClient.DisconnectedHandler = new MqttClientDisconnectedHandlerDelegate(OnDisconnected);
            _mqttClient.ConnectingFailedHandler = new ConnectingFailedHandlerDelegate(OnConnectingFailed);

            // Starts a connection with the Broker
            _mqttClient.StartAsync(options).GetAwaiter().GetResult();
            #endregion Opzioni Client MQTT

            while (_mqttClient.IsConnected == false) { }
            //Console.WriteLine(_mqttClient.IsConnected);

            #region Quando vengono ricevuti messaggi da MQTT

            _mqttClient.UseApplicationMessageReceivedHandler(e =>
            {
                //Se il contenuto del messaggio non è null
                if(e.ApplicationMessage.Payload != null)
                {
                    //Estrazione Messaggio ricevuto
                    var data = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);

                    try
                    {

                        #region Estrazione Json e dati necessari

                        //Convert da Stringa Json a Json
                        JObject json = JObject.Parse(data);
                        //Estrazione topic
                        string topic = e.ApplicationMessage.Topic;
                        //Split del topic tramite "/"
                        string[] topicSplit = topic.Split("/");

                        #endregion Estrazione Json e dati necessari

                        Console.WriteLine($"\n[{DateTime.Now}] Message received in Topic: {topic}\nData: {data}");

                        //Oggetto che verrà usato per creare il json da inserire su mongodb
                        Dictionary<string, object> objToInsert = new Dictionary<string, object>();

                        #region Aggiunta dati in objToInsert

                        //Aggiunta data e nr treno (ricavato dal topic di ricezione del messaggio)
                        objToInsert.Add("date", DateTime.Now);
                        objToInsert.Add("nrTrain", int.Parse(topicSplit[1].ToString()));

                        foreach (var jsonElement in json)
                        {
                            if (!jsonElement.Key.ToString().ToLower().Equals("port"))
                            {
                                //Tentativi di conversione in bool, float e successivamente int
                                //Se la conversione non è possibile in alcun caso, il dato viene considerato come stringa
                                bool resultBoolConvert = false;
                                if (bool.TryParse(jsonElement.Value.ToString(), out resultBoolConvert))
                                {
                                    objToInsert.Add(jsonElement.Key, resultBoolConvert);

                                    //Controllo sensore del fumo
                                    if (jsonElement.Key.ToString().ToLower().Equals("smoke") && resultBoolConvert == true)
                                    {
                                        //Se il sensore del fumo è attivo viene mandata una notifica su telegram
                                        string messageTelegramBot = $"Gas was detected in wagon {json["nrWagon"]} of train nr° {int.Parse(topicSplit[1].ToString())}";
                                        sendTelegram(messageTelegramBot);
                                    }
                                }
                                else
                                {
                                    double resultFloatConvert = 0;
                                    if (double.TryParse(jsonElement.Value.ToString(), out resultFloatConvert))
                                    {
                                        objToInsert.Add(jsonElement.Key, resultFloatConvert);

                                        //Controllo valore Temperatura
                                        if (jsonElement.Key.ToString().ToLower().Equals("temp") && resultFloatConvert > 30)
                                        {
                                            //Se la temperatura supera i 30°C viene mandata una notifica su telegram
                                            string messageTelegramBot = $"Excessive temperature of {resultFloatConvert} °C  was detected in wagon {json["nrWagon"]} of train nr° {int.Parse(topicSplit[1].ToString())}";
                                            sendTelegram(messageTelegramBot);
                                        }else if (jsonElement.Key.ToString().ToLower().Equals("temp") && resultFloatConvert < 15)
                                        {
                                            //Se la temperatura supera i 30°C viene mandata una notifica su telegram
                                            string messageTelegramBot = $"Too low temperature of {resultFloatConvert} °C  was detected in wagon {json["nrWagon"]} of train nr° {int.Parse(topicSplit[1].ToString())}";
                                            sendTelegram(messageTelegramBot);
                                        }

                                        //Controllo valore Umidità
                                        if (jsonElement.Key.ToString().ToLower().Equals("hum") && resultFloatConvert > 80)
                                        {
                                            //Se l'umidità supera l' 80% viene mandata una notifica su telegram
                                            string messageTelegramBot = $"Excessive humidity of {resultFloatConvert}% was detected in wagon {json["nrWagon"]} of train nr° {int.Parse(topicSplit[1].ToString())}";
                                            sendTelegram(messageTelegramBot);
                                        }else if (jsonElement.Key.ToString().ToLower().Equals("hum") && resultFloatConvert < 40)
                                        {
                                            //Se l'umidità supera l' 80% viene mandata una notifica su telegram
                                            string messageTelegramBot = $"Too low humidity of {resultFloatConvert}% was detected in wagon {json["nrWagon"]} of train nr° {int.Parse(topicSplit[1].ToString())}";
                                            sendTelegram(messageTelegramBot);
                                        }
                                    }
                                    else
                                    {
                                        int resultIntConvert = 0;
                                        if (int.TryParse(jsonElement.Value.ToString(), out resultIntConvert))
                                        {
                                            objToInsert.Add(jsonElement.Key, resultIntConvert);
                                        }
                                        else
                                        {
                                            objToInsert.Add(jsonElement.Key, jsonElement.Value.ToString());
                                        }
                                    }
                                }
                            }
                            else
                            {
                                var portValues = jsonElement.Value;
                                int count = 1;
                                foreach (var port in portValues)
                                {
                                    objToInsert.Add(jsonElement.Key + count.ToString(), bool.Parse(port.ToString()));
                                    count++;
                                }
                            }

                        }

                        #endregion Aggiunta dati in objToInsert

                        try
                        {

                            //var a = Directory.GetFiles(Path.GetFullPath("..//..//..//"));

                            //Dict finito, ora lo devo inserire nel db
                            MongoDb.Client.GetDatabase("trainProjectWork").GetCollection<Dictionary<string, object>>("TrainLiveData").InsertOne(objToInsert);

                        }
                        catch (Exception err)
                        {
                            var errorMessage = err.Message;
                        }
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine($"{err.StackTrace}: {err.Message}");
                    }
                    
                }
            });
            #endregion Quando vengono ricevuti messaggi da MQTT

            Console.ReadKey();
        }

        #endregion Main

        #region Metodi usati per la connessione con MQTT

        //Connessione Avvenuta correttamente su MQTT
        public static void OnConnected(MqttClientConnectedEventArgs obj)
        {
            //Appena si connette fa il sub al topic da cui deve ricevre i messaggi
            _mqttClient.SubscribeAsync(topicToReceive);

            Console.WriteLine("Successfully connected.");
        }

        //Connessione Non Avvenuta correttamente su MQTT
        public static void OnConnectingFailed(ManagedProcessFailedEventArgs obj)
        {
            Console.WriteLine("Couldn't connect to broker.");
        }

        //Disconnessione da MQTT
        public static void OnDisconnected(MqttClientDisconnectedEventArgs obj)
        {
            Console.WriteLine("Successfully disconnected.");
        }

        #endregion Metodi usati per la connessione con MQTT

        #region Telegram

        //Metodo usare per mandare un messaggio con il bot su telegram
        private static void sendTelegram(string msgToSend)
        {
            //Bot basato su Token di accesso
            var telegramBot = new TelegramBotClient("5513414500:AAEsclqcHI1dNien8pfrNqY5-PZFzmZ0NI8");
            //Send del messaggio sul gruppo telegram
            //Basato sull'id del gruppo
            telegramBot.SendTextMessageAsync("-592882855", msgToSend);
        }

        #endregion Telegram
    }
}
