using System.Collections.Generic;
using System.Net.Http;
using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Documents;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Travelman
{
    class GoogleHttp : ILocationProvider, IPlacesProvider
    {
        private const string Apikey = "AIzaSyBUnZVJgEMRfpppPPPkMAtQ9CyqYbITX_s";
        private const string BaseAddress = "https://maps.googleapis.com/maps/api/";
        private const string Language = "nl";

        /// <summary>
        /// All photos requested from the Google Places API should be at maximum these dimensions.
        /// 1600 is the limit defined by the API.
        /// </summary>
        private const int PhotoMaxHeight = 1600, PhotoMaxWidth = 1600;

        /// <summary>
        /// Include nearby places within x meters of location.
        /// API does not support a radius bigger than 50 kilometers.
        /// </summary>
        private const int MaximumNearbyRadius = 50000;

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
        /// Get the latitude and longitude of the specified address.
        /// Returns 0 and 0 if it cannot find the place.
        /// </summary>
        /// <param name="address"></param>
        /// <returns>Latitude, longitude</returns>
        public GeoCode Geocode(string address)
        {
            var parameters = new Dictionary<string, string> { { "address", address } };
            string requestUri = "geocode/json?" + BuildUri(parameters);
            try
            {
                string responseBody = _client.GetStringAsync(requestUri).Result;
                JObject json = JObject.Parse(responseBody);
                JToken token = json.SelectToken("$.results[0].geometry.location");
                GeoCode code = token.ToObject<GeoCode>();
                return code;
            }
            catch (Exception)
            {
                return new GeoCode(); // Connectivity issue, API related problem or unknown address
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

        /// <summary>
        /// Get places nearby the specified address and within the radius. Prominent places outside the radius
        /// may also be shown. Radius may not exceed the MaximumNearbyRadius. The API returns 20 results by default.
        /// Note that this method is asynchronous.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        public async Task<ICollection<Place>> GetNearbyPlaces(string address, int radius = MaximumNearbyRadius)
        {
            if (radius > MaximumNearbyRadius) throw new ArgumentOutOfRangeException();

            // Get geocode (latitude, longitude) of address
            GeoCode location = Geocode(address);

            // Invalid address
            if (location.Equals(new GeoCode())) return new List<Place>(); 

            var parameters = new Dictionary<string, string>
            {
                { "location", location.ToString() },
                { "radius", radius.ToString() }
            };
            string requestUri = "place/nearbysearch/json?" + BuildUri(parameters);
            try
            {
                string responseBody = await _client.GetStringAsync(requestUri);
                JObject json = JObject.Parse(responseBody);
                IEnumerable<JToken> tokens = json.SelectTokens("$.results[*]");
                return tokens.Select(token => token.ToObject<Place>()).ToList();
            }
            catch (Exception)
            {
                return new List<Place>(); // Connectivity issue or API related problem
            }
        }

        /// <summary>
        /// Fills every Place with a photo image URL which is actually a valid API-call.
        /// Be careful: Each time you want to show that photo you actually do the aforementioned API-call.
        /// You can quickly go over the API quota this way.
        /// </summary>
        /// <param name="places"></param>
        /// <param name="maxHeight"></param>
        /// <param name="maxWidth"></param>
        /// <returns></returns>
        public ICollection<Place> GetPhotosOfPlaces(ICollection<Place> places, int maxHeight, int maxWidth)
        {
            if (maxHeight < 0 || maxWidth < 0 || maxHeight > PhotoMaxHeight || maxWidth > PhotoMaxWidth)
            {
                throw new ArgumentOutOfRangeException();
            }

            foreach (Place place in places)
            {
                if (string.IsNullOrEmpty(place.PhotoReference)) continue;
                var parameters = new Dictionary<string, string>
                {
                    { "photoreference", place.PhotoReference },
                    { "maxheight", maxHeight.ToString() },
                    { "maxwidth", maxWidth.ToString() }
                };
                string requestUri = "place/photo?" + BuildUri(parameters);
                place.PhotoUrl = BaseAddress + requestUri;
            }

            return places;
        }
    }
}
