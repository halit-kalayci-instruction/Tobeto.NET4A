using AutoMapper;
using Business.Features.Products.Commands.Create;
using Business.Features.Products.Commands.Update;
using Business.Features.Products.Queries.GetById;
using Business.Features.Products.Queries.GetList;
using Entities;

namespace Business.Features.Products.Profiles
{
    public class ProductMappingProfiles : Profile
    {
        public ProductMappingProfiles()
        {
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, GetAllProductResponse>().ReverseMap();
            CreateMap<Product, GetByIdProductResponse>().ReverseMap();
            CreateMap<Product, UpdateProductResponse>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            //.ForMember(i=>i.UnitPrice, opt => opt.MapFrom(dto => dto.Price));
        }
    }
}
