using AutoMapper;
using DomainLayer.orderModule;
using Microsoft.Extensions.Configuration;
using Shared.DataTransferObject.OrderDtos;

namespace Service.MappingProfile;

public class OrderItemPictureUrlResolver : IValueResolver<OrderItem, OrderItemDto, string>
{
    private readonly IConfiguration _configuration;
    public OrderItemPictureUrlResolver(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
    {
        if (string.IsNullOrEmpty(source.Product.PictureUrl))
        {
            return string.Empty;
        }
        else
        {
            var Url = $"{context.Items["BaseUrl"]}{source.Product.PictureUrl}";
            return Url;
        }
    }
    
}
