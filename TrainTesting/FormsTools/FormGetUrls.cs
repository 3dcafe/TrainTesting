using Newtonsoft.Json;
using System;
using System.Net;
using System.Windows.Forms;
using TrainTesting.Models.Provides;

namespace TrainTesting.FormsTools
{
    public partial class FormGetUrls : Form
    {
        Main m;
        public FormGetUrls(Main m)
        {
            InitializeComponent();
            this.m = m;
        }

        private void button1_Click(object sender, EventArgs e)
        {
#warning  Валидацию
#warning  И выбор поставщика провайдера услуг
#warning  В поставщике сделать интерфейс который будет во всех поставщиках некая зависимость
            using (WebClient wc = new WebClient())
            {
                Uri u = new Uri(textBox1.Text);
                var json = wc.DownloadString(textBox1.Text);
                Odata data = JsonConvert.DeserializeObject<Odata>(json);
                foreach (var item in data.value)
                {
                    string doUrl = string.Format("{0}://{1}/odata/{2}",
                        u.Scheme,
                        u.DnsSafeHost,
                        item.url
                        );
                    m.db.Requests.Add(new Models.BaseRequest()
                    {
                         url = doUrl   
                    });
                }
                m.UpdateRequests();
            }
        }
    }
}
