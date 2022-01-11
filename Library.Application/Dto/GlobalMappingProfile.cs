using AutoMapper;
using Library.Core.Entities;

namespace Library.Application.Dto;

public class GlobalMappingProfile : Profile
{
    public GlobalMappingProfile()
    {
        CreateMap<AddressDto, Address>();
        CreateMap<Address, AddressDto>();
    }
}