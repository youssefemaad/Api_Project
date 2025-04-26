using AutoMapper;
using DomainLayer.Models.BasketModule;
using Shared.DataTransferObject.BasketModuleDto;

namespace Service.MappingProfile;

public class BasketProfile: Profile
{
    public BasketProfile()
    {
        CreateMap<CustomerBasket , BasketDto>().ReverseMap();
        CreateMap<BasketItem , BasketItemDto>().ReverseMap();
    }
}
