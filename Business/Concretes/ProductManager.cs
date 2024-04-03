using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Product;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ProductManager : IProductService
    {
        IProductRepository _productRepository;
        IMapper _mapper;

        // DI => Bu servis, servisler arasına eklendi mi?
        public ProductManager(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        // DTO => Data Transfer Object

        public async Task Add(ProductForAddDto dto)
        {
            if (dto.UnitPrice < 0)
                throw new BusinessException("Ürün fiyatı 0'dan küçük olamaz.");
            Product? productWithSameName = await _productRepository.GetAsync(p=>p.Name == dto.Name);
            if (productWithSameName is not null)
                throw new System.Exception("Aynı isimde 2. ürün eklenemez.");

            Product product = _mapper.Map<Product>(dto);
            await _productRepository.AddAsync(product);
        }

        public void Delete(int id)
        {
            Product? productToDelete = _productRepository.Get(i=> i.Id == id);
            throw new NotImplementedException();
        }

        public async Task<List<ProductForListingDto>> GetAll()
        {
            List<Product> products = await _productRepository.GetListAsync();
            List<ProductForListingDto> response = _mapper.Map<List<ProductForListingDto>>(products);
            return response;
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
