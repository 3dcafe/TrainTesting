using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainTesting.Models;
using TrainTesting.FormsTools;
using System.Drawing;

namespace TrainTesting
{
    public partial class Main : Form
    {
        public ApplicationDbContext db;
        public Main()
        {
            InitializeComponent();
            db = ApplicationDbContext.Load();
            UpdateRequests();
        }

        private void addRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRequest add = new AddRequest(this);
            add.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            var Name = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            this.Text = String.Format("{1} - {0}", version, Name);
        }

        internal void UpdateRequests()
        {
            listRequests.Items.Clear();
            foreach (var item in db.Requests)
            {
                listRequests.Items.Add(item);
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                var items = db.Requests;
                foreach (var item in items)
                {
                    Task.Run(async () =>
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            await TestRAsync(item);
                        }
                    });
                }
            });
        }

        async Task TestRAsync(BaseRequest r)
        {
            var sw = new Stopwatch();
            sw.Start();
            using (HttpClient client = new HttpClient())
            {
                if(r.Headers!=null)
                {
                    foreach (var header in r.Headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }
                HttpResponseMessage response = await client.GetAsync(r.url);
                var s = response.Content.ReadAsStringAsync().Result.Length;
                sw.Stop();
                if (r.UrlParseDatas == null) r.UrlParseDatas = new List<UrlParseData>();
                var item = new UrlParseData()
                {
                    url = r.url,
                    code = response.StatusCode.ToString(),
                    DateAdd = DateTime.Now,
                    length = s,
                    Time = sw.ElapsedMilliseconds,
                };
                if(db.QueryStyles.Where(x => x.Status == item.code && x.TimeRequest <= item.Time).Any())
                {
                    var q = db.QueryStyles.Where(x => x.Status == item.code && x.TimeRequest >= item.Time).OrderBy(x => x.TimeRequest).FirstOrDefault();
                    if (q != null)
                        item.SetStyle(q);
                }
                r.UrlParseDatas.Add(item);
                AddLog(item);
            }
        }
        void AddLog(object o)
        {
            Invoke(new MethodInvoker(
               delegate 
               {
                   listBox2.Items.Add(o);
               }
            ));
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings sett = new FormSettings(this);
            sett.Show();
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormStatistics form = new FormStatistics();
            form.Show();
        }

        private void addHeaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var r = listRequests.SelectedItem as BaseRequest;
            FormRequestHeaders form = new FormRequestHeaders(this,r);
            form.Show();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            db.Save();
        }

        private void getUrlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGetUrls form = new FormGetUrls(this);
            form.Show();
        }

        private void listBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            UrlParseData.DrawItem(e,listBox2);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var r = listRequests.SelectedItem as BaseRequest;
            db.Requests.Remove(r);
            this.UpdateRequests();
        }
    }
}
