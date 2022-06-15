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
    public partial class SeeWagonForm : Form
    {
        static int nrTrain = 0;

        List<Dictionary<string, object>> trainList = new List<Dictionary<string, object>>();

        static List<string[]> listBackupRow = new List<string[]>();

        #region Mqtt

        //Client Mqtt
        static IManagedMqttClient _mqttClient;
        //Tempo in secondi tra ogni tentativo di riconnessione
        static int timeMqttReconnect = 5;
        //Nr di porta di Mqtt
        static int nPortMqtt = 707;
        //Stringa Ip del broker Mqtt
        static string serverMqtt = "localhost";

        #endregion Mqtt

        #region Emoji

        //Emoji usate per ridimensionare la pagina
        string squareVoidEmoji = "◻";
        string squareDoubleEmoji = "❐";

        #endregion Emoji

        #region Move Form

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        #endregion Move Form

        #region Column Index

        int nrWagonIndexColumn = 0;
        int temperatureIndexColumn = 1;
        int humidityIndexColumn = 2;
        int smokeIndexColumn = 3;
        int toiletteIndexColumn = 4;
        int port1IndexColumn = 5;
        int port2IndexColumn = 6;
        int port3IndexColumn = 7;
        int port4IndexColumn = 8;

        #endregion

        public SeeWagonForm(int train)
        {
            #region WaitForm Open

            WaitForm wf = new WaitForm();

            wf.Show();
            wf.Refresh();

            #endregion WaitForm Open

            InitializeComponent();

            nrTrain = train;

            #region MongoDb User List

            trainList = MongoDB.Client
                    .GetDatabase("trainProjectWork")
                    .GetCollection<Dictionary<string, object>>("Trains")
                   .Find(Builders<Dictionary<string, object>>.Filter.Empty)
                   .ToList();

            #endregion MongoDb User List

            seeWagonList(nrTrain);

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


                if (InvokeRequired)
                {
                    try
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            //Aggiornamento valori
                            //dateLabel.Text = DateTime.Now.ToString();

                            int nrRow = wagonDataGridView.Rows.Count;

                            for(int i = 0; i < nrRow; i++)
                            {
                                if (int.Parse(wagonDataGridView.Rows[i].Cells[nrWagonIndexColumn].Value.ToString()) == int.Parse(json["nrWagon"].ToString()))
                                {
                                    dateLabel.Text = DateTime.Now.ToString();
                                    wagonDataGridView.Rows[i].Cells[temperatureIndexColumn].Value = $"{json["Temp"].ToString()} °C";
                                    wagonDataGridView.Rows[i].Cells[humidityIndexColumn].Value = $"{json["Hum"].ToString()} %";

                                    if (bool.Parse(json["Smoke"].ToString()) == true)
                                    {
                                        if(!listBackupRow[i][smokeIndexColumn].Equals("true"))
                                        {
                                            wagonDataGridView.Rows[i].Cells[smokeIndexColumn].Value = Resources._true;
                                            listBackupRow[i][smokeIndexColumn] = "true";
                                        }
                                    }
                                    else if (bool.Parse(json["Smoke"].ToString()) == false)
                                    {
                                        if (!listBackupRow[i][smokeIndexColumn].Equals("false"))
                                        {
                                            wagonDataGridView.Rows[i].Cells[smokeIndexColumn].Value = Resources.falseDaCambiare;
                                            listBackupRow[i][smokeIndexColumn] = "false";
                                        }
                                    }
                                    if (bool.Parse(json["Toilette"].ToString()) == true)
                                    {
                                        if (!listBackupRow[i][toiletteIndexColumn].Equals("true"))
                                        {
                                            wagonDataGridView.Rows[i].Cells[toiletteIndexColumn].Value = Resources.open;
                                            listBackupRow[i][toiletteIndexColumn] = "true";
                                        }
                                    }
                                    else if (bool.Parse(json["Toilette"].ToString()) == false)
                                    {
                                        if (!listBackupRow[i][toiletteIndexColumn].Equals("false"))
                                        {
                                            wagonDataGridView.Rows[i].Cells[toiletteIndexColumn].Value = Resources._lock;
                                            listBackupRow[i][toiletteIndexColumn] = "false";
                                        }
                                    }
                                    if (bool.Parse(json["Port"][0].ToString()) == true)
                                    {
                                        if (!listBackupRow[i][port1IndexColumn].Equals("true"))
                                        {
                                            wagonDataGridView.Rows[i].Cells[port1IndexColumn].Value = Resources.open;
                                            listBackupRow[i][port1IndexColumn] = "true";
                                        }
                                    }
                                    else if (bool.Parse(json["Port"][0].ToString()) == false)
                                    {
                                        if (!listBackupRow[i][port1IndexColumn].Equals("false"))
                                        {
                                            wagonDataGridView.Rows[i].Cells[port1IndexColumn].Value = Resources._lock;
                                            listBackupRow[i][port1IndexColumn] = "false";
                                        }
                                    }
                                    if (bool.Parse(json["Port"][1].ToString()) == true)
                                    {
                                        if (!listBackupRow[i][port2IndexColumn].Equals("true"))
                                        {
                                            wagonDataGridView.Rows[i].Cells[port2IndexColumn].Value = Resources.open;
                                            listBackupRow[i][port2IndexColumn] = "true";
                                        }
                                    }
                                    else if (bool.Parse(json["Port"][1].ToString()) == false)
                                    {
                                        if (!listBackupRow[i][port2IndexColumn].Equals("false"))
                                        {
                                            wagonDataGridView.Rows[i].Cells[port2IndexColumn].Value = Resources._lock;
                                            listBackupRow[i][port2IndexColumn] = "false";
                                        }
                                    }
                                    if (bool.Parse(json["Port"][2].ToString()) == true)
                                    {
                                        if (!listBackupRow[i][port3IndexColumn].Equals("true"))
                                        {
                                            wagonDataGridView.Rows[i].Cells[port3IndexColumn].Value = Resources.open;
                                            listBackupRow[i][port3IndexColumn] = "true";
                                        }
                                    }
                                    else if (bool.Parse(json["Port"][2].ToString()) == false)
                                    {
                                        if (!listBackupRow[i][port3IndexColumn].Equals("false"))
                                        {
                                            wagonDataGridView.Rows[i].Cells[port3IndexColumn].Value = Resources._lock;
                                            listBackupRow[i][port3IndexColumn] = "false";
                                        }
                                    }
                                    if (bool.Parse(json["Port"][3].ToString()) == true)
                                    {
                                        if (!listBackupRow[i][port4IndexColumn].Equals("true"))
                                        {
                                            wagonDataGridView.Rows[i].Cells[port4IndexColumn].Value = Resources.open;
                                            listBackupRow[i][port4IndexColumn] = "true";
                                        }
                                    }
                                    else if (bool.Parse(json["Port"][3].ToString()) == false)
                                    {
                                        if (!listBackupRow[i][port4IndexColumn].Equals("false"))
                                        {
                                            wagonDataGridView.Rows[i].Cells[port4IndexColumn].Value = Resources._lock;
                                            listBackupRow[i][port4IndexColumn] = "false";
                                        }
                                    }
                                }
                            }
                        }));
                    }
                    catch (Exception)
                    { }
                }
            });
            #endregion Quando vengono ricevuti messaggi da MQTT

            #endregion Mqtt

            #region WaitForm Close

            wf.Close();

            #endregion WaitForm Close
        }

        private void seeWagonList(int train)
        {
            wagonDataGridView.Visible = false;

            wagonDataGridView.AllowUserToAddRows = true;

            wagonDataGridView.Rows.Clear();

            List<DataGridViewRow> listRow = new List<DataGridViewRow>();

            int nrWagon = trainList.Where(s => int.Parse(s["nrTrain"].ToString()) == train).Select(s => Convert.ToInt32(s["nrWagon"].ToString()) /*new Int32(Int32.Parse(s["nrWagon"].ToString()*/).FirstOrDefault();

            for (int i = 1; i <= nrWagon; i++)
            {
                DataGridViewRow row = (DataGridViewRow)wagonDataGridView.Rows[0].Clone();

                string[] backupData = new string[9];

                row.Cells[nrWagonIndexColumn].Value = i.ToString();
                backupData[nrWagonIndexColumn] = i.ToString();

                row.Cells[temperatureIndexColumn].Value = "Not Available";
                backupData[temperatureIndexColumn] = "Not Available";

                row.Cells[humidityIndexColumn].Value = "Not Available";
                backupData[humidityIndexColumn] = "Not Available";

                row.Cells[smokeIndexColumn].Value = Resources.falseDaCambiare;
                backupData[smokeIndexColumn] = "false";

                row.Cells[toiletteIndexColumn].Value = Resources._lock;
                backupData[toiletteIndexColumn] = "false";

                row.Cells[port1IndexColumn].Value = Resources._lock;
                backupData[port1IndexColumn] = "false";

                row.Cells[port2IndexColumn].Value = Resources._lock;
                backupData[port2IndexColumn] = "false";

                row.Cells[port3IndexColumn].Value = Resources._lock;
                backupData[port3IndexColumn] = "false";

                row.Cells[port4IndexColumn].Value = Resources._lock;
                backupData[port4IndexColumn] = "false";

                listRow.Add(row);
                listBackupRow.Add(backupData);
            }

            wagonDataGridView.Rows.AddRange(listRow.ToArray());

            wagonDataGridView.AllowUserToAddRows = false;

            wagonDataGridView.Visible = true;
        }

        #region Metodi usati per la connessione con MQTT

        public static void OnConnected(MqttClientConnectedEventArgs obj)
        {
            string topicToReceive = $"trainProjectWork/{nrTrain}/liveData/#";

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

        private void SeeWagonForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _mqttClient.StopAsync();
        }
    }
}
