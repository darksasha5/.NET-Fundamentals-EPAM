﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ClassLibrary.BL.Interfaces.Services
{
    public interface IAsyncService<T> where T : class, IEntity
    {
        Task<List<T>> GetAllAsync(); // TODO IReadOnlyList?
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(int id);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        Task<double> AverageAsync(Expression<Func<T, bool>> wherePredicate,
            Expression<Func<T, double>> averageSelector);
    }
}
