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
        string userNick = "";
        string userRole = "";

        #region Emoji

        //Emoji usate per ridimensionare la pagina
        string squareVoidEmoji = "◻";
        string squareDoubleEmoji = "❐";

        #endregion Emoji

        #region Move Form

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        #endregion Move Form

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
                trainButton.Visible = false;
                wagonButton.Visible = true;
            }else
            {
                trainButton.Visible = true;
                wagonButton.Visible = false;
            }

            #endregion Layout in base al Ruolo

            #region WaitForm Close

            wf.Close();

            #endregion WaitForm Close

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

        //Quando si schiaccia il pulsante per vedere le informazioni dei vagoni
        private void wagonButton_Click(object sender, EventArgs e)
        {
            /*
            WagonForm wf = new WagonForm(userRole, userNick);
            this.Visible = false;
            wf.ShowDialog();
            this.Visible = true;
            */

            if (userRole.Equals("Null"))
            {
                SeeWagonForm swf = new SeeWagonForm(1);
                this.Visible = false;
                swf.ShowDialog();
                this.Visible = true;
            }
            else
            {
                //(SeeTrainForm)
                //Mostro prima Form treni, poi dai Form Treni passa al SeeWagonForm
            }
        }
    }
}
