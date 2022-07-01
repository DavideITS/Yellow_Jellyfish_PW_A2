using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MQTTnet;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Extensions.ManagedClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace TrainProjectWorkWebApp.Pages
{
    public class ChangePortModel : PageModel
    {

        //Nome della porta da modificare
        [BindProperty]
        public string portName { get; set; }

        //Nuovo valore dello stato della porta da inviare
        [BindProperty]
        public bool portStatus { get; set; }

        //Errori da mostrare sulla pagina
        [BindProperty]
        public string ErrorToSee { get; set; }

        //nr Train
        [BindProperty]
        public int nrTrain { get; set; }

        //nr Wagon
        int nrWagon;

        #region Dichiarazione Variabili Mqtt
        //Tempo ogni quanto viene inviato un messaggio
        static int timeToSendMessage = 1000;
        //Client Mqtt
        static IManagedMqttClient _mqttClient;
        //Ogni quanti secondi prova a riconnettersi
        static int timeMqttReconnect = 5;
        //Numero Porta di Mqtt
        //static int nPortMqtt = 707;
        static int nPortMqtt = 1883;
        //Ip del Server Mqtt
        //static string serverMqtt = "localhost";
        static string serverMqtt = "broker.hivemq.com";
        #endregion Dichiarazione Variabili Mqtt

        public void OnGet()
        {
            //Get dei valori di input
            string inputDataUrlCompl = this.HttpContext.Request.QueryString.Value.Replace("?handler=", "");

            //Array composto dagli elementi di input
            string[] inputDataUrl = inputDataUrlCompl.Split("-");

            //Nome della porta selezionata
            portName = inputDataUrl[2];

            //Nr Treno
            nrTrain = int.Parse(inputDataUrl[0]);
        }

        public IActionResult OnPost()
        {
            //Scelta randomica del Client id
            string idNameClientMqtt = Guid.NewGuid().ToString("N");

            #region Opzioni Client MQTT
            // Creates a new client
            MqttClientOptionsBuilder builder = new MqttClientOptionsBuilder()
                                                    .WithClientId("TrainPW Web App " + idNameClientMqtt.ToString())
                                                    .WithTcpServer(serverMqtt, nPortMqtt)
                                                    //.WithTls()
                                                    .WithCredentials("TrainPW Web App " + idNameClientMqtt.ToString(), "ConsolePassword000");

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

            #region Per mandare messaggi Mqtt

            if (_mqttClient.IsConnected)
            {
                #region Creazione Json String
                //Get dei valori di input
                string inputDataUrlCompl = this.HttpContext.Request.QueryString.Value.Replace("?handler=", "");

                //Array composto dagli elementi di input
                string[] inputDataUrl = inputDataUrlCompl.Split("-");

                //Nr del treno
                nrTrain = int.Parse(inputDataUrl[0]);

                //Nr del vagone
                nrWagon = int.Parse(inputDataUrl[1]);

                //Nome della porta selezionata
                portName = inputDataUrl[2];

                //Creazione dict da trasformare in json
                Dictionary<string, object> objToSend = new Dictionary<string, object>();

                //Agg. elementi
                objToSend.Add("nrTrain", nrTrain);
                objToSend.Add("nrWagon", nrWagon);
                objToSend.Add("change", portName);
                objToSend.Add("newValue", portStatus);

                //Creazione JObject da Dict
                var jobjToConvert = JObject.FromObject(objToSend);
                //Conversione da JObject a Json String
                string jsonStringToSend = jobjToConvert.ToString().Replace("\r\n", "");
                #endregion Creazione Json String

                string topicToPublish = $"trainProjectWork/{nrTrain}/command";

                //Creazione del messaggio Mqtt
                var message = new MqttApplicationMessageBuilder()
                   .WithTopic(topicToPublish)
                   .WithPayload(jsonStringToSend)
                   .WithAtMostOnceQoS()
                   .WithRetainFlag(true)
                   .Build();

                //Publish del messaggio nel Broker Mqtt
                _mqttClient.PublishAsync(message).GetAwaiter().GetResult();

                _mqttClient.StopAsync();

                return RedirectToPage("ConfermDataSend");
            }
            else
            {
                ErrorToSee = "No Connection with Mqtt Broker";
                return Page();
            }
            #endregion Per mandare messaggi Mqtt
            
        }

        #region Metodi usati per la connessione con MQTT

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

        #endregion Metodi usati per la connessione con MQTT
    }
}
