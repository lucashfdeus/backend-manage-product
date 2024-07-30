using LH.ManageProduct.Business.Models;

namespace LH.ManageProduct.Business.Interfaces
{
    public interface IProductRepository : IRepositoryDapper<Product>
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(Guid id);
        Task<bool> CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(Guid id);
    }
}
