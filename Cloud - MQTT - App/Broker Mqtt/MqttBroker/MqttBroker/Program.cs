using MQTTnet;
using MQTTnet.Protocol;
using MQTTnet.Server;
using System;
using System.Threading;

namespace MqttBroker
{
    internal class Program
    {
        #region Dichiarazione Variabili

        //Server Mqtt
        static IMqttServer mqttServer;

        //Variabile che indica il numero della Porta di connessione per Mqtt
        static int nPortMqtt = 707;

        //Stringa Ip
        static string ip = "localhost";

        #endregion Dichiarazione Variabili

        #region Main
        static void Main(string[] args)
        {
            Console.Title = "Broker MQTT";

            #region Opzioni del Server Broker MQTT

            // Create the options for our MQTT Broker
            MqttServerOptionsBuilder options = new MqttServerOptionsBuilder()
                                                 // set endpoint to localhost
                                                 .WithDefaultEndpoint()
                                                 // port used will be 707
                                                 .WithDefaultEndpointPort(nPortMqtt)
                                                 // handler for new connections
                                                 .WithConnectionValidator(OnNewConnection)
                                                 // handler for new messages
                                                 .WithApplicationMessageInterceptor(OnNewMessage);
            //.WithEncryptedEndpoint();

            // creates a new mqtt server     
            mqttServer = new MqttFactory().CreateMqttServer();

            // start the server with options  
            mqttServer.StartAsync(options.Build()).GetAwaiter().GetResult();

            #endregion Opzioni del Server Broker MQTT

            while (mqttServer.IsStarted == false) { }

            Console.WriteLine("Broker MQTT Started. Press a Key to stop.");

            //Premere invio per chiudere il Broker Mqtt
            Console.ReadKey();
        }
        #endregion Main

        #region Metodo eseguito per ogni nuova Connessione (Client) nel broker
        public static void OnNewConnection(MqttConnectionValidatorContext context)
        {
            //Salvataggio Username Completo
            string usernameCompl = context.Username;
            //Split Username tramite " "
            string[] nameArr = usernameCompl.Split(" ");
            //Prende la 1° parola dell'username completo
            string username = nameArr[0];

            Console.WriteLine($"[{DateTime.Now}] User {username} Login");

            //Return Connessione corretta
            context.ReasonCode = MqttConnectReasonCode.Success;
        }

        #endregion Metodo eseguito per ogni nuova Connessione (Client) nel broker

        #region Metodo eseguito per ogni nuovo messaggio nel broker
        public static void OnNewMessage(MqttApplicationMessageInterceptorContext context)
        {
            string topic = context.ApplicationMessage.Topic;
            Console.WriteLine($"[{DateTime.Now}] Message received in topic: {topic}");
        }
        #endregion Metodo eseguito per ogni nuovo messaggio nel broker
    }
}
