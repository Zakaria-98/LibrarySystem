using System.Linq.Expressions;

namespace LibrarySystem.Repositories
{
    public interface IBaseRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<TType>> GetAllAsync<TType>(Expression<Func<T, TType>> select) where TType : class;
        Task<T> GetByIdAsync(int id);

        Task<T> FindByIdAsync(Expression<Func<T, bool>> criteria, string[] includes = null);

        Task<TType> GetByIdAsync<TType>(Expression<Func<T, bool>> where, Expression<Func<T, TType>> select) where TType : class;


        Task<IEnumerable<TType>> GetListAsync<TType>(Expression<Func<T, bool>> where, Expression<Func<T, TType>> select) where TType : class;

        Task<T> AddAsync(T entity);

        T Update(T entity);

        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
    }
}
