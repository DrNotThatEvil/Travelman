using System.Globalization;
using Newtonsoft.Json;

namespace Travelman.Data
{
    [JsonConverter(typeof(GeoCodeConverter))]
    public class GeoCode
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        // It is assumed that (0.0, 0.0) is an invalid GeoCode.
        public GeoCode() : this(0.0f, 0.0f) { }

        public GeoCode(float latitude, float longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override string ToString()
        {
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo("en-GB"); // Enforce use of '.' as decimal separator
            return Latitude.ToString(cultureInfo) + "," + Longitude.ToString(cultureInfo);
        }

        protected bool Equals(GeoCode other)
        {
            return Latitude.Equals(other.Latitude) && Longitude.Equals(other.Longitude);
        }
    }
}