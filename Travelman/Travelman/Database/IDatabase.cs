using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelman.Database
{
    interface IDatabase
    {
        object Select(string query);
        void Update(string query);
        void Insert(string query);
        void Delete(string query);
    }
}
