using CentiroHomeAssignment.Shared.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CentiroHomeAssignment.Data.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {

        /// <summary>
        /// General Db functions for all classes
        /// </summary>
        protected readonly CentiroHomeAssignmentDbContext _CentiroHomeAssignmentDbContext;

        public BaseRepository(CentiroHomeAssignmentDbContext centiroHomeAssignmentDbContext)
        {
            _CentiroHomeAssignmentDbContext=centiroHomeAssignmentDbContext;
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _CentiroHomeAssignmentDbContext.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Returns list of all the objects of one type
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _CentiroHomeAssignmentDbContext.Set<T>().ToListAsync();
        }



        public async Task<T> AddAsync(T entity)
        {
            await _CentiroHomeAssignmentDbContext.Set<T>().AddAsync(entity);
            await _CentiroHomeAssignmentDbContext.SaveChangesAsync();

            return entity;
        }

        public T Add(T entity)
        {
            _CentiroHomeAssignmentDbContext.Set<T>().Add(entity);
            _CentiroHomeAssignmentDbContext.SaveChanges();

            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _CentiroHomeAssignmentDbContext.Set<T>().AddRangeAsync(entities);
            await _CentiroHomeAssignmentDbContext.SaveChangesAsync();

            return entities;
        }

        public async Task UpdateAsync(T entity)
        {
            _CentiroHomeAssignmentDbContext.Update(entity).State = EntityState.Modified;
            await _CentiroHomeAssignmentDbContext.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            _CentiroHomeAssignmentDbContext.UpdateRange(entities);
            await _CentiroHomeAssignmentDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _CentiroHomeAssignmentDbContext.Set<T>().Remove(entity);
            await _CentiroHomeAssignmentDbContext.SaveChangesAsync();
        }
    }
}
