using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrainTesting.Models
{
    public class UrlParseData: QueryStyle
    {
        public string url { get; set; } = string.Empty;
        public long length { get; set; }
        public long Time { get; set; }
        public string code { get; set; } = "0";
        public DateTime DateAdd { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return string.Format("{2} time: {0} - length: {1} code: {3}", Time,length,url, code);
        }

        internal static void DrawItem(DrawItemEventArgs e,ListBox listBox)
        {
            e.DrawBackground();
            if (e.Index > -1)
            {
                QueryStyle data = listBox.Items[e.Index] as QueryStyle;
                Color c = Color.FromName(data.ColorName);
                SolidBrush solidBrush = new SolidBrush(c);
                e.Graphics.FillRectangle(solidBrush, e.Bounds);

                using (Brush textBrush = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(listBox.Items[e.Index].ToString(), e.Font, textBrush, e.Bounds.Location);
                }
            }
        }

        internal void SetStyle(QueryStyle q)
        {
            this.ColorName = q.ColorName;
            this.Status = q.Status;
            this.TimeRequest = q.TimeRequest;
        }
    }
}
