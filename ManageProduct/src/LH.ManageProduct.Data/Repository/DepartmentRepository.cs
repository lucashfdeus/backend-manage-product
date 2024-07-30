using Dapper;
using LH.ManageProduct.Api.Configurations;
using LH.ManageProduct.Business.Interfaces;
using LH.ManageProduct.Business.Models;

namespace LH.ManageProduct.Data.Repository
{
    public class DepartmentRepository : RepositoryDapper<Department>, IDepartmentRepository
    {
        private readonly DBConnection _dBConnection;

        public DepartmentRepository(DBConnection dBConnection) : base(dBConnection)
        {
            _dBConnection = dBConnection;
        }

        public async Task<Department> CreateDepartment(Department department)
        {
            var checkQuery = @"SELECT COUNT(*) 
                           FROM departments 
                           WHERE code = @Code";

            using (var connection = GetOpenConnection())
            {
                var exists = await connection.ExecuteScalarAsync<int>(checkQuery, new { Code = department.Code });
                if (exists > 0)
                {
                    return new();
                }

                var insertQuery = @"INSERT INTO departments (Id, Code, Description) 
                                VALUES (@Id, @Code, @Description)";

                await connection.ExecuteAsync(insertQuery, department);

                return department;
            }
        }

        public async Task<IEnumerable<Department>> GetAllDepartment()
        {
            var query = @"SELECT
	                        D0.id,
	                        D0.code,
	                        D0.description 
                            FROM departments D0";

            return await GetAll(query);
        }
    }
}
