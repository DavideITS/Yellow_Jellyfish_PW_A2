using MQTTnet;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Extensions.ManagedClient;
using Newtonsoft.Json.Linq;
using System;
using System.Text;

namespace TestSubMessageMqtt
{
    internal class SubMessage
    {
        #region Dichiarazione Variabili

        //Client Mqtt
        static IManagedMqttClient _mqttClient;
        //Topic nel quale ricevere i messaggi
        static string topicToReceive = "trainProjectWork/#";
        //Tempo in secondi tra ogni tentativo di riconnessione
        static int timeMqttReconnect = 5;
        //Nr di porta di Mqtt
        static int nPortMqtt = 707;
        //Stringa Ip del broker Mqtt
        static string serverMqtt = "localhost";

        #endregion Dichiarazione Variabili

        static void Main(string[] args)
        {
            //Id randomico del Client
            string idNameClientMqtt = Guid.NewGuid().ToString("N");
            Console.Title = "Test Sub Mqtt";

            #region Opzioni Client MQTT
            // Creates a new client
            MqttClientOptionsBuilder builder = new MqttClientOptionsBuilder()
                                                    .WithClientId("Console Test Sub Mqtt " + idNameClientMqtt.ToString())
                                                    .WithTcpServer(serverMqtt, nPortMqtt)
                                                    .WithCredentials("Console Test Sub Mqtt " + idNameClientMqtt.ToString(), "ConsolePassword000");

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
                //Estrazione Messaggio ricevuto
                var data = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                //Convert da Stringa Json a Json
                JObject json = JObject.Parse(data);
                //Estrazione topic
                string topic = e.ApplicationMessage.Topic;
                //Split del topic tramite "/"
                string[] topicSplit = topic.Split("/");

                Console.WriteLine($"\n[{DateTime.Now}] Message received in Topic: {topic}\nData: {data}");
            });
            #endregion Quando vengono ricevuti messaggi da MQTT

            Console.ReadKey();
        }

        #region Metodi usati per la connessione con MQTT

        public static void OnConnected(MqttClientConnectedEventArgs obj)
        {
            _mqttClient.SubscribeAsync(topicToReceive);

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

        #endregion Metodi usati per la connessione con MQTT
    }
}
