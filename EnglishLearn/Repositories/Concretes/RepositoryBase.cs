using System.Linq.Expressions;
using EnglishLearn.Contexts;
using EnglishLearn.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace EnglishLearn.Repositories.Concretes
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationContext _context;

        public RepositoryBase(ApplicationContext context)
        {
            _context = context;
        }
        public IQueryable<T> FindAll()
        {
            return _context.Set<T>()
                .AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition)
        {
            return _context.Set<T>()
                .Where(condition)
                .AsNoTracking();
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
