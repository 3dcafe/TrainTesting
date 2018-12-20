using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainTesting.Models;

namespace TrainTesting
{
    public partial class AddRequest : Form
    {
        Main mainForm;
        public AddRequest(Main m)
        {
            InitializeComponent();
            this.mainForm = m;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            db.Requests.Add(new BaseRequest()
            {
                url = textBox1.Text,
                DateAdd = DateTime.Now
            });
            this.mainForm.UpdateRequests();
            this.Close();
            */
        }
    }
}
