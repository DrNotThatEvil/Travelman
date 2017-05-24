using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Travelman.Data;

namespace Travelman.Database
{
    class RouteDataAccessLayer : IDataAccessLayer<Route>
    {
        private readonly IDatabase _database;
        private const string TableName = "Route";
        private const string Columns = "Id, Name, Start, Destination";
        private const string ColumnsNoId = "Name, Start, Destination";

        public RouteDataAccessLayer(IDatabase database)
        {
            _database = database;
        }

        public ICollection<Route> GetEntities()
        {
            string cmdText = $"SELECT {Columns} FROM {TableName}";

            IEnumerable<dynamic> objects = _database.Query(cmdText);

            List<Route> routes = new List<Route>();
            foreach (dynamic d in objects)
            {
                // Note that d is dynamic, we assume the object contains everything we need
                routes.Add(new Route
                {
                    Id = d.Id,
                    Name = d.Name,
                    Start = d.Start,
                    Destination = d.Destination
                });
            }

            return routes;
        }

        public bool SaveEntity(Route route)
        {
            string cmdText = $"INSERT INTO {TableName} ({ColumnsNoId}) VALUES (@Name, @Start, @Destination)";

            var name = new SqlParameter("@Name", SqlDbType.NVarChar) { Value = route.Name };
            var start = new SqlParameter("@Start", SqlDbType.NVarChar) { Value = route.Start };
            var destination = new SqlParameter("@Destination", SqlDbType.NVarChar) {Value = route.Destination};

            return _database.NonQuery(cmdText, name, start, destination);
        }

        public bool DeleteEntity(Route route)
        {
            string cmdText = $"DELETE FROM {TableName} WHERE Id = @Id";

            var id = new SqlParameter("@Id", SqlDbType.Int) {Value = route.Id};

            return _database.NonQuery(cmdText, id);
        }

        public bool ModifyEntity(Route route)
        {
            string cmdText = $"UPDATE {TableName} SET Start = @Start, Destination = @Destination WHERE Id = @Id";

            var name = new SqlParameter("@Name", SqlDbType.NVarChar) { Value = route.Name };
            var start = new SqlParameter("@Start", SqlDbType.NVarChar) {Value = route.Start};
            var destination = new SqlParameter("@Destination", SqlDbType.NVarChar) {Value = route.Destination};
            var id = new SqlParameter("@Id", SqlDbType.Int) {Value = route.Id};
            
            return _database.NonQuery(cmdText, name, start, destination, id);
        }
    }
}
