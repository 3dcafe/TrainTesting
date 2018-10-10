using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTesting.Models
{
    public class UrlParseData
    {
#warning Сделать статус
        public int id { get; set; }
        public int BaseRequestId { get; set; }
        [ForeignKey("BaseRequestId")]
        public virtual BaseRequest Request { get; set; }
        public long length { get; set; }
        public long Time { get; set; }
        public DateTime DateAdd { get; set; } = DateTime.Now;
        public override string ToString()
        {
            return string.Format("time: {0} - length: {1} url: {2}", Time,length, Request.url);
        }
    }
}
