using DomainLayer.Models.BasketModule;

namespace DomainLayer.Contracts
{
    public interface IBasketRepository
    {
        Task<CustomerBasket?> GetBasketAsync(string key);
        Task<CustomerBasket?> CreateOrUpdateBasketAsync(CustomerBasket basket, TimeSpan? TimeToLive = null);
        Task<bool> DeleteBasketAsync(string id);
        
    }
}
