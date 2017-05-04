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
            var parameters = new Dictionary<string, string> {{"input", query}};
            string requestUri = "place/autocomplete/json?" + BuildUri(parameters);
            try
            {
                string responseBody = await _client.GetStringAsync(requestUri);
                JObject json = JObject.Parse(responseBody);
                IEnumerable<JToken> tokens = json.SelectTokens("$.predictions[*].description");

                return new List<string>(tokens.Values<string>());
            }
            catch (Exception)
            {
                return new List<string>(); // Connectivity issue or API related problem
            }
        }

        /// <summary>
        /// Synchronous API call where we check if both locations exist, and if google knows
        /// a route between the two points.
        /// </summary>
        /// <param name="start">Starting location query</param>
        /// <param name="destination">Destination query</param>
        /// <returns>Route is possible</returns>
        public bool RouteIsPossible(string start, string destination)
        {
            var parameters = new Dictionary<string, string>
            {
                { "origin", start },
                { "destination", destination }
            };
            string requestUri = "directions/json?" + BuildUri(parameters);
            try
            {
                string responseBody = _client.GetStringAsync(requestUri).Result;
                JObject json = JObject.Parse(responseBody);
                JToken token = json.SelectToken("$.status");
                return token.ToString() == "OK";
            }
            catch (Exception)
            {
                return false; // Connectivity issue or API related problem
            }
        }

        /// <summary>
        /// Builds a valid and safe URI.
        /// Parameters that are required to use the Google API are automatically added.
        /// This is used to specify extra parameters.
        /// </summary>
        /// <param name="parameters">Parameters to add</param>
        /// <returns>A valid and safe URI</returns>
        private static string BuildUri(IDictionary<string, string> parameters)
        {
            parameters.Add("key", Apikey);
            parameters.Add("language", Language);

            var f = new FormUrlEncodedContent(parameters);
            return f.ReadAsStringAsync().Result;
        }
    }
}
