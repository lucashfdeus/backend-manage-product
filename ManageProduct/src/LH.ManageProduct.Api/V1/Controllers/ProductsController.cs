using AutoMapper;
using LH.ManageProduct.Api.Controllers;
using LH.ManageProduct.Api.ViewModels;
using LH.ManageProduct.Business.Interfaces;
using LH.ManageProduct.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LH.ManageProduct.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/products")]

    public class ProductsController : MainController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(INotification notification, IProductService productService, IMapper mapper, IUser user) : base(notification, user)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(await _productService.GetAllProducts());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProductViewModel>> GetById(Guid id)
        {
            var produtoViewModel = _mapper.Map<ProductViewModel>(await _productService.GetProductById(id));

            if (produtoViewModel == null) return NotFound();

            return produtoViewModel;
        }

        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> Create(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _productService.CreateProduct(_mapper.Map<Product>(productViewModel));

            return CustomResponse(productViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, ProductViewModel productViewModel)
        {
            if (id != productViewModel.Id)
            {
                NotifyError("The IDs entered do not match!");
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _productService.UpdateProduct(_mapper.Map<Product>(productViewModel));

            return CustomResponse(HttpStatusCode.NoContent);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var product = await _productService.GetProductById(id);

            if (product is null)
            {
                NotifyError("No product found with the specified ID.");
                return NotFound();
            }

            if (product.Status == false)
            {
                NotifyError("The product with the specified ID is already inactive.");
                return CustomResponse(product);
            }

            await _productService.DeleteProduct(product.Id);
            return CustomResponse("Product deleted successfully.");
        }
    }
}
