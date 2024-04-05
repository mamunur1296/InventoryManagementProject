using AutoMapper;
using Project.Application.DTOs;
using Project.Application.Features.CustomerFeatures.Commands;
using Project.Domain.Entities;

namespace Project.Application.Mapper
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile() 
        {
            
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}
