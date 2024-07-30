using LH.ManageProduct.Business.Interfaces;
using LH.ManageProduct.Business.Models;
using LH.ManageProduct.Business.Models.Validations;

namespace LH.ManageProduct.Business.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IDapperUnitOfWork _dapperUnitOfWork;

        public ProductService(INotification notification, IProductRepository productRepository, IDapperUnitOfWork dapperUnitOfWork)
            : base(notification, dapperUnitOfWork)
        {
            _productRepository = productRepository;
            _dapperUnitOfWork = dapperUnitOfWork;
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }

        public async Task<Product> GetProductById(Guid id)
        {
            return await _productRepository.GetProductById(id);
        }

        public async Task CreateProduct(Product product)
        {
            if (!ExecuteValidation(new ProductValidation(), product)) return;

            var existingProduct = await _productRepository.GetProductById(product.Id);

            if (existingProduct is not null)
            {
                Notify("There is already a product with the specified ID!");
                return;
            }

            await _productRepository.CreateProduct(product);

            await Commit();
        }

        public async Task UpdateProduct(Product product)
        {
            if (!ExecuteValidation(new ProductValidation(), product)) return;

            var productUpdate = await _productRepository.GetProductById(product.Id);


            if (productUpdate is null)
            {
                Notify("Product not found.");
                return;
            }

            productUpdate.Description = product.Description;
            productUpdate.DepartmentCode = product.DepartmentCode;
            productUpdate.Price = product.Price;
            productUpdate.Status = product.Status;

            await _productRepository.UpdateProduct(productUpdate);

            await Commit();
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            await _productRepository.DeleteProduct(id);
            await Commit();
            return true;
        }

        public void Dispose()
        {
            _productRepository.Dispose();
        }
    }
}