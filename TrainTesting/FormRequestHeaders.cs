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
    public partial class FormRequestHeaders : Form
    {
        BaseRequest _request;
        Main m;
        public FormRequestHeaders(Main m,BaseRequest request)
        {
            InitializeComponent();
            this._request = request;
            this.m = m;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_request.Headers == null) _request.Headers = new List<HeaderRequest>();
            _request.Headers.Add(new HeaderRequest()
            {
                Key = textBox1.Text,
                Value = textBox2.Text,
            });
            this.ClearForm();
        }

        void ClearForm()
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
        }
    }
}
