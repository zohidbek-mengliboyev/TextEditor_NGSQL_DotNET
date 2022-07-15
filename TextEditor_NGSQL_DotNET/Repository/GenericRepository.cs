﻿using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq.Expressions;
using TextEditor_NGSQL_DotNET.Context;
using TextEditor_NGSQL_DotNET.IRepository;
using ILogger = Serilog.ILogger;

namespace TextEditor_NGSQL_DotNET.Repository
{
#pragma warning disable
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal TxtEditorDbContext dbContext;
        internal DbSet<T> dbSet;
        private readonly ILogger logger;

        public GenericRepository(TxtEditorDbContext dbContext, ILogger logger)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
            this.logger = logger;
        }

        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                var entry = await dbSet.AddAsync(entity);

                return entry.Entity;
            }
            catch (Exception ex)
            {
                Log.Error("Error creating entity {0}", ex.Message);
                throw;
            }
        }

        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                var entity = await dbSet.FirstOrDefaultAsync(expression);

                if (entity is null)
                    return false;

                dbSet.Remove(entity);

                return true;
            }
            catch (Exception ex)
            {
                Log.Error("Error in DeleteAsync: {0}", ex.Message);
                throw;
            }
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {

            try
            {
                return expression is null ? dbSet : dbSet.Where(expression);
            }
            catch (Exception ex)
            {
                Log.Error("Error in Getall: {0}", ex.Message);
                throw;
            }
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                var entity = await dbSet.FirstOrDefaultAsync(expression);
                return entity;
            }
            catch (Exception ex)
            {
                Log.Error("Error in GetAsync: {0}", ex.Message);
                throw;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var entry = dbSet.Update(entity);

                return entry.Entity;
            }
            catch (Exception ex)
            {
                Log.Error("Error in UpdateAsync: {0}", ex.Message);
                throw;
            }
        }
    }
}
