using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelman.Data;

namespace Travelman.Database
{
    class RouteDataAccessLayer : IDataAccessLayer<Route>
    {
        public ICollection<Route> GetEntities()
        {
            throw new NotImplementedException();
        }

        public bool SaveEntity(Route t)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEntity(Route t)
        {
            throw new NotImplementedException();
        }

        public bool ModifyEntity(Route t)
        {
            throw new NotImplementedException();
        }
    }
}
