using System.Collections.Generic;
using System.Data.SqlClient;

namespace Travelman.Database
{
    interface IDatabase
    {
        IEnumerable<object> Query(string cmdText, params SqlParameter[] sqlParameters);
        bool NonQuery(string cmdText, params SqlParameter[] sqlParameters);
    }
}