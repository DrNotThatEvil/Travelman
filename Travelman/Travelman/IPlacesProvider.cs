using System.Collections.Generic;

namespace Travelman
{
    interface IPlacesProvider
    {
        ICollection<Place> GetNearbyPlaces(string address);
    }
}
