using System;
using System.Linq;
namespace Tendy.DAL.Abstract
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Func<T, bool> predicate);
        T FindSingle(int id);
        T Create(T item);
        T Update(T item);
        void Delete(int id);
        void Delete(T entity);
    }
}
