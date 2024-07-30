using LH.ManageProduct.Business.Models;

namespace LH.ManageProduct.Business.Interfaces
{
    public interface IProductService : IDisposable
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(Guid id);
        Task CreateProduct(Product product);
        Task UpdateProduct(Product product);
        Task<bool> DeleteProduct(Guid id);
    }
}
