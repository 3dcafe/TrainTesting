using System;

namespace TrainTesting.Models
{
    public class UrlParseData
    {
#warning Сделать статус
        public int id { get; set; }
        public int BaseRequestId { get; set; }
        public virtual BaseRequest Request { get; set; }
        public long length { get; set; }
        public long Time { get; set; }
        public string code { get; set; } = "0";
        public DateTime DateAdd { get; set; } = DateTime.Now;
        public override string ToString()
        {
            return string.Format("{3} - time: {0} - length: {1} url: {2}", Time,length, Request.url,code);
        }
    }
}
