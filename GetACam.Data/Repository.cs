using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GetACam.Data
{
    public class Repository<T> :  IRepository<T>
        where T : class
    {
        private readonly GetACamContext _getACamContext;
        private readonly DbSet<T> _dbSet;

        public Repository(GetACamContext getACamContext)
        {
            _getACamContext = getACamContext;
            _dbSet = getACamContext.Set<T>();
        }

        public async void Add(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).AsQueryable();
        }

        public IQueryable<T> Query()
        {
            return _dbSet.AsQueryable();
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _getACamContext.Entry(entity).State = EntityState.Modified;
        }
        
    }
}
