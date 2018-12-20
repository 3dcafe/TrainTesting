using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainTesting
{
    public partial class FormSettings : Form
    {
        Main m;
        public FormSettings(Main m)
        {
            InitializeComponent();
            this.m = m;
            GrayingFailedRequests.Checked = m.db.GrayingFailedRequests;
        }
        /// <summary>
        /// Saved data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            m.db.GrayingFailedRequests = GrayingFailedRequests.Checked;
        }
    }
}
