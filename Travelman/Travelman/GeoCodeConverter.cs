using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Travelman
{
    /// <summary>
    /// Class used in the deserialization of a GeoCode location of the Google API.
    /// In this case, deserialization means converting json into a .NET object.
    /// </summary>
    class GeoCodeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Place);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);

            float latitude = obj["lat"].Value<float>();
            float longitude = obj["lng"].Value<float>();
            
            return new GeoCode(latitude, longitude);
        }

        public override bool CanWrite => false;

        // Serialization of a GeoCode is not implemented nor necessary. We throw a NIE to explicitly inform programmers.
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("The serialization of this type is not supported.");
        }
    }
}
