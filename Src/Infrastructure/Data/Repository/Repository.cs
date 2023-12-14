using Core;
using Core.Entities;
using Domain;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, 
        IAggregateRoot
    {
        private readonly DataBaseContext _context;

        public Repository(DataBaseContext dataBaseContext)
        {
            _context = dataBaseContext;
        }

        /// <summary>
        /// soft delete
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public async Task Delete(TEntity entity) 
        {
            if(entity == null) throw new ArgumentNullException(nameof(entity));
            var val = await _context.Set<TEntity>().SingleOrDefaultAsync(x=>x.Id == entity.Id);
            if (val == null) throw new ArgumentException("شی یافت نشد");
            val.Delete();
            _context.Update(val);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> Get(int id)
        {
            return await _context.Set<TEntity>().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().AsQueryable().ToListAsync();
            //return entities.AsEnumerable();
        }

        public async Task Insert(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync(); //
        }

        public async Task SaveChages()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
