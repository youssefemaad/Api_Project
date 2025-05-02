using AutoMapper;
using DomainLayer.Models.IdentityModule;
using Shared.DataTransferObject.IdentityModuleDto;

namespace Service.MappingProfile
{
    public class AuthenticationProfile : Profile
    {
        public AuthenticationProfile()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
