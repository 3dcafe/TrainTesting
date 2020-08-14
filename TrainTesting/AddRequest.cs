using System;
using System.Collections.Generic;
using System.Linq;
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
            List<string> items = this.mainForm.db.Requests.Where(x => !string.IsNullOrEmpty(x.tag)).Select(x => x.tag).GroupBy(x => x).Select(x => x.Key).ToList();
            this.TagsCB.DataSource = items;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (mainForm.db.Requests == null)
                mainForm.db.Requests = new List<BaseRequest>();
            mainForm.db.Requests.Add(new BaseRequest()
            {
                url = textBox1.Text,
                tag = TagsCB.Text,
                DateAdd = DateTime.Now
            });
            this.mainForm.UpdateRequests();
            this.Close();
        }
    }
}
