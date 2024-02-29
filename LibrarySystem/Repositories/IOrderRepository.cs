using LibrarySystem.Dto;
using LibrarySystem.Models;
using System.Linq.Expressions;

namespace LibrarySystem.Repositories
{
    public interface IOrderRepository:IBaseRepository<Order>
    {
        Task<IEnumerable<DisplayOutput>> GetAllOrdersAsync();

        Task<IEnumerable<DisplayOutput>> GetListOrdersAsync(Expression<Func<Order, bool>> where);

        Task<DisplayOutput> GetByIdOrderAsync(int id);
    }
}
