using AutoMapper;
using DomainLayer.orderModule;
using Shared.DataTransferObject.IdentityModuleDto;
using Shared.DataTransferObject.OrderDtos;

namespace Service.MappingProfile;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<AddressDto, OrderAddress>().ReverseMap();

        CreateMap<Order, OrderToReturnDto>()
            .ForMember(d => d.DeliveryMethod , opt => opt.MapFrom(s => s.DeliveryMethod.ShortName));

        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(D => D.ProductName, opt => opt.MapFrom(S => S.Product.ProductName))
            .ForMember(D => D.PictureUrl, opt => opt.MapFrom<OrderItemPictureUrlResolver>());
    }
}
