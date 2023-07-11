using APIImplementation.Models.Entities;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APIImplementation.Repositories
{
    public class BaseRepository<T> where T : class
    {
        private readonly string _connectionString;

        public BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public T Get(string query, object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<T>(query, parameters);
        }
        public IEnumerable<T> GetAll(string query, object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<T>(query,parameters);
        }
        
    }
}
