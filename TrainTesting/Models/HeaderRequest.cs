using System.ComponentModel.DataAnnotations.Schema;

namespace TrainTesting.Models
{
    public class HeaderRequest
    {
        public int id { get; set; }
        public int RequestId { get; set; }
        [ForeignKey("RequestId")]
        public virtual BaseRequest Request { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
