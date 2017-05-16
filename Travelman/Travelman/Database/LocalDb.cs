using System;
using System.Data;
using System.Data.SqlClient;

namespace Travelman.Database
{
    class LocalDb : IDatabase
    {
        private const string ConnectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private SqlConnection _connection;
        private SqlDataReader _reader;

        public LocalDb()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM Customers";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;

            _connection.Open();

            reader = cmd.ExecuteReader();

            _connection.Close();
        }

        public void Delete(string query)
        {
            throw new NotImplementedException();
        }

        public void Insert(string query)
        {
            throw new NotImplementedException();
        }

        public object Select(string query)
        {
            _connection.Open();

            _connection.Close();

            throw new NotImplementedException();
        }

        public void Update(string query)
        {
            throw new NotImplementedException();
        }
    }
}
