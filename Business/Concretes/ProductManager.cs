using Business.Abstracts;
using DataAccess.Abstracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ProductManager : IProductService
    {
        IProductRepository _productRepository;

        // DI => Bu servis, servisler arasına eklendi mi?
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Add(Product product)
        {
            // ürün ismini kontrol et
            // fiyatını kontrol et

            if (product.UnitPrice < 0)
                throw new Exception("Ürün fiyatı 0'dan küçük olamaz.");

            // Aynı isimde 2. ürün eklenemez.

            Product? productWithSameName = _productRepository.Get(p=>p.Name == product.Name);
            if (productWithSameName is not null)
                throw new Exception("Aynı isimde 2. ürün eklenemez.");

            // İş kuralları, Validaton => Daha temiz yazarız?
            // Global Ex. Handling.
            // Pipeline Mediator pattern ??

            _productRepository.Add(product);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            // Cacheleme?
            return _productRepository.GetAll();
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
