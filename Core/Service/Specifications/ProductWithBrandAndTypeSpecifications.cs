using DomainLayer.Models;

namespace Service.Specifications
{
    class ProductWithBrandAndTypeSpecifications : BaseSpecification<Product, int>
    {
        public ProductWithBrandAndTypeSpecifications(): base(null)
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
