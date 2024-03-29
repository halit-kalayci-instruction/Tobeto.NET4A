using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    // Constraints => Kısıt
    public class EfRepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TContext : DbContext
        where TEntity : Entity
    {
        private readonly TContext Context;

        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }

        public void Add(TEntity entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            Context.Update(entity);
            Context.SaveChanges();
        }

        // Filter ✅
        // OrderBy ?
        public List<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate)
        {
            IQueryable<TEntity> data = Context.Set<TEntity>();

            if(predicate != null)
                data = data.Where(predicate);

            return data.ToList();
        }

        // Filter ✅
        // OrderBy ?
        public TEntity? Get(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> data = Context.Set<TEntity>();

            return data.FirstOrDefault(predicate);
        }
    }
}
