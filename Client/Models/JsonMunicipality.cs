using Newtonsoft.Json;

namespace Client.Models
{
    public class JsonMunicipality
    {
        public List<string> lan_code { get; set; }
        public List<string> lan_name { get; set; }
        public List<string> kom_code { get; set; }
        public List<string> kom_name { get; set; }
        public string kom_area_code { get; set; }
        public string kom_type { get; set; }
    }
}
