using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainTesting.Models;

namespace TrainTesting
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
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
            this.Text = String.Format("Train Testing {0}", version);
        }

        internal void UpdateRequests()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                listBox1.DataSource = db.Requests.ToList();
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    for (int i = 0; i < 100; i++)
                    {
                        var items = db.Requests.ToList();
                        foreach (var item in items)
                        {
                            await TestRAsync(item);
                        }
                    }
                }
            });
        }

        async Task TestRAsync(BaseRequest r)
        {
            var sw = new Stopwatch();
            sw.Start();
            using (HttpClient client = new HttpClient())
            {
                var responseString = await client.GetStringAsync(r.url);
                var s = responseString.Length;
                sw.Stop();
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var item  =  db.UrlParseDatas.Add(new UrlParseData()
                    {
                         BaseRequestId = r.id,
                         DateAdd = DateTime.Now,
                         length = s,
                         Time = sw.ElapsedMilliseconds
                    });
                    db.SaveChanges();
                    item.Request = r;
                    AddLog(item);
                }
            }
        }

        void AddLog(Object o)
        {
            Invoke(new MethodInvoker(
               delegate {
                   listBox2.Items.Add(o); }
               ));
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings sett = new FormSettings();
            sett.Show();
        }
    }
}
