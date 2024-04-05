using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Products.Queries.GetById
{
    public class GetByIdQuery : IRequest<GetByIdProductResponse>
    {
        public int Id { get; set; }


        public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GetByIdProductResponse>
        {
            private IMapper _mapper;
            private IProductRepository _productRepository;

            public GetByIdQueryHandler(IMapper mapper, IProductRepository productRepository)
            {
                _mapper = mapper;
                _productRepository = productRepository;
            }

            public async Task<GetByIdProductResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                Product? product = await _productRepository.GetAsync(p => p.Id == request.Id);

                if (product is null)
                    throw new BusinessException("Böyle bir veri bulunamadı.");

                GetByIdProductResponse response = _mapper.Map<GetByIdProductResponse>(product);

                return response;
            }
        }
    }
}
