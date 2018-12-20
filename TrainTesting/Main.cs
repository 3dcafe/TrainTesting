﻿using System;
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
            this.Text = String.Format("Train Testing {0}", version);
        }

        internal void UpdateRequests()
        {
#warning not refreshing afrerr add request
            listBox1.DataSource = db.Requests;
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
                        for (int i = 0; i < 100; i++)
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
                r.UrlParseDatas.Add(item);
                AddLog(item,r.url,"Red");
            }
        }

        int counterLogs = 0;
        void AddLog
            (
                object o, 
                string text = "", 
                string colorName = ""
            )
        {
            Invoke(new MethodInvoker(
               delegate 
               {
                   counterLogs++;
                   string inf = String.Format("{0} {1} {2}", 
                       counterLogs,
                       text,
                       o.ToString()
                       );
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
            var r = listBox1.SelectedItem as BaseRequest;
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
            e.DrawBackground();
            if (e.Index > -1)
            {
                UrlParseData data = listBox2.Items[e.Index] as UrlParseData;
                if(data.code != "OK")
                {
                    e.Graphics.FillRectangle(Brushes.Gray, e.Bounds);
                }
                using (Brush textBrush = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(listBox2.Items[e.Index].ToString(), e.Font, textBrush, e.Bounds.Location);
                }
                //if (e.Index == 0)
                //    e.Graphics.FillRectangle(Brushes.Green, e.Bounds);
                //else if (e.Index == 1)
                //    e.Graphics.FillRectangle(Brushes.Red, e.Bounds);
                //else
                //    
            }
        }
    }
}
