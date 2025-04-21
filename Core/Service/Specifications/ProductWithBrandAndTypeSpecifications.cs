using DomainLayer.Models;

namespace Service.Specifications
{
    class ProductWithBrandAndTypeSpecifications : BaseSpecification<Product, int>
    {
        public ProductWithBrandAndTypeSpecifications(int? brandId, int? typeId): 
                    base(P =>(!brandId.HasValue || P.BrandId == brandId) && (!typeId.HasValue || P.TypeId == typeId))
        {
            AddInclude(n => n.ProductBrand);
            AddInclude(n => n.ProductType);
        }

        public ProductWithBrandAndTypeSpecifications(int id) : base(n => n.Id == id)
        {
            AddInclude(n => n.ProductBrand);
            AddInclude(n => n.ProductType);
        }
    }
}
