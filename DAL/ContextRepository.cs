using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public sealed class ContextRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DataContext Context;
        private readonly DbSet<TEntity> dataset;

        public ContextRepository(DataContext context)
        {
            Context = context;
            dataset = context.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            using (DataContext db = new DataContext())
            {
                dataset.Add(item);
            }
        }

        public TEntity FindById(int id)
        {
            return dataset.Find(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return dataset.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return dataset.AsNoTracking().Where(predicate).ToList();
        }

        public TEntity GetOne(Func<TEntity, bool> predicate)
        {
            return dataset.AsNoTracking().Where(predicate).FirstOrDefault();
        }

        public void Remove(TEntity item)
        {
            try
            {
                dataset.Remove(item);
            }
            catch (ArgumentNullException)
            {

            }
        }

        public void Update(TEntity item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }


    }
}
