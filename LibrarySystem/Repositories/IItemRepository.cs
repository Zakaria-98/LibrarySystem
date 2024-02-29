using LibrarySystem.Dto;
using LibrarySystem.Models;
using System.Linq.Expressions;

namespace LibrarySystem.Repositories
{
    public interface IItemRepository : IBaseRepository<Item>
    {
        Task<IEnumerable<DisplayOutput>> GetListOrdersAsync(Expression<Func<Item, bool>> where);

    }
}
