using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Travelman
{
    /// <summary>
    /// Class used in the deserialization of nearby places returned by the Google API.
    /// In this case, deserialization means converting json into a .NET object.
    /// </summary>
    class PlaceConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Place);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);

            string name = obj.SelectToken("name").Value<string>();
            string type = obj.SelectToken("types[0]").Value<string>(); // Choose best term (index 0)
            string iconUrl = obj.SelectToken("icon").Value<string>();
            string vicinity = obj.SelectToken("vicinity").Value<string>();
            string photoReference = obj.SelectToken("photos[0].photo_reference")?.Value<string>() ?? "";
            float rating = obj.SelectToken("rating")?.Value<float>() ?? -1.0f;
            GeoCode geoCode = obj.SelectToken("geometry.location").ToObject<GeoCode>();

            return new Place(name, type, iconUrl, photoReference, vicinity, rating, geoCode);
        }

        public override bool CanWrite => false;

        // Serialization of a Place is not implemented nor necessary. We throw a NIE to explicitly inform programmers.
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("The serialization of this type is not supported.");
        }
    }
}