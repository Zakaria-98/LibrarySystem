using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace LibrarySystem.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _context.Set<T>().ToListAsync();

            return result;

        }

        public async Task<IEnumerable<TType>> GetAllAsync<TType>( Expression<Func<T, TType>> select) where TType : class
        {
            var result = await _context.Set<T>().Select(select).ToListAsync();
            if (result == null)
                return null;

            return result;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await  _context.Set<T>().FindAsync(id);

            return result;
        }

        public async Task<T> FindByIdAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var incluse in includes)
                    query = query.Include(incluse);

            return await query.SingleOrDefaultAsync(criteria);
        }

        public async Task<TType> GetByIdAsync<TType>(Expression<Func<T, bool>> where, Expression<Func<T, TType>> select) where TType : class
        {
            var result = await _context.Set<T>().Where(where).Select(select).FirstAsync(); 
            if (result == null)
                return null;

            return result;
        }

        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> where) 
        {
            var result = await _context.Set<T>().Where(where).ToListAsync();
            if (result == null)
                return null;

            return result;
        }


        public async Task<IEnumerable<TType>> GetListAsync<TType>(Expression<Func<T, bool>> where, Expression<Func<T, TType>> select) where TType : class
        {
            var result = await _context.Set<T>().Where(where).Select(select).ToListAsync();
            if (result == null)
                return null;

            return result;
        }



        public async Task<T> AddAsync(T entity)
        {
             var result = await _context.Set<T>().AddAsync(entity);

            return entity;

        }

        public  T Update(T entity)
        {
             _context.Update(entity);

            return entity;

        }

        public void Delete(T entity)
        {
            _context.Remove(entity);

        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _context.RemoveRange(entities);
        }


    }
}
