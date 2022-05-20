using AutoMapper;
using CentiroHomeAssignment.Shared.Models;
using CentiroHomeAssignment.Shared.RequestModels;
using CentiroHomeAssignment.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentiroHomeAssignment.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            // Mapping for Order
            CreateMap<Order, OrderResponse>().ReverseMap();
            CreateMap<OrderRequest, Order>().ReverseMap();
            CreateMap<OrderRequest, OrderResponse>().ReverseMap();
        }
    }
}
