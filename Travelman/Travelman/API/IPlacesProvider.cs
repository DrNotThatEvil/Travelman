using System.Collections.Generic;
using System.Threading.Tasks;

namespace Travelman
{
    public interface IPlacesProvider
    {
        /// <summary>
        /// Get a list of interesting places near the specified address. 
        /// Search area may be specified with the radius parameter.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="radius">Radius in meters</param>
        /// <returns></returns>
        Task<ICollection<Place>> GetNearbyPlaces(string address, int radius);

        /// <summary>
        /// Fills every Place with a photo image URL which is actually a valid API-call.
        /// Be careful: Each time you want to show that photo you actually do the aforementioned API-call.
        /// You can quickly go over the API quota this way.
        /// </summary>
        /// <param name="places"></param>
        /// <param name="maxHeight"></param>
        /// <param name="maxWidth"></param>
        /// <returns></returns>
        ICollection<Place> GetPhotosOfPlaces(ICollection<Place> places, int maxHeight, int maxWidth);
    }
}