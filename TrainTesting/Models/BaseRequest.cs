using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTesting.Models
{
    public class BaseRequest
    {
#warning Расширить метод вызова
        public int id { get; set; }
        public string url { get; set; }
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Данные обработки
        /// </summary>
        [ForeignKey("BaseRequestId")]
        public virtual List<UrlParseData> UrlParseDatas { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", url);
        }
    }
}
