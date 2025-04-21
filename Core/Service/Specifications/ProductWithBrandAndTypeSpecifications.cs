using DomainLayer.Models;
using Shared;

namespace Service.Specifications
{
    class ProductWithBrandAndTypeSpecifications : BaseSpecification<Product, int>
    {
        public ProductWithBrandAndTypeSpecifications(int? brandId, int? typeId, ProductSortingOptions? sortingOptions) :
                    base(P =>(!brandId.HasValue || P.BrandId == brandId) && (!typeId.HasValue || P.TypeId == typeId))
        {
            AddInclude(n => n.ProductBrand);
            AddInclude(n => n.ProductType);

            switch (sortingOptions)
            {
                case ProductSortingOptions.PriceAsc:
                    AddOrderBy(n => n.Price);
                    break;
                case ProductSortingOptions.PriceDesc:
                    AddOrderByDescending(n => n.Price);
                    break;
                case ProductSortingOptions.NameAsc:
                    AddOrderBy(n => n.Name);
                    break;
                case ProductSortingOptions.NameDesc:
                    AddOrderByDescending(n => n.Name);
                    break;
                default:
                    AddOrderBy(n => n.Id);
                    break;
            }
        }

        public ProductWithBrandAndTypeSpecifications(int id) : base(n => n.Id == id)
        {
            AddInclude(n => n.ProductBrand);
            AddInclude(n => n.ProductType);
        }
    }
}
