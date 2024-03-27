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
    public class EfCategoryRepository : ICategoryRepository
    {
        public void Add(Category category)
        {
            using (BaseDbContext context = new())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }

        public void Delete(Category category)
        {
            using (BaseDbContext context = new())
            {
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }

        public List<Category> GetAll()
        {
            using (BaseDbContext context = new())
            {
                return context.Categories.ToList();
            }
        }

        public Category GetById(int id)
        {
            using (BaseDbContext context = new())
            {
                return context.Categories.FirstOrDefault(p => p.Id == id);
            }
        }

        public void Update(Category category)
        {
            using (BaseDbContext context = new())
            {
                context.Categories.Update(category);
                context.SaveChanges();
            }
        }
    }
}
