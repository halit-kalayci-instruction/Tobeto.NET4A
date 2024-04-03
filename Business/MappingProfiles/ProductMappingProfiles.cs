using AutoMapper;
using Business.Dtos.Product;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.MappingProfiles
{
    public class ProductMappingProfiles : Profile
    {
        public ProductMappingProfiles()
        {
            CreateMap<Product, ProductForAddDto>().ReverseMap();
            //.ForMember(i=>i.UnitPrice, opt => opt.MapFrom(dto => dto.Price));
            CreateMap<Product, ProductForListingDto>().ReverseMap();
        }
    }
}
