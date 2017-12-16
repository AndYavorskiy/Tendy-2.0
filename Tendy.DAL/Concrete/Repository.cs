using Tendy.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using Tendy.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Tendy.DAL.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }


        public IQueryable<T> FindBy(Func<T, bool> predicate)
        {
            return _dbSet.Where(predicate).AsQueryable();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null,
                                            Func<IQueryable<T>, IOrderedEnumerable<T>> orderBy = null,
                                            string includeProperties = "")
        {
            IQueryable<T> query = _dbSet.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (string includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }

            return query.ToList();
        }

        public virtual T FindSingle(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual T Create(T item)
        {
            _dbSet.Add(item);
            return item;
        }

        public virtual T Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return item;
        }

        public virtual void Delete(int id)
        {
            T entity = FindSingle(id);
            _dbSet.Remove(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
