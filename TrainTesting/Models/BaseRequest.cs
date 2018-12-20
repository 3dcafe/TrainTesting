using System;
using System.Collections.Generic;

namespace TrainTesting.Models
{
    public class BaseRequest
    {
        public int id { get; set; }
        public string url { get; set; }
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Данные обработки
        /// </summary>
        public virtual List<UrlParseData> UrlParseDatas { get; set; }
        /// <summary>
        /// Заголовки для заполса
        /// </summary>
        public virtual List<HeaderRequest> Headers { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", url);
        }
    }
}
