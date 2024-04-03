using Business.Dtos.Product.Requests;
using Business.Dtos.Product.Responses;
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
        Task<List<ListProductResponse>> GetAll();
        Task Add(AddProductRequest dto);
        void Update(Product product);
        void Delete(int id);
    }
}
// Servisler arası iletişim
// CQRS
// Mediator pattern (MediatR)