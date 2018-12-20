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
        public FormRequestHeaders(BaseRequest request)
        {
            InitializeComponent();
            this._request = request;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
               // var req = db.Requests.Where(x => x.id == this._request.id).FirstOrDefault();
                var h = new HeaderRequest()
                {
                     RequestId = _request.id,
                     Key = textBox1.Text,
                     Value = textBox2.Text,
                };
                db.SaveChanges();
            }
            ClearForm();
            */
        }

        void ClearForm()
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
        }
    }
}
