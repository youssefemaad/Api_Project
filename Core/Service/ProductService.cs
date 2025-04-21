using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models;
using Service.Specifications;
using ServiceAbstraction;
using Shared.DataTransferObject;

namespace Service
{
    public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper) : IProductService
    {
        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            var Repo = _unitOfWork.GetRepository<ProductBrand, int>();
            var brands = await Repo.GetAllAsync();
            var brandDtos = _mapper.Map<IEnumerable<ProductBrand> ,IEnumerable<BrandDto>>(brands);
            return brandDtos;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var specification = new ProductWithBrandAndTypeSpecifications();
            var products = await _unitOfWork.GetRepository<Product, int>().GetAllAsync(specification);
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);
        }

        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeDto>>(types);
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var specification = new ProductWithBrandAndTypeSpecifications(id);
            var product = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(specification);
            return product == null ? null : _mapper.Map<Product, ProductDto>(product);
        }

    }
}
