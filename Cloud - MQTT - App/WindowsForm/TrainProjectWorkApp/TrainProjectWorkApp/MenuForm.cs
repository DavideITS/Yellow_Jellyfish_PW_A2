using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainProjectWorkApp
{
    public partial class MenuForm : Form
    {
        string userNick = "";
        string userRole = "";

        public MenuForm(string nick, string role)
        {

            #region WaitForm Open

            WaitForm wf = new WaitForm();

            wf.Show();
            wf.Refresh();

            #endregion WaitForm Open

            InitializeComponent();

            userNick = nick;
            userRole = role;

            #region WaitForm Close

            wf.Close();

            #endregion WaitForm Close

        }
    }
}
