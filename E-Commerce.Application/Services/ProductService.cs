using E_Commerce.Application.DTOs;
using E_Commerce.Domain.Models;
using E_Commerce.Domain.Repositories;

namespace E_Commerce.Application.IServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Title = p.Title,
                Price = p.Price,
                Image = p.Image
            }).ToList();
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
            {
                return null;
            }

            return new ProductDto
            {
                Id = product.Id,
                Title = product.Title,
                Price = product.Price,
                Image = product.Image
            };
        }

        public async Task AddAsync(CreateProductDto productDto)
        {
            var product = new Product
            {
                Title = productDto.Title,
                Price = productDto.Price,
                Image = productDto.Image
            };

            await _repository.AddAsync(product);
        }

        public async Task UpdateAsync(int id, UpdateProductDto productDto)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
            {
                return;
            }

            product.Title = productDto.Title;
            product.Price = productDto.Price;
            product.Image = productDto.Image;

            await _repository.UpdateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
