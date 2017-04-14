using System.Collections.Generic;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Travelman
{
    class GoogleHTTP
    {
        private const string APIKEY = "AIzaSyBUnZVJgEMRfpppPPPkMAtQ9CyqYbITX_s";
        private const string BASE_ADDRESS = "https://maps.googleapis.com/maps/api/";
        private const string LANGUAGE = "nl";
        private const string PLACE_TYPE = "(cities)"; 
        private HttpClient client;
        private static GoogleHTTP instance;


        private GoogleHTTP()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(BASE_ADDRESS);
            //client.DefaultRequestHeaders.Add("key", APIKEY);
            //client.DefaultRequestHeaders.Add("types", PLACE_TYPE);
            //client.DefaultRequestHeaders.Add("language", LANGUAGE);
            //"place/autocomplete/json?input=Vict&types=(cities)&language=pt_BR"
        }

        public static GoogleHTTP Instance()
        {
            if (instance == null) { instance = new GoogleHTTP(); }
            return instance;
        }

        //https://developers.google.com/places/web-service/autocomplete
        public async Task<List<string>> getAutocompleteList(string query)
        {
            string requestUri = "place/autocomplete/json?" + BuildUri(query) 
                + UnsafeParameter("types", PLACE_TYPE);

            string response_body = await client.GetStringAsync(requestUri);
            JObject json = JObject.Parse(response_body);
            IEnumerable<JToken> tokens = json.SelectTokens("$.predictions[*].description");

            return new List<string>(tokens.Values<string>());
        }

        private Task<string> GetAsync(string requestUri)
        {
            return client.GetStringAsync(requestUri);
        }

        private string BuildUri(string query, Dictionary<string, string> customParameters = null)
        {
            if (customParameters == null)
            {
                customParameters = new Dictionary<string, string>();
            }
            Dictionary<string, string> parameters = new Dictionary<string, string>(customParameters);

            parameters.Add("key", APIKEY);
            parameters.Add("language", LANGUAGE);
            parameters.Add("input", query);


            FormUrlEncodedContent f = new FormUrlEncodedContent(parameters);
            string uri = f.ReadAsStringAsync().Result;
            return uri;
        }

        private string UnsafeParameter(string key, string value)
        {
            return string.Format("&{0}={1}", key, value);
        }
    }
}
