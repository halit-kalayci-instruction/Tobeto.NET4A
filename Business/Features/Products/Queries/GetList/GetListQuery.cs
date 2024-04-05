using Business.Features.Products.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Products.Queries.GetList
{
    public class GetListQuery : IRequest<ListProductResponse>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }


        public class GetListQueryHandler : IRequestHandler<GetListQuery, ListProductResponse>
        {
            public Task<ListProductResponse> Handle(GetListQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
// 2:45 -> 