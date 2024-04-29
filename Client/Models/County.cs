using Newtonsoft.Json;

namespace Client.Models
{
    public class County
    {
        public int CountyId { get; set; }
        public string CountyName { get; set; }
        public List<Municipality>? Municipalities { get; set;}
    }
}
