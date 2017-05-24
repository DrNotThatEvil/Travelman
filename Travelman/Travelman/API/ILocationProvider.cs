using System.Collections.Generic;
using System.Threading.Tasks;
using Travelman.Data;

namespace Travelman.API
{
    public interface ILocationProvider
    {
        /// <summary>
        /// Get a list of autocompletion suggestions from the specified query string.
        /// Asynchronous operation.
        /// </summary>
        /// <param name="query">The query to autocomplete</param>
        /// <returns>A list of autocompletion suggestions</returns>
        Task<List<string>> GetAutocompleteList(string query);

        /// <summary>
        /// Validates the current locations by checking if they exist and that there is a 
        /// possible route between them.
        /// </summary>
        /// <param name="start">Starting location query</param>
        /// <param name="destination">Destination query</param>
        /// <returns>Validity of location query</returns>
        bool RouteIsPossible(string start, string destination);

        /// <summary>
        /// Get the latitude and longitude of the specified query string.
        /// Returns 0 and 0 if it cannot find the place.
        /// </summary>
        /// <param name="address"></param>
        /// <returns>Latitude, longitude</returns>
        GeoCode Geocode(string address);

        /// <summary>
        /// Fills the route objects with an URL leading to an image previewing the route.
        /// </summary>
        /// <returns></returns>
        List<Route> GetPreviewImageOfRoutes(List<Route> routes, int width, int height);
    }
}