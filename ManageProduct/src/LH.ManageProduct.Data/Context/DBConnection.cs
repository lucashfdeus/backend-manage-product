using Microsoft.Extensions.Configuration;
using Npgsql;

namespace LH.ManageProduct.Api.Configurations
{
    public class DBConnection
    {
        private readonly IConfiguration _configuration;

        public DBConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public NpgsqlConnection OpenConnection()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            var cnn = new NpgsqlConnection(connectionString);
            cnn.Open();
            return cnn; 
        }
    }
}
