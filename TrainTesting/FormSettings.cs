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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.m.db.QueryStyles == null) this.m.db.QueryStyles = new List<Models.QueryStyle>();
            this.m.db.QueryStyles.Add(new Models.QueryStyle()
            {
                 ColorName = ColorName.Text,
                 Status= Status.Text,
                 TimeRequest =  int.Parse(TimeRequest.Text)
            });
        }
    }
}
