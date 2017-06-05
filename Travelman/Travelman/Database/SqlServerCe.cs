using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Dynamic;
using System.IO;

namespace Travelman.Database
{
    class SqlServerCe : IDatabase
    {
        private const string ConnectionString = "Data Source=|DataDirectory|\\database.sdf";
        private const string CreationSql = "SqlServerCe.sql";
        private SqlCeConnection _connection;
        private SqlCeCommand _command;

        private void CreateDatabase()
        {
            try
            {
                new SqlCeEngine(ConnectionString).CreateDatabase();

                _connection = new SqlCeConnection(ConnectionString);
                _connection.Open();

                SqlCeCommand cmd = _connection.CreateCommand();
                cmd.CommandText = File.ReadAllText(CreationSql);
                cmd.ExecuteNonQuery();
            }
            catch (Exception) { } // Here would be a good place to implement logging
            finally { _connection.Close(); }
        }

        /// <summary>
        /// Safely prepares a parameterized command. Must be used before executing a (non)query.
        /// </summary>
        /// <param name="cmdText">A (parameterized) SQL command</param>
        /// <param name="sqlParameters">Optional parameters to be filled</param>
        /// <returns></returns>
        private bool PrepareCommand(string cmdText, params SqlParameter[] sqlParameters)
        {
            try
            {
                if (!File.Exists("database.sdf")) CreateDatabase();
                _connection = new SqlCeConnection(ConnectionString);
                _connection.Open();
                _command = new SqlCeCommand(cmdText, _connection);
                foreach (var param in sqlParameters)
                {
                    _command.Parameters.Add(ConvertParamToCe(param));
                }
                _command.Prepare();
                return true;
            }
            catch (Exception)
            {
                // Here would be a good place to implement logging
                return false;
            }
        }

        private void DisposeCommand()
        {
            _command.Dispose();
            _connection.Close();
            _connection.Dispose();
        }

        /// <summary>
        /// Used to execute a SELECT operation. Returns a collection of objects.
        /// </summary>
        /// <param name="cmdText">A (parameterized) SQL command</param>
        /// <param name="sqlParameters">Optional parameters to be filled</param>
        /// <returns></returns>
        public IEnumerable<object> Query(string cmdText, params SqlParameter[] sqlParameters)
        {
            if (!PrepareCommand(cmdText, sqlParameters)) return new List<object>();

            var results = new List<object>();
            using (SqlCeDataReader reader = _command.ExecuteReader())
            {
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

        /// <summary>
        /// Used to execute an operation like a UPDATE, DELETE and INSERT.
        /// Returns true if successful.
        /// </summary>
        /// <param name="cmdText">A (parameterized) SQL command</param>
        /// <param name="sqlParameters">Optional parameters to be filled</param>
        /// <returns></returns>
        public bool NonQuery(string cmdText, params SqlParameter[] sqlParameters)
        {
            if (!PrepareCommand(cmdText, sqlParameters)) return false;

            bool result = _command.ExecuteNonQuery() != -1;

            DisposeCommand();
            return result;
        }

        /// <summary>
        /// Used to convert a more generic SqlParameter to a CE-specific SqlCeParameter.
        /// </summary>
        /// <param name="sqlParameter"></param>
        /// <returns></returns>
        private static SqlCeParameter ConvertParamToCe(SqlParameter sqlParameter)
        {
            return new SqlCeParameter
            { 
                DbType = sqlParameter.DbType,
                ParameterName = sqlParameter.ParameterName,
                Direction = sqlParameter.Direction,
                IsNullable = sqlParameter.IsNullable,
                Offset = sqlParameter.Offset,
                Precision = sqlParameter.Precision,
                Scale = sqlParameter.Scale,
                Size = sqlParameter.Size,
                SourceColumn = sqlParameter.SourceColumn,
                SourceColumnNullMapping = sqlParameter.SourceColumnNullMapping,
                SqlDbType = sqlParameter.SqlDbType,
                SourceVersion = sqlParameter.SourceVersion,
                Value = sqlParameter.Value
            };
        }
    }
}
