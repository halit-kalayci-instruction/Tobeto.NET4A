using Core.DataAccess;
using DataAccess.Abstracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    // Her veri için 3'er seed data, ve configurasyonlar.
    // 3:05
    public class EfCategoryRepository : EfRepositoryBase<Category, BaseDbContext>, ICategoryRepository
    {
        public EfCategoryRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
