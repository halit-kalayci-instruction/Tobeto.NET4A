using DataAccess.Abstracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.InMemory
{
    public class InMemoryProductRepository : IProductRepository
    {
        List<Product> products;

        public InMemoryProductRepository()
        {
            products = new List<Product>();
        }

        public void Add(Product product)
        {
            products.Add(product);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return products;
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
