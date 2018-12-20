using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace TrainTesting.Models
{
    public class ApplicationDbContext
    {
        const string FileNameRead = "data.json";
        public List<BaseRequest> Requests { get; set; }
        public void Save()
        {
            string json = JsonConvert.SerializeObject(this);
            System.IO.File.WriteAllText(FileNameRead, json);
        }
        /// <summary>
        /// Загрузка данных из файла сериализации
        /// </summary>
        /// <returns></returns>
        internal static ApplicationDbContext Load()
        {
            if (File.Exists(FileNameRead))
            {
                ApplicationDbContext m;
                using (var reader = new StreamReader(FileNameRead))
                {
                    string json = reader.ReadToEnd();
                    m = JsonConvert.DeserializeObject<ApplicationDbContext>(json);
                }
                return m;
            }
            else
                return new ApplicationDbContext();
        }
    }
}
