using MongoDB.Driver;
using MQTTnet;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Extensions.ManagedClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainProjectWorkApp.Properties;

namespace TrainProjectWorkApp
{
    public partial class WagonForm : Form
    {
        string userRole = "";
        string userNick = "";

        List<Dictionary<string, object>> trainList = new List<Dictionary<string, object>>();

        static int nrTrain = 0;
        int nrWagon = 0;

        #region Mqtt

        //Client Mqtt
        static IManagedMqttClient _mqttClient;
        //Topic nel quale ricevere i messaggi
        static string topicToReceive = "trainProjectWork/#/liveData/#";
        //Tempo in secondi tra ogni tentativo di riconnessione
        static int timeMqttReconnect = 5;
        //Nr di porta di Mqtt
        static int nPortMqtt = 707;
        //Stringa Ip del broker Mqtt
        static string serverMqtt = "localhost";

        #endregion Mqtt

        #region Move Form

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        #endregion Move Form

        #region Emoji

        //Emoji usate per ridimensionare la pagina
        string squareVoidEmoji = "◻";
        string squareDoubleEmoji = "❐";

        #endregion Emoji

        public WagonForm(string role, string nick)
        {
            #region WaitForm Open

            WaitForm wf = new WaitForm();

            wf.Show();
            wf.Refresh();

            #endregion WaitForm Open

            InitializeComponent();

            userRole = role;
            userNick = nick;

            #region MongoDb User List

            trainList = MongoDB.Client
                    .GetDatabase("trainProjectWork")
                    .GetCollection<Dictionary<string, object>>("Trains")
                   .Find(Builders<Dictionary<string, object>>.Filter.Empty)
                   .ToList();

            #endregion MongoDb User List

            if (!userRole.ToLower().Equals("Null"))
            {
                var trainListFilterWhere = trainList.Where(s => s["conductor"].ToString().Equals(userNick));

                if(trainListFilterWhere.Count() == 0)
                {
                    trainNumericUpDown.Enabled = false;
                    wagonNumericUpDown.Enabled = false;
                }else if (trainListFilterWhere.Count() > 0)
                {
                    nrTrain = trainListFilterWhere.Select(s => int.Parse(s["nrTrain"].ToString())).First();
                    nrWagon = trainListFilterWhere.Select(s => int.Parse(s["nrWagon"].ToString())).First();

                    trainNumericUpDown.Value = nrTrain;
                    trainNumericUpDown.Maximum = nrTrain;
                    trainNumericUpDown.Minimum = nrTrain;

                    wagonNumericUpDown.Value = 1;
                    wagonNumericUpDown.Maximum = nrWagon;
                    wagonNumericUpDown.Minimum = 1;
                }
                
            }
            else
            {
                //
            }

            

            #region Mqtt

            //Id randomico del Client
            string idNameClientMqtt = Guid.NewGuid().ToString("N");

            #region Opzioni Client MQTT
            // Creates a new client
            MqttClientOptionsBuilder builder = new MqttClientOptionsBuilder()
                                                    .WithClientId("TPW-" + idNameClientMqtt.ToString())
                                                    .WithTcpServer(serverMqtt, nPortMqtt)
                                                    .WithCredentials("TPW-" + idNameClientMqtt.ToString(), "testApp000");

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

                //Controllo se il dato è quello interessato
                /*
                if (int.Parse(json["nrTrain"].ToString()) == trainNumericUpDown.Value
                && int.Parse(json["nrWagon"].ToString()) == wagonNumericUpDown.Value)
                */
                if (int.Parse(json["nrWagon"].ToString()) == wagonNumericUpDown.Value)
                {

                    if (InvokeRequired)
                    {
                        try
                        {
                            this.Invoke(new MethodInvoker(delegate
                            {
                                //Aggiornamento valori
                                dateLabel.Text = DateTime.Now.ToString();
                                temperatureLabel.Text = $"{json["Temp"].ToString()} °C";
                                humidityLabel.Text = $"{json["Hum"].ToString()} %";
                                if (bool.Parse(json["Smoke"].ToString()) == true)
                                {
                                    smokePictureBox.Image = Resources._true;
                                }
                                else if (bool.Parse(json["Smoke"].ToString()) == false)
                                {
                                    smokePictureBox.Image = Resources.falseDaCambiare;
                                }
                                if (bool.Parse(json["Toilette"].ToString()) == true)
                                {
                                    toilettePictureBox.Image = Resources.open;
                                }
                                else if (bool.Parse(json["Toilette"].ToString()) == false)
                                {
                                    toilettePictureBox.Image = Resources._lock;
                                }
                                if (bool.Parse(json["Port"][0].ToString()) == true)
                                {
                                    port1PictureBox.Image = Resources.open;
                                }
                                else if (bool.Parse(json["Port"][0].ToString()) == false)
                                {
                                    port1PictureBox.Image = Resources._lock;
                                }
                                if (bool.Parse(json["Port"][1].ToString()) == true)
                                {
                                    port2PictureBox.Image = Resources.open;
                                }
                                else if (bool.Parse(json["Port"][1].ToString()) == false)
                                {
                                    port2PictureBox.Image = Resources._lock;
                                }
                                if (bool.Parse(json["Port"][2].ToString()) == true)
                                {
                                    port3PictureBox.Image = Resources.open;
                                }
                                else if (bool.Parse(json["Port"][2].ToString()) == false)
                                {
                                    port3PictureBox.Image = Resources._lock;
                                }
                                if (bool.Parse(json["Port"][3].ToString()) == true)
                                {
                                    port4PictureBox.Image = Resources.open;
                                }
                                else if (bool.Parse(json["Port"][3].ToString()) == false)
                                {
                                    port4PictureBox.Image = Resources._lock;
                                }
                            }));
                        }
                        catch (Exception)
                        { }
                    }
                }
            });
            #endregion Quando vengono ricevuti messaggi da MQTT

            #endregion Mqtt

            #region WaitForm Close

            wf.Close();

            #endregion WaitForm Close
        }


        //Metodo per il reset dei valori
        private void resetField()
        {
            dateLabel.Text = "Not Available";
            temperatureLabel.Text = "Not Available";
            humidityLabel.Text = "Not Available";
            smokePictureBox.Image = Resources.falseDaCambiare;
            toilettePictureBox.Image = Resources._lock;
            port1PictureBox.Image = Resources._lock;
            port2PictureBox.Image = Resources._lock;
            port3PictureBox.Image = Resources._lock;
            port4PictureBox.Image = Resources._lock;
        }

        #region Metodi usati per la connessione con MQTT

        public static void OnConnected(MqttClientConnectedEventArgs obj)
        {
            if(nrTrain != 0)
            {
                topicToReceive = $"trainProjectWork/{nrTrain}/liveData/#";
            }
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

        private void trainNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            resetField();
        }

        private void wagonNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            resetField();
        }

        //Se si vuole chiudere l'app
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //Se si vuole massimizzare o ridurre la grandezza dell'app
        private void resizeButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                resizeButton.Text = squareVoidEmoji;
                this.WindowState = FormWindowState.Normal;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                resizeButton.Text = squareDoubleEmoji;
                this.WindowState = FormWindowState.Maximized;
            }
        }

        //Se si vuole minimizzare l'app
        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Metodi per lo spostamento della schermata
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        //Metodo usato per il muovimento del Form
        private void headerTitleLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        //Quando si vuole chiudere il form
        private void WagonForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _mqttClient.StopAsync();
        }
    }
}
