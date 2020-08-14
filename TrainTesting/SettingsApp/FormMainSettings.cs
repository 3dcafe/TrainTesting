using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainTesting.SettingsApp
{
    public partial class FormMainSettings : Form
    {
        Main mainForm;
        public FormMainSettings(Main m)
        {
            InitializeComponent();
            this.mainForm = m;
            countRequests.Text = this.mainForm.db.countRequests.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.mainForm.db.countRequests = int.Parse(countRequests.Text);
        }
    }
}
