using Business.Dtos.Product;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IProductService
    {
        Product GetById(int id);
        Task<List<ProductForListingDto>> GetAll();
        Task Add(ProductForAddDto dto);
        void Update(Product product);
        void Delete(int id);
    }
}
