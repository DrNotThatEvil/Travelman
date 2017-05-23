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
        private const string Columns = "Id, Start, Destination";
        private const string ColumnsNoId = "Start, Destination";

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
                    Destination = d.Destination,
                    Id = d.Id,
                    Start = d.Start
                });
            }

            return routes;
        }

        public bool SaveEntity(Route t)
        {
            string cmdText = $"INSERT INTO {TableName} ({ColumnsNoId}) VALUES (@Start, @Destination)";

            var start = new SqlParameter("@Start", SqlDbType.NVarChar) { Value = t.Start };
            var destination = new SqlParameter("@Destination", SqlDbType.NVarChar) {Value = t.Destination};

            return _database.NonQuery(cmdText, start, destination);
        }

        public bool DeleteEntity(Route t)
        {
            string cmdText = $"DELETE FROM {TableName} WHERE Id = @Id";

            var id = new SqlParameter("@Id", SqlDbType.Int) {Value = t.Id};

            return _database.NonQuery(cmdText, id);
        }

        public bool ModifyEntity(Route t)
        {
            string cmdText = $"UPDATE {TableName} SET Start = @Start, Destination = @Destination WHERE Id = @Id";

            var start = new SqlParameter("@Start", SqlDbType.NVarChar) {Value = t.Start};
            var destination = new SqlParameter("@Destination", SqlDbType.NVarChar) {Value = t.Destination};
            var id = new SqlParameter("@Id", SqlDbType.Int) {Value = t.Id};
            
            return _database.NonQuery(cmdText, start, destination, id);
        }
    }
}
