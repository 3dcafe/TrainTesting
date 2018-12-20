using System.Collections.Generic;

namespace TrainTesting.Models.Provides
{
    public class OdataValue
    {
        public string name { get; set; }
        public string kind { get; set; }
        public string url { get; set; }
    }
    public class Odata
    {
        public List<OdataValue> value { get; set; }
    }
}
