namespace Client.Models
{
    public class Geometry
    {
        public List<List<List<double>>> coordinates { get; set; }
        public string type { get; set; }
    }

    public class GeoPoint2d
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class GeoShape
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }

    public class Properties
    {
    }

    public class JsonCounty
    {
        public GeoPoint2d geo_point_2d { get; set; }
        public GeoShape geo_shape { get; set; }
        public string year { get; set; }
        public List<string> lan_code { get; set; }
        public List<string> lan_name { get; set; }
        public string lan_area_code { get; set; }
        public string lan_type { get; set; }
    }
}
