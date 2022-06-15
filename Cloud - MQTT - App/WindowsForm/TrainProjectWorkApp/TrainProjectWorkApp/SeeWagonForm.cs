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
    public partial class SeeWagonForm : Form
    {
        int nrTrain = 0;

        public SeeWagonForm(int train)
        {
            InitializeComponent();

            nrTrain = train;
        }
    }
}
