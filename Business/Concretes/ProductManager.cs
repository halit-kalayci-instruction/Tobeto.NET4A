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
            // ürün ismini kontrol et
            // fiyatını kontrol et

            if (dto.UnitPrice < 0)
                throw new BusinessException("Ürün fiyatı 0'dan küçük olamaz.");

            // Aynı isimde 2. ürün eklenemez.

            Product? productWithSameName = await _productRepository.GetAsync(p=>p.Name == dto.Name);
            if (productWithSameName is not null)
                throw new System.Exception("Aynı isimde 2. ürün eklenemez.");

            // Async işlemler ✅
            // Global Ex. Handling.
            // İş kuralları, Validaton => Daha temiz yazarız?
            // Pipeline Mediator pattern ??

            // Mapping (Manual)
            // AutoMapping
            /* Product product = new();
            product.Name = dto.Name;
            product.Stock = dto.Stock;
            product.UnitPrice = dto.UnitPrice;
            product.CategoryId = dto.CategoryId;
            product.CreatedDate = DateTime.Now; 
            */

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
            // Cacheleme?
            List<Product> products = await _productRepository.GetListAsync();
            //List<ProductForListingDto> response = new List<ProductForListingDto>();

            //foreach (Product product in products)
            //{
            //    ProductForListingDto dto = new();
            //    dto.Name = product.Name;
            //    dto.UnitPrice = product.UnitPrice;
            //    dto.Id = product.Id;
            //    response.Add(dto);  
            //}
            
            // Manual Mapping
            // AutoMapping
            List<ProductForListingDto> response = products.Select(p => new ProductForListingDto()
            {
                Id=p.Id,
                Name=p.Name,
                UnitPrice=p.UnitPrice,
            }).ToList();

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
