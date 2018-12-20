using System;
using System.Collections.Generic;
using System.IO;

namespace TrainTesting.Models
{
    public class ApplicationDbContext
    {
        public List<BaseRequest> Requests { get; set; }

        /// <summary>
        /// Загрузка данных из файла сериализации
        /// </summary>
        /// <returns></returns>
        internal static ApplicationDbContext Load()
        {
            using (var reader = new StreamReader("data.json"))
            {
                string json = reader.ReadToEnd();
#error Дописать загрузку из файла 
            }
            // LOAD -------- https://www.newtonsoft.com/json
            //Product product = new Product();
            //product.Name = "Apple";
            //product.Expiry = new DateTime(2008, 12, 28);
            //product.Sizes = new string[] { "Small" };
            //string json = JsonConvert.SerializeObject(product);

            //throw new NotImplementedException();
        }
    }
}
