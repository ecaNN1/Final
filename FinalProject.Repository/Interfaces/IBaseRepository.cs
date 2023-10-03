using FinalProject.Core.Interfaces;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : IBaseEntity
    {
        Task Create(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
        Task<bool> Any(Expression<Func<T, bool>> expression);
        Task<T> GetDefault(Expression<Func<T, bool>> expression);
        Task<List<T>> GetDefaults(Expression<Func<T, bool>> expression);

        Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<T, TResult>> select,
                                                            Expression<Func<T, bool>> where = null,
                                                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                            Func<IQueryable<T>, IIncludableQueryable<T, object>> join = null);

        Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<T, TResult>> select,
                                                    Expression<Func<T, bool>> where = null,
                                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                    Func<IQueryable<T>, IIncludableQueryable<T, object>> join = null);
    }
}
