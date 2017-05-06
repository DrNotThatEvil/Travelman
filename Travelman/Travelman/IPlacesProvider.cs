using System.Collections.Generic;
using System.Threading.Tasks;

namespace Travelman
{
    interface IPlacesProvider
    {
        /// <summary>
        /// Get a list of interesting places near the specified address. 
        /// Search area may be specified with the radius parameter.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="radius">Radius in meters</param>
        /// <returns></returns>
        Task<ICollection<Place>> GetNearbyPlaces(string address, int radius);
    }
}
