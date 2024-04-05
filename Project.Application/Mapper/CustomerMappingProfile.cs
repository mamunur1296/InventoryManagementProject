using AutoMapper;
using Project.Application.CustomerFeatures.Commands;
using Project.Application.DTOs;
using Project.Application.Models;
using Project.Domain.Entities;

namespace Project.Application.Mapper
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile() 
        {
            CreateMap<Customer, CustomerModel>().ReverseMap();
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}
