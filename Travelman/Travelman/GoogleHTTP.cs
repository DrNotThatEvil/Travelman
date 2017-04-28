using System.Collections.Generic;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Travelman
{
    class GoogleHttp : ILocationProvider
    {
        private const string Apikey = "AIzaSyBUnZVJgEMRfpppPPPkMAtQ9CyqYbITX_s";
        private const string BaseAddress = "https://maps.googleapis.com/maps/api/";
        private const string Language = "nl";

        /// <summary>
        /// Used for communicating with an external HTTP service.
        /// </summary>
        private readonly HttpClient _client;

        /// <summary>
        /// Stores a single instance of this class, used by the singleton pattern.
        /// </summary>
        private static GoogleHttp _instance;

        /// <summary>
        /// Private constructor only used by the Instance() method.
        /// </summary>
        private GoogleHttp()
        {
            _client = new HttpClient { BaseAddress = new Uri(BaseAddress) };
        }

        /// <summary>
        /// Gives the instance of GoogleHttp, while also ensuring
        /// that there can only be one single instance of GoogleHttp.
        /// This is part of the singleton pattern.
        /// </summary>
        /// <returns></returns>
        public static GoogleHttp Instance()
        {
            return _instance ?? (_instance = new GoogleHttp());
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
        public async Task<List<string>> GetAutocompleteList(string query)
        {
            string requestUri = "place/autocomplete/json?" + BuildUri(query);

            string responseBody = await _client.GetStringAsync(requestUri);
            JObject json = JObject.Parse(responseBody);
            IEnumerable<JToken> tokens = json.SelectTokens("$.predictions[*].description");

            return new List<string>(tokens.Values<string>());
        }

        /// <summary>
        /// Synchronous API call where we geocode the query and check if the status is OK.
        /// If not then it means google cannot find the specified location.
        /// </summary>
        /// <param name="query">Location to check</param>
        /// <returns>Location is valid</returns>
        public bool LocationIsValid(string query)
        {
            string requestUri = "place/autocomplete/json?" + BuildUri(query);

            string responseBody = _client.GetStringAsync(requestUri).Result;
            JObject json = JObject.Parse(responseBody);
            JToken token = json.SelectToken("$.status");
            return token.ToString() == "OK";
        }

        /// <summary>
        /// Builds a valid and safe URI.
        /// Parameters that are required to use the Google API are automatically added.
        /// </summary>
        /// <param name="query">Input for an API call</param>
        /// <param name="customParameters">Optional custom parameters</param>
        /// <returns>A valid and safe URI</returns>
        private static string BuildUri(string query, Dictionary<string, string> customParameters = null)
        {
            if (customParameters == null)
            {
                customParameters = new Dictionary<string, string>();
            }
            var parameters =
                new Dictionary<string, string>(customParameters)
                {
                    {"key", Apikey},
                    {"language", Language},
                    {"input", query}
                };

            var f = new FormUrlEncodedContent(parameters);
            string uri = f.ReadAsStringAsync().Result;
            return uri;
        }
    }
}
