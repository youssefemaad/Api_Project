using Shared;
using Shared.DataTransferObject;

namespace ServiceAbstraction
{
    public interface IProductService
    {
        Task<PaginationResult<ProductDto>> GetAllProductsAsync(ProductQueryParams queryParams);
        Task<ProductDto?> GetProductByIdAsync(int id);
        Task<IEnumerable<BrandDto>> GetAllBrandsAsync();
        Task<IEnumerable<TypeDto>> GetAllTypesAsync();
    }
}