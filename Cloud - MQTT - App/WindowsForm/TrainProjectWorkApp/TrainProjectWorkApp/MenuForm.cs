using MongoDB.Driver;
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
    public partial class MenuForm : Form
    {
        #region Variabili

        string userNick = "";
        string userRole = "";

        List<Dictionary<string, object>> trainList = new List<Dictionary<string, object>>();

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

        public MenuForm(string nick, string role)
        {

            #region WaitForm Open

            WaitForm wf = new WaitForm();

            wf.Show();
            wf.Refresh();

            #endregion WaitForm Open

            InitializeComponent();

            #region Layout in base al Ruolo

            userNick = nick;
            userRole = role;

            nameLabel.Text = userNick;
            roleLabel.Text = userRole;

            if (userRole.Equals("Null"))
            {
                wagonButton.Text = "View Wagon Info";
            }
            else
            {
                wagonButton.Text = "View Train Info";
            }

            #endregion Layout in base al Ruolo

            #region MongoDb Train List

            trainList = MongoDB.Client
                    .GetDatabase("trainProjectWork")
                    .GetCollection<Dictionary<string, object>>("Trains")
                   .Find(Builders<Dictionary<string, object>>.Filter.Empty)
                   .ToList();

            #endregion MongoDb Train List

            #region WaitForm Close

            wf.Close();

            #endregion WaitForm Close

        }

        #endregion Costruttore

        #region Move Form

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

        #endregion Move Form

        #region Button

        //Quando si schiaccia il pulsante per vedere le informazioni dei vagoni
        private void wagonButton_Click(object sender, EventArgs e)
        {
            /*
            WagonForm wf = new WagonForm(userRole, userNick);
            this.Visible = false;
            wf.ShowDialog();
            this.Visible = true;
            */

            //Controllo del Form da aprire in base al ruolo
            //Se persona normale -> Avrà 1 solo treno e vede subito i corrispettivi vagoni
            //Se Admin o CapoStazione -> Vede tutti i treni e successivamente vede i vagoni del treno che sceglierà
            if (userRole.Equals("Null"))
            {
                //Query per ricavare il numero del treno a lui associato
                int nrTrain = trainList.Where(s => s["conductor"].ToString().Equals(userNick)).Select(s => int.Parse(s["nrTrain"].ToString())).FirstOrDefault();
                if(nrTrain != 0)
                {
                    SeeWagonForm swf = new SeeWagonForm(nrTrain);
                    this.Visible = false;
                    swf.ShowDialog();
                    this.Visible = true;
                }
                else
                {
                    //Nessun treno associato
                    //Mostro un form di errore
                }
            }
            else
            {
                //(SeeTrainForm)
                //Mostro prima Form treni, poi dai Form Treni passa al SeeWagonForm
                SeeTrainForm stf = new SeeTrainForm();
                this.Visible = false;
                stf.ShowDialog();
                this.Visible = true;
            }
        }

        #endregion Button
    }
}
