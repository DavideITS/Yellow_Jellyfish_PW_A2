using MQTTnet;
using MQTTnet.Client;
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

namespace TrainProjectWorkApp
{
    public partial class LoginForm : Form
    {

        #region Variabili

        List<Dictionary<string, object>> userList = new List<Dictionary<string, object>>();

        #region Mqtt

        //Client Mqtt
        static IManagedMqttClient _mqttClient;
        //Topic nel quale ricevere i messaggi
        static string topicToReceive = "trainProjectWork/testSendMessage";
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

        #endregion Variabili

        #region Costruttore

        public LoginForm()
        {
            #region WaitForm Open

            WaitForm wf = new WaitForm();

            wf.Show();
            wf.Refresh();

            #endregion WaitForm Open

            InitializeComponent();

            #region Sub Mqtt

            //Id randomico del Client
            string idNameClientMqtt = Guid.NewGuid().ToString("N");
            Console.Title = "Train Project Work App";

            #region Opzioni Client MQTT
            // Creates a new client
            MqttClientOptionsBuilder builder = new MqttClientOptionsBuilder()
                                                    .WithClientId("App-" + idNameClientMqtt.ToString())
                                                    .WithTcpServer(serverMqtt, nPortMqtt)
                                                    .WithCredentials("App-" + idNameClientMqtt.ToString(), "ConsolePassword000");

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
                var jsonString = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);

                //Estrazione topic
                string topic = e.ApplicationMessage.Topic;
                //Split del topic tramite "/"
                string[] topicSplit = topic.Split("/");
                //Conversione da Json String a Json
                var allJsonContent = JObject.Parse(jsonString);

                //Estrazione dei dati
                userList = allJsonContent["values"].Select(s => new Dictionary<string, object> {
                            { "nick", s["nick"].ToString() },
                            { "role", s["role"].ToString()},
                            { "password", s["password"].ToString()}
                                })
                                .ToList();

                Console.WriteLine($"\n[{DateTime.Now}] Message received in Topic: {topic}");
            });
            #endregion Quando vengono ricevuti messaggi da MQTT

            #endregion Sub Mqtt

            #region WaitForm Close

            wf.Close();

            #endregion WaitForm Close
        }

        #endregion Costruttore

        #region Metodi

        #region Bottoni Gestione Grandezza Form

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

        #endregion Bottoni Gestione Grandezza Form

        #region Login

        //Se si vuole mostrare o nascondere il campo d'inserimento della password
        private void seepasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(passwordTextBox.UseSystemPasswordChar == false)
            {
                passwordTextBox.UseSystemPasswordChar = true;
            }
            else if (passwordTextBox.UseSystemPasswordChar == true)
            {
                passwordTextBox.UseSystemPasswordChar = false;
            }
        }

        //Bottone di Login
        private void loginButton_Click(object sender, EventArgs e)
        {
            //Controllo che ci siano scritte all'interno dei campi utenti e password
            if((!passwordTextBox.Text.Replace(" ", "").Equals("")) && (!userTextBox.Text.Replace(" ", "").Equals("")))
            {
                var searchUser = userList.Where(s => s["nick"].ToString().Equals(userTextBox.Text) && s["password"].ToString().Equals(passwordTextBox.Text));
                //Controllo se viene trovata una corrispondenza per utente/password
                if (searchUser.Count() > 0)
                {
                    Console.WriteLine("Login Corretto");
                    //Estrazione dati utili
                    var userNick = searchUser.Select(s => new string(s["nick"].ToString().ToCharArray())).First();
                    var userRole = searchUser.Select(s => new string(s["role"].ToString().ToCharArray())).First();
                    //Visione MenuForm
                    MenuForm mf = new MenuForm(userNick, userRole);
                    mf.ShowDialog();
                }
                else
                {
                    Console.WriteLine("Login Non Avvenuto");
                }
            }
            passwordTextBox.Text = "";
            userTextBox.Text = "";
        }

        #endregion Login

        #region Metodi Mqtt

        //Metodo eseguito quando avviene una connessione con mqtt
        public static void OnConnected(MqttClientConnectedEventArgs obj)
        {
            _mqttClient.SubscribeAsync(topicToReceive);

            Console.WriteLine("Successfully connected.");
        }

        //Metodo eseguito quando avviene un errore di connessione con mqtt
        public static void OnConnectingFailed(ManagedProcessFailedEventArgs obj)
        {
            Console.WriteLine("Couldn't connect to broker.");
        }

        //Metodo eseguito quando avviene una disconnessione da mqtt
        public static void OnDisconnected(MqttClientDisconnectedEventArgs obj)
        {
            Console.WriteLine("Successfully disconnected.");
        }


        #endregion Metodi Mqtt

        #endregion Metodi

        #region Move Form
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
        #endregion Move Form


    }
}
