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
        QueryStyle SelectedQueryStyle = null;
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
#warning Validate Form
            if(SelectedQueryStyle==null)
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
                ClearForm();
            }
            else
            {
                SelectedQueryStyle.ColorName = ColorName.Text;
                SelectedQueryStyle.Status = Status.Text;
                SelectedQueryStyle.TimeRequest = int.Parse(TimeRequest.Text);
                ClearForm();
                LoadSource();
            }
        }

        void ClearForm()
        {

        }

        void LoadSource()
        {
            QueryStyles.Items.Clear();
            if (m.db.QueryStyles == null) m.db.QueryStyles = new List<QueryStyle>();
            foreach (var item in m.db.QueryStyles)
            {
                QueryStyles.Items.Add(item);
            }
        }

        private void QueryStyles_DrawItem(object sender, DrawItemEventArgs e)
        {
            UrlParseData.DrawItem(e, QueryStyles);
        }

        private void QueryStyles_DoubleClick(object sender, EventArgs e)
        {
            this.SelectedQueryStyle = QueryStyles.SelectedItem as QueryStyle;
            LoadFromSelectedQuery();
        }

        void LoadFromSelectedQuery()
        {
            ColorName.Text = this.SelectedQueryStyle.ColorName;
            Status.Text = SelectedQueryStyle.Status;
            TimeRequest.Text = SelectedQueryStyle.TimeRequest.ToString();
        }
    }
}
