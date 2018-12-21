using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainTesting.FormsTools
{
    public partial class FormHeadersRequests : Form
    {
        Main m;
        public FormHeadersRequests(Main m)
        {
            InitializeComponent();
            this.m = m;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in m.db.Requests)
            {
                Uri u = new Uri(item.url);
                if(u.Host==textBox1.Text)
                {
                    if (item.Headers == null) item.Headers = new List<Models.HeaderRequest>();
                    item.Headers.Add(new Models.HeaderRequest()
                    {
                         Key = textBox2.Text,
                         Value = textBox3.Text
                    });
                }
            }
            m.UpdateRequests();
        }
    }
}
