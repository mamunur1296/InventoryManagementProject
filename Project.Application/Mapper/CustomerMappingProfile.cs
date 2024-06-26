﻿using AutoMapper;
using Project.Application.DTOs;
using Project.Domain.Entities;

namespace Project.Application.Mapper
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile() 
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}
