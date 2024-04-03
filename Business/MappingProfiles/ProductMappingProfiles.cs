using AutoMapper;
using Business.Dtos.Product.Requests;
using Business.Dtos.Product.Responses;
using Entities;

namespace Business.MappingProfiles
{
    public class ProductMappingProfiles : Profile
    {
        public ProductMappingProfiles()
        {
            CreateMap<Product, AddProductRequest>().ReverseMap();
            //.ForMember(i=>i.UnitPrice, opt => opt.MapFrom(dto => dto.Price));
            CreateMap<Product, ListProductResponse>().ReverseMap();
        }
    }
}
