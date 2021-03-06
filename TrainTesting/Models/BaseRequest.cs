﻿using System;
using System.Collections.Generic;

namespace TrainTesting.Models
{
    public class BaseRequest
    {
        public string url { get; set; }
        public string tag { get; set; }
        public DateTime DateAdd { get; set; } = DateTime.Now;
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
            if(Headers==null)
                return string.Format("{1} - {0}", url,tag);
            else
                return string.Format("{2} - {0} ({1})", url,Headers.Count.ToString(), tag);
        }
    }
}
