using Shared.DataTransferObject.BasketModuleDto;

namespace ServiceAbstraction
{
    public interface IBasketService
    {
        Task<BasketDto> GetBasketAsync(string key);
        Task<BasketDto> CreateOrUpdateAsync(BasketDto basket);
        Task<bool> DeleteBasketAsync(string key);
    }
}
