using E_Commerce.Application.DTOs;

namespace E_Commerce.Application.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(int id);
        Task AddAsync(CreateProductDto productDto);
        Task UpdateAsync(int id, UpdateProductDto productDto);
        Task DeleteAsync(int id);
    }
}
