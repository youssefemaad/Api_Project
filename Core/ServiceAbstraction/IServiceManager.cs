namespace ServiceAbstraction
{
    public interface IServiceManager
    {
        public IProductService ProductService { get; }
        public IBasketService basketService { get; }
    }
}
