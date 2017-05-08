using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Travelman
{
    /// <summary>
    /// Class used in the deserialization of nearby places returned by the Google API.
    /// </summary>
    class PlaceConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Place));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);

            string name = obj.SelectToken("name").Value<string>();
            string type = obj.SelectToken("types[0]").Value<string>(); // Choose best term (index 0)
            string iconUrl = obj.SelectToken("icon").Value<string>();
            string vicinity = obj.SelectToken("vicinity").Value<string>();
            float rating = obj.SelectToken("rating")?.Value<float>() ?? -1.0f;
            GeoCode geoCode = obj.SelectToken("geometry.location").ToObject<GeoCode>();

            return new Place(name, type, iconUrl, vicinity, rating, geoCode);
        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
