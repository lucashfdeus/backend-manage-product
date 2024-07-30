using Dapper;
using LH.ManageProduct.Api.Configurations;
using LH.ManageProduct.Business.Interfaces;
using LH.ManageProduct.Business.Models;
using Npgsql;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LH.ManageProduct.Data.Repository
{
    public abstract class RepositoryDapper<TEntity> : IRepositoryDapper<TEntity> where TEntity : Entity, new()
    {
        private readonly DBConnection _dbConnection;

        protected RepositoryDapper(DBConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        protected NpgsqlConnection GetOpenConnection()
        {
            return _dbConnection.OpenConnection();
        }

        public async Task<IEnumerable<TEntity>> GetAll(string sql, object parameters = null)
        {
            using (var connection = GetOpenConnection())
            {
                return await connection.QueryAsync<TEntity>(sql, parameters);
            }
        }

        public async Task<TEntity> GetById(string sql, object parameters)
        {
            using (var connection = GetOpenConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<TEntity>(sql, parameters);
            }
        }

        public async Task<int> Create(string sql, object parameters)
        {          
            using (var connection = GetOpenConnection())
            {
                return await connection.ExecuteAsync(sql, parameters);
            }
        }

        public async Task<int> Update(string sql, object parameters)
        {           
            using (var connection = GetOpenConnection())
            {
                return await connection.ExecuteAsync(sql, parameters);
            }
        }

        public async Task<int> Delete(string sql, object parameters)
        {
            using (var connection = GetOpenConnection())
            {
                return await connection.ExecuteAsync(sql, parameters);
            }
        }

        public void Dispose()
        {            
            using (var connection = GetOpenConnection())
            {
                connection?.Dispose();
            }
        }
    }
}
