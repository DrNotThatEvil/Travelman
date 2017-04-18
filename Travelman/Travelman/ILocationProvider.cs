using System.Collections.Generic;
using System.Threading.Tasks;

namespace Travelman
{
    interface ILocationProvider
    {
        /// <summary>
        /// Get a list of autocompletion suggestions from the specified query string.
        /// Asynchronous method call.
        /// </summary>
        /// <param name="query">The query to autocomplete</param>
        /// <returns>A list of autocompletion suggestions</returns>
        Task<List<string>> GetAutocompleteList(string query);

        /// <summary>
        /// Validates the current location query string.
        /// </summary>
        /// <param name="query">The query to be validated</param>
        /// <returns>Validity of location query</returns>
        bool LocationIsValid(string query);
    }
}
