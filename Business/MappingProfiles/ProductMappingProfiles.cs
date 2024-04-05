using AutoMapper;
using Business.Features.Products.Commands.Create;
using Entities;

namespace Business.MappingProfiles
{
    public class ProductMappingProfiles : Profile
    {
        public ProductMappingProfiles()
        {
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            //.ForMember(i=>i.UnitPrice, opt => opt.MapFrom(dto => dto.Price));
        }
    }
}
