using Microsoft.EntityFrameworkCore;
using ProjectCore.Core.Data.Repository;
using ProjectCore.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCore.Data.Repository
{
    public class RepositoryBase<T>:IRepositoryBase<T> where T:class
    {
        private ApplicationDbContext _DbContext;

        public RepositoryBase(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }
        public virtual void Add(T entity) => _DbContext.Set<T>().Add(entity);
        public virtual async Task AddAsync(T entity) => await _DbContext.Set<T>().AddAsync(entity);
        public virtual async Task AddRangeAsync(IEnumerable<T> entities) => await _DbContext.Set<T>().AddRangeAsync(entities);
       
        public virtual void Update(T entity)
        {
            _DbContext.Attach(entity);
            _DbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            _DbContext.Remove(entity);
        }

        public virtual void DeleteMulti(List<T> entities)
        {
            _DbContext.Set<T>().RemoveRange(entities);
        }

        public virtual async Task<T> GetByID(int id) => await _DbContext.Set<T>().FindAsync(id);

        public virtual IEnumerable<T> GetByCondition(Expression<Func<T, bool>> where) => _DbContext.Set<T>().Where(where).ToList();
        public virtual IEnumerable<T> GetByCondition(Expression<Func<T, bool>> where, string includes) => _DbContext.Set<T>().Where(where).ToList();

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _DbContext.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public IEnumerable<T> GetAll(string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = _DbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.AsQueryable();
            }

            return _DbContext.Set<T>().AsQueryable();
        }

        public T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = _DbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.FirstOrDefault(expression);
            }
            return _DbContext.Set<T>().FirstOrDefault(expression);
        }

        public virtual IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = _DbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.Where<T>(predicate).AsQueryable<T>();
            }

            return _DbContext.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }

        public virtual IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> predicate,  out int total, int index = 1, int size = 10, string[] includes = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            int skipCount = (index-1) * size;
            IQueryable<T> _resetSet;

            if (includes != null && includes.Count() > 0)
            {
                var query = _DbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                _resetSet = predicate != null ? query.Where<T>(predicate).AsQueryable() : query.AsQueryable();
            }
            else
            {
                _resetSet = predicate != null ? _DbContext.Set<T>().Where<T>(predicate).AsQueryable() : _DbContext.Set<T>().AsQueryable();
            }

            total = _resetSet.Count();
            if (orderBy != null)
            {
               return skipCount == 0 ? orderBy(_resetSet).Take(size) : orderBy(_resetSet).Skip(skipCount).Take(size); 
            }
          
            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            return _resetSet.AsQueryable().AsNoTracking();
        }

        public bool CheckContains(Expression<Func<T, bool>> predicate)
        {
            return _DbContext.Set<T>().Count<T>(predicate) > 0;
        }
    }
}
