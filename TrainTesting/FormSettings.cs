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
    public partial class FormSettings : Form
    {
#warning remove all DataSource
#warning Add render on listbox (QueryStyle) settings
#warning Change render
        Main m;
        public FormSettings(Main m)
        {
            InitializeComponent();
            this.m = m;
            LoadSource();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.m.db.QueryStyles == null) this.m.db.QueryStyles = new List<Models.QueryStyle>();
            var item = new Models.QueryStyle()
            {
                ColorName = ColorName.Text,
                Status = Status.Text,
                TimeRequest = int.Parse(TimeRequest.Text)
            };
            this.m.db.QueryStyles.Add(item);
            QueryStyles.Items.Add(item);
        }

        void LoadSource()
        {
            foreach (var item in m.db.QueryStyles)
            {
                QueryStyles.Items.Add(item);
            }
        }

        private void QueryStyles_DrawItem(object sender, DrawItemEventArgs e)
        {
            UrlParseData.DrawItem(e, QueryStyles);
        }
    }
}
