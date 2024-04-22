using Core.DataAccess;
using DataAccess.Abstracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfProductRepository : EfRepositoryBase<Product, BaseDbContext>, IProductRepository
    {
        public EfProductRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
