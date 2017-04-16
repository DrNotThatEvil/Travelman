using System.Collections.Generic;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Travelman
{
    class GoogleHTTP
    {
        private const string APIKEY = "AIzaSyBUnZVJgEMRfpppPPPkMAtQ9CyqYbITX_s";
        private const string BASE_ADDRESS = "https://maps.googleapis.com/maps/api/";
        private const string LANGUAGE = "nl";

        /// <summary>
        /// Used for communicating with an external HTTP service.
        /// </summary>
        private HttpClient _client;

        /// <summary>
        /// Stores a single instance of this class, used by the singleton pattern.
        /// </summary>
        private static GoogleHTTP _instance;

        /// <summary>
        /// Private constructor only used by the Instance() method.
        /// </summary>
        private GoogleHTTP()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(BASE_ADDRESS);
        }

        /// <summary>
        /// Gives the instance of GoogleHTTP, while also ensuring
        /// that there can only be one single instance of GoogleHTTP.
        /// This is part of the singleton pattern.
        /// </summary>
        /// <returns></returns>
        public static GoogleHTTP Instance()
        {
            if (_instance == null) { _instance = new GoogleHTTP(); }
            return _instance;
        }

        /// <summary>
        /// Gets a list of place predictions using a query specified by the user.
        /// This API call is asynchronous, this allows us to not make the application freeze
        /// while we wait on the response from the Google API.
        /// See the documentation of the required API method here:
        /// https://developers.google.com/places/web-service/autocomplete
        /// </summary>
        /// <param name="query">Search terms</param>
        /// <returns>Asynchronous list of place names</returns>
        public async Task<List<string>> getAutocompleteList(string query)
        {
            string requestUri = "place/autocomplete/json?" + BuildUri(query);

            string response_body = await _client.GetStringAsync(requestUri);
            JObject json = JObject.Parse(response_body);
            IEnumerable<JToken> tokens = json.SelectTokens("$.predictions[*].description");

            return new List<string>(tokens.Values<string>());
        }

        /// <summary>
        /// Builds a valid and safe URI.
        /// Parameters that are required to use the Google API are automatically added.
        /// </summary>
        /// <param name="query">Input for an API call</param>
        /// <param name="customParameters">Optional custom parameters</param>
        /// <returns>A valid and safe URI</returns>
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
    }
}
