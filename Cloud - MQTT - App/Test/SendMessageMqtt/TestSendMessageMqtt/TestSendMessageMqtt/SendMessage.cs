using MQTTnet;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Extensions.ManagedClient;
using Newtonsoft.Json;
using System;
using System.Threading;

namespace TestSendMessageMqtt
{
    internal class SendMessage
    {
        #region Dichiarazione Variabili
        //Topic in cui Pubblicare i messaggi Mqtt
        static string topicToPublish = "trainProjectWork/1/liveData";
        static ManualResetEvent MRE = new ManualResetEvent(false);
        //Tempo ogni quanto viene inviato un messaggio
        static int timeToSendMessage = 1000;

        //Client Mqtt
        static IManagedMqttClient _mqttClient;
        //Ogni quanti secondi prova a riconnettersi
        static int timeMqttReconnect = 5;
        //Numero Porta di Mqtt
        static int nPortMqtt = 707;
        //Ip del Server Mqtt
        static string serverMqtt = "localhost";
        #endregion Dichiarazione Variabili

        #region Main
        static void Main(string[] args)
        {
            //Scelta randomica del Client id
            string idNameClientMqtt = Guid.NewGuid().ToString("N");
            Console.Title = "Test Pub Mqtt";

            #region Opzioni Client MQTT
            // Creates a new client
            MqttClientOptionsBuilder builder = new MqttClientOptionsBuilder()
                                                    .WithClientId("Console Test Pub Mqtt " + idNameClientMqtt.ToString())
                                                    .WithTcpServer(serverMqtt, nPortMqtt)
                                                    //.WithTls()
                                                    .WithCredentials("Console Test Pub Mqtt " + idNameClientMqtt.ToString(), "ConsolePassword000");

            // Create client options objects
            ManagedMqttClientOptions options = new ManagedMqttClientOptionsBuilder()
                                    .WithAutoReconnectDelay(TimeSpan.FromSeconds(timeMqttReconnect))
                                    .WithClientOptions(builder.Build())
                                    .Build();

            // Creates the client object
            _mqttClient = new MqttFactory().CreateManagedMqttClient();

            // Set up handlers
            _mqttClient.ConnectedHandler = new MqttClientConnectedHandlerDelegate(OnConnected);
            _mqttClient.DisconnectedHandler = new MqttClientDisconnectedHandlerDelegate(OnDisconnected);
            _mqttClient.ConnectingFailedHandler = new ConnectingFailedHandlerDelegate(OnConnectingFailed);

            // Starts a connection with the Broker
            _mqttClient.StartAsync(options).GetAwaiter().GetResult();
            #endregion Opzioni Client MQTT

            while (_mqttClient.IsConnected == false) { }

            /*#region Quando viene ricevuto un messaggio MQTT (Usato per Test)
            _mqttClient.UseApplicationMessageReceivedHandler(e =>
            {
                byte[] risp = e.ApplicationMessage.Payload;
            });
            #endregion Quando viene ricevuto un messaggio MQTT (Usato per Test)*/

            #region Per mandare messaggi di "aggiornamento" ( -> Messaggi di Lettura su MQTT da eseguire su Modbus )
            // Send a new message to the broker every x second
            while (!MRE.WaitOne(timeToSendMessage))
            {
                //Se il Client è connesso al Server Mqtt
                if (_mqttClient.IsConnected)
                {
                    //Crea la stringa Json
                    //string json = JsonConvert.SerializeObject("{\"values\":[{\"nick\":\"Admin\",\"role\":\"Admin\",\"password\":\"test123\"},{\"nick\":\"Utente1\",\"role\":\"Capo\",\"password\":\"test123\"},{\"nick\":\"Utente2\",\"role\":\"Null\",\"password\":\"test123\"}]}");
                    //string json = "{\"values\":[{\"nick\":\"Admin\",\"role\":\"Admin\",\"password\":\"test123\"},{\"nick\":\"Utente1\",\"role\":\"Capo\",\"password\":\"test123\"},{\"nick\":\"Utente2\",\"role\":\"Null\",\"password\":\"test123\"}]}";
                    //string json = "{\"nrTrain\":1,\"nrWagon\":3,\"Temp\":23.3,\"Hum\":61.5,\"Smoke\":false,\"Toilette\":true,\"Port\":[true,true,true,false]}";
                    string json = "{\"nrWagon\":3,\"Temp\":23.3,\"Hum\":61.5,\"Smoke\":false,\"Toilette\":true,\"Port\":[true,true,true,false]}";


                    //Creazione del messaggio Mqtt
                    var message = new MqttApplicationMessageBuilder()
                   .WithTopic(topicToPublish)
                   .WithPayload(json)
                   .WithAtMostOnceQoS()
                   .WithRetainFlag(true)
                   .Build();

                    //Publish del messaggio nel Broker Mqtt
                    _mqttClient.PublishAsync(message);

                    Console.WriteLine($"\n[{DateTime.Now}] Message send in Topic: {topicToPublish}");

                }
            }
            #endregion Per mandare messaggi di "aggiornamento" ( -> Messaggi di Lettura su MQTT da eseguire su Modbus )

        }
        #endregion Main

        #region Metodi usati per la connessione MQTT
        public static void OnConnected(MqttClientConnectedEventArgs obj)
        {
            Console.WriteLine("Successfully connected.");
        }

        public static void OnConnectingFailed(ManagedProcessFailedEventArgs obj)
        {
            Console.WriteLine("Couldn't connect to broker.");
        }

        public static void OnDisconnected(MqttClientDisconnectedEventArgs obj)
        {
            Console.WriteLine("Successfully disconnected.");
        }
        #endregion Metodi usati per la connessione MQTT
    }
}
