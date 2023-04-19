using Data.Context;
using Data.Repositories.Interfaces;
using Data.Models.Public;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        #region Protectetd

        protected readonly DbContext _context;
        internal readonly DbSet<T> _dbSet;

        #endregion Protectetd

        #region Properties

        public IQueryable<T> Table
        {
            get { return _dbSet; }
        }

        #endregion Properties

        #region Ctor

        public BaseRepository(GargarContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        #endregion Ctor

        #region Methods

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(params object[] key)
        {
            var entity = await _dbSet.FindAsync(key);
            if (entity is null)
            {
                throw new Exception("Entiti not found");
            }
            return entity;
        }

        public async Task CreateAsync(T entity, string userId)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));
            var now = DateTime.UtcNow;
            entity.CreatedBy = userId;
            entity.UpdatedBy = userId;
            entity.CreatedOn = now;
            entity.UpdatedOn = now;
            await _dbSet.AddAsync(entity);
            await Save();

        }

        public async Task RemoveAsync(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));
            _dbSet.Remove(entity);
            await Save();
        }

        public async Task UpdateAsync(T updated, string userId)
        {
            if (updated == null)
                throw new ArgumentNullException(nameof(updated));
            _dbSet.Update(updated);
            await Save();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        #endregion 

        public async Task Save() => await _context.SaveChangesAsync();
    }
}