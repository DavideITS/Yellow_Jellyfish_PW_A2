using MongoDB.Driver;
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

            Console.Title = "Train Project Work's App";

            #region MongoDb User List

            userList = MongoDB.Client
                    .GetDatabase("trainProjectWork")
                    .GetCollection<Dictionary<string, object>>("Users")
                   .Find(Builders<Dictionary<string, object>>.Filter.Empty)
                   .ToList();

            #endregion MongoDb User List

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
            login();
        }

        //Quando viene premuto un tasto nel userTextBox
        private void userTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //Se il tasto premuto è l'invio
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

        //Quando viene premuto un tasto nel passwordTextBox
        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //Se il tasto premuto è l'invio
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

        //Quando si vuole effettuare il Login
        private void login()
        {
            //Controllo che ci siano scritte all'interno dei campi utenti e password
            if ((!passwordTextBox.Text.Replace(" ", "").Equals("")) && (!userTextBox.Text.Replace(" ", "").Equals("")))
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
