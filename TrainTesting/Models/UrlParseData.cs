using System;

namespace TrainTesting.Models
{
    public class UrlParseData
    {
#warning Сделать статус
        public long length { get; set; }
        public long Time { get; set; }
        public string code { get; set; } = "0";
        public DateTime DateAdd { get; set; } = DateTime.Now;
        public override string ToString()
        {
            return string.Format("time: {0} - length: {1}", Time,length);
        }
    }
}
