using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;

namespace Travelman.Database
{
    class LocalDb : IDatabase
    {
        private const string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\database.mdf;Integrated Security=True";
        private SqlConnection _connection;
        private SqlCommand _command;

        private bool PrepareCommand(string cmdText)
        {
            try
            {
                _connection = new SqlConnection(ConnectionString);
                _connection.Open();
                _command = new SqlCommand(cmdText, _connection);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void DisposeCommand()
        {
            _command.Dispose();
            _connection.Close();
            _connection.Dispose();
        }

        public IEnumerable<object> Select(string table, string columns, string where = "1=1")
        {
            string cmdText = $"SELECT {columns} FROM {table} WHERE {where};";
            var results = new List<object>();

            if (!PrepareCommand(cmdText)) return new List<object>();

            using (SqlDataReader reader = _command.ExecuteReader())
            {
                // Call Read before accessing data.
                while (reader.Read())
                {
                    var result = new ExpandoObject() as IDictionary<string, object>;
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        result.Add(reader.GetName(i), reader.GetValue(i));
                    }
                    results.Add(result);
                }
            }
            
            DisposeCommand();
            return results;
        }

        public bool Update(string table, string values, string where = "1=1")
        {
            string cmdText = $"UPDATE {table} SET {values} WHERE {where};";
            if (!PrepareCommand(cmdText)) return false;

            bool result = _command.ExecuteNonQuery() != -1;

            DisposeCommand();
            return result;
        }

        public bool Insert(string table, string columns, string values)
        {
            string cmdText = $"INSERT INTO {table} ({columns}) VALUES ({values});";
            if (!PrepareCommand(cmdText)) return false;

            bool result = _command.ExecuteNonQuery() != -1;

            DisposeCommand();
            return result;
        }

        public bool Delete(string table, string where = "1=1")
        {
            string cmdText = $"DELETE FROM {table} WHERE {where};";
            if (!PrepareCommand(cmdText)) return false;

            bool result = _command.ExecuteNonQuery() != -1;

            DisposeCommand();
            return result;
        }
    }
}
