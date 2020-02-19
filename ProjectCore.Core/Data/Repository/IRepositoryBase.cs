using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCore.Core.Data.Repository
{
    public interface IRepositoryBase<T>
    {
        void Add(T entity);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void Delete  (T entity);
        void DeleteMulti(List<T> entities);
        Task<T> GetByID(int id);
        IEnumerable<T> GetByCondition(Expression<Func<T, bool>> where);
        IEnumerable<T> GetByCondition(Expression<Func<T, bool>> where, string includes);
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        IEnumerable<T> GetAll(string[] includes = null);
        T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null);
        IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);
        IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> predicate, out int total, int index = 0, int size = 20, string[] includes = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        bool CheckContains(Expression<Func<T, bool>> predicate);
    }
}
