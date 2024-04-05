using AutoMapper;
using Business.Abstracts;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Products.Commands.Create
{
    public class CreateProductCommand : IRequest
    {
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }


        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;


            public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                if (request.UnitPrice < 0)
                    throw new BusinessException("Ürün fiyatı 0'dan küçük olamaz.");
                Product? productWithSameName = await _productRepository.GetAsync(p => p.Name == request.Name);
                if (productWithSameName is not null)
                    throw new System.Exception("Aynı isimde 2. ürün eklenemez.");
                // Kategori verilerine ulaş..
                //Category? category = _categoryService.GetById(request.CategoryId);
                //if (category is null)
                //    throw new BusinessException("Böyle bir kategori bulunamadı.");

                Product product = _mapper.Map<Product>(request);
                await _productRepository.AddAsync(product);
            }
        }
    }
}
