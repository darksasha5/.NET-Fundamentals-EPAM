﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ClassLibrary.BL.Interfaces;
using ClassLibrary.BL.Interfaces.Repositories;
using ClassLibrary.BL.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ClassLibrary.BL.Services
{
    public abstract class EfService<TEntity, TRepository> : IAsyncService<TEntity>
        where TEntity : class, IEntity
        where TRepository : IAsyncRepository<TEntity>
    {
        protected readonly TRepository repository;
        private readonly ILogger<EfService<TEntity, TRepository>> logger;

        protected EfService(TRepository repository, ILogger<EfService<TEntity, TRepository>> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            try
            {
                return await repository.AddAsync(entity);
            }
            catch (DbUpdateException ex)
            {
                logger.LogError(ex, "Adding entity of type {0} caused an error", typeof(TEntity));
                throw; //TODO Custom exception?
            }
        }

        public async Task<TEntity> DeleteAsync(int id)
        {
            try
            {
                return await repository.DeleteAsync(id);
            }
            catch (DbUpdateException ex)
            {
                logger.LogError(ex, "Deleting entity of type {0} caused an error", typeof(TEntity));
                throw; //TODO Custom exception?
            }
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }
        
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            try
            {
                return await repository.UpdateAsync(entity);
            }
            catch (DbUpdateException ex)
            {
                logger.LogError(ex, "Updating entity of type {0} caused an error", typeof(TEntity));
                throw; //TODO Custom exception?
            }
        }
        
        public async Task<int> CountAsync()
        {
            return await repository.CountAsync();
        }
        
        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }
            
            return await repository.CountAsync(predicate);
        }
        
        public async Task<double> AverageAsync(Expression<Func<TEntity, bool>> wherePredicate, Expression<Func<TEntity, double>> averageSelector)
        {
            if (wherePredicate == null)
            {
                throw new ArgumentNullException(nameof(wherePredicate));
            }
            
            if (averageSelector == null)
            {
                throw new ArgumentNullException(nameof(averageSelector));
            }
            
            return await repository.AverageAsync(wherePredicate, averageSelector);
        }
    }
}