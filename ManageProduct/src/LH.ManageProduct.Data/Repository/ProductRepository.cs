using LH.ManageProduct.Api.Configurations;
using LH.ManageProduct.Business.Interfaces;
using LH.ManageProduct.Business.Models;

namespace LH.ManageProduct.Data.Repository
{
    public class ProductRepository : RepositoryDapper<Product>, IProductRepository
    {
        public ProductRepository(DBConnection dBConnection) : base(dBConnection) { }

        // Dapper-based methods using Dapper.Contrib
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var query = @"SELECT 
                            P0.id,
                            P0.description,
                            P0.departmentcode,
                            P0.price,
                            P0.status 
                          FROM products P0
                          ORDER BY P0.departmentcode ";

            return await GetAll(query);
        }

        public async Task<Product> GetProductById(Guid id)
        {
            var query = @"SELECT
                            P0.id,
                            P0.description,
                            P0.departmentcode,
                            P0.price,
                            P0.status 
                          FROM Products P0 WHERE P0.Id = @Id";
            return await GetById(query, new { Id = id });
        }

        public async Task<bool> CreateProduct(Product product)
        {
            var sql = @"INSERT INTO products (id, description, departmentcode, price, status) 
                        VALUES (@Id, @Description, @DepartmentCode, @Price, @Status)";

            var parameters = new
            {
                Id = product.Id,
                Description = product.Description,
                DepartmentCode = product.DepartmentCode,
                Price = product.Price,
                Status = product.Status
            };

            return await Create(sql, parameters) > 0;
        }


        public async Task<bool> UpdateProduct(Product product)
        {
            var sql = @"UPDATE products 
                        SET description = @Description, 
                        departmentcode = @DepartmentCode, 
                        price = @Price, 
                        status = @Status 
                        WHERE id = @Id";

            var parameters = new
            {
                Id = product.Id,
                Description = product.Description,
                DepartmentCode = product.DepartmentCode,
                Price = product.Price,
                Status = product.Status
            };
            return await Update(sql, parameters) > 0;
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            var query = "UPDATE Products SET Status = false WHERE Id = @Id";
            return await Delete(query, new { Id = id }) > 0;
        }
    }
}