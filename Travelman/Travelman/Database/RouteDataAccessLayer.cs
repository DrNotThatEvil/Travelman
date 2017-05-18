using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Travelman.Data;

namespace Travelman.Database
{
    class RouteDataAccessLayer : IDataAccessLayer<Route>
    {
        private readonly IDatabase _database;
        private const string Columns = "Id, Start, Destination";
        private const string ColumnsNoId = "Start, Destination";

        public RouteDataAccessLayer(IDatabase database)
        {
            _database = database;
        }

        public ICollection<Route> GetEntities()
        {
            IEnumerable<dynamic> objects = _database.Select("dbo.Route", Columns);

            List<Route> routes = new List<Route>();
            foreach (dynamic d in objects)
            {
                // Note that d is dynamic, we assume the object contains everything we need
                routes.Add(new Route
                {
                    Destination = d.Destination,
                    Id = d.Id,
                    Start = d.Start
                });
            }

            return routes;
        }

        public bool SaveEntity(Route t)
        {
            string values = $"'{t.Start}', '{t.Destination}'"; // Ensure that the order is the same as ColumnsNoId
            return _database.Insert("dbo.Route", ColumnsNoId, values);
        }

        public bool DeleteEntity(Route t)
        {
            string where = $"Id = {t.Id}";
            return _database.Delete("dbo.Route", where);
        }

        public bool ModifyEntity(Route t)
        {
            string where = $"Id = {t.Id}";
            string values = $"Start = '{t.Start}', Destination = '{t.Destination}'";
            return _database.Update("dbo.Route", values, where);
        }
    }
}
