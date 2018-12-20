using System;

namespace TrainTesting.Models
{
    public class UrlParseData
    {
        public string url { get; set; } = string.Empty;
        public long length { get; set; }
        public long Time { get; set; }
        public string code { get; set; } = "0";
        public DateTime DateAdd { get; set; } = DateTime.Now;
        public override string ToString()
        {
            return string.Format("{2} time: {0} - length: {1}", Time,length,url);
        }
    }
}
