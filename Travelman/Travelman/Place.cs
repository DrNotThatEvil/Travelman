using Newtonsoft.Json;

namespace Travelman
{
    [JsonConverter(typeof(PlaceConverter))]
    class Place
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string IconUrl { get; set; }
        public string Vicinity { get; set; }
        public float Rating { get; set; } // A rating of -1 is used for places where ratings are not applicable
        public GeoCode GeoCode { get; set; }

        public Place(string name, string type, string iconUrl, string vicinity, float rating, GeoCode geoCode)
        {
            Name = name;
            Type = type;
            IconUrl = iconUrl;
            Vicinity = vicinity;
            Rating = rating;
            GeoCode = geoCode;
        }
    }
}
