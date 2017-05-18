using System.Collections.Generic;

namespace Travelman.Database
{
    interface IDatabase
    {
        IEnumerable<object> Select(string table, string columns, string where = "1=1");
        bool Update(string table, string values, string where = "1=1");
        bool Insert(string table, string columns, string values);
        bool Delete(string table, string where = "1=1");
    }
}