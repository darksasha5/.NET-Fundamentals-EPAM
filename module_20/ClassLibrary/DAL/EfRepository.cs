﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ClassLibrary.BL.Interfaces;
using ClassLibrary.BL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.DAL
{
    public abstract class EfRepository<TEntity, TContext> : IAsyncRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        protected readonly TContext context;

        protected EfRepository(TContext context)
        {
            this.context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> DeleteAsync(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);

            if (entity == null)
            {
                return null;
            }

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }
        
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<int> CountAsync()
        {
            return await context.Set<TEntity>().CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().CountAsync(predicate);
        }

        public async Task<double> AverageAsync(Expression<Func<TEntity, bool>> wherePredicate, Expression<Func<TEntity, double>> averageSelector)
        {
            return await context.Set<TEntity>().Where(wherePredicate).AverageAsync(averageSelector);
        }
    }
}