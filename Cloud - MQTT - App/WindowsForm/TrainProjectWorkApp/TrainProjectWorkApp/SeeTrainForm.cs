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
using TrainProjectWorkApp.Properties;

namespace TrainProjectWorkApp
{
    public partial class SeeTrainForm : Form
    {

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

        #region Column Index

        int trainColumnIndex = 0;
        int nrWagonColumnIndex = 1;
        int stationmasterColumnIndex = 2;

        #endregion Column Index

        public SeeTrainForm()
        {
            #region WaitForm Open

            WaitForm wf = new WaitForm();

            wf.Show();
            wf.Refresh();

            #endregion WaitForm Open

            InitializeComponent();

            #region MongoDb Train List

            trainList = MongoDB.Client
                    .GetDatabase("trainProjectWork")
                    .GetCollection<Dictionary<string, object>>("Trains")
                   .Find(Builders<Dictionary<string, object>>.Filter.Empty)
                   .ToList();

            seeTrainList();

            #endregion MongoDb Train List

            #region WaitForm Close

            wf.Close();

            #endregion WaitForm Close
        }

        private void trainDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == trainColumnIndex)
            {
                int nrTrainSelected = int.Parse(trainDataGridView[trainColumnIndex, e.RowIndex].Value.ToString());

                SeeWagonForm swf = new SeeWagonForm(nrTrainSelected);
                this.Visible = false;
                swf.ShowDialog();
                this.Visible = true;
            }
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

        private void seeTrainList()
        {
            trainDataGridView.Visible = false;

            trainDataGridView.AllowUserToAddRows = true;

            trainDataGridView.Rows.Clear();

            trainDataGridView.Columns[trainColumnIndex].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            trainDataGridView.Columns[nrWagonColumnIndex].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            trainDataGridView.Columns[stationmasterColumnIndex].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            List<DataGridViewRow> listRow = new List<DataGridViewRow>();

            foreach (var train in trainList)
            {
                DataGridViewRow row = (DataGridViewRow)trainDataGridView.Rows[0].Clone();

                row.Cells[trainColumnIndex].Value = int.Parse(train["nrTrain"].ToString());

                row.Cells[nrWagonColumnIndex].Value = int.Parse(train["nrWagon"].ToString());

                row.Cells[stationmasterColumnIndex].Value = train["conductor"].ToString();

                listRow.Add(row);
            }

            trainDataGridView.Rows.AddRange(listRow.ToArray());

            trainDataGridView.AllowUserToAddRows = false;

            trainDataGridView.Visible = true;
        }
    }
}
