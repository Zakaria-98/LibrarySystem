using LibrarySystem.Dto;
using LibrarySystem.Models;

namespace LibrarySystem.Services
{
    public interface IOrdersService
    {
        Task<IEnumerable<DisplayOutput>> GetAllOrders();

        Task<DisplayOutput> GetOrdersByOrderId(int Orderid);

        Task<IEnumerable<DisplayOutput>> GetOrderslate();

        Task<IEnumerable<DisplayOutput>> GetOrdersbyOrderDateFilter(DateTime date1, DateTime date2);

        Task<IEnumerable<DisplayOutput>> GetOrdersbyRestorationDateFilter(DateTime date1, DateTime date2);

        Task<IEnumerable<DisplayOutput>> GetOrdersByMemberId( int MemberId);

        Task<IEnumerable<DisplayOutput>> GetOrdersByBookId(int BookId);
        Task<bool> AddOrder(OrderDto dto, List<ItemsDto> dto2);

        Task<bool> UpdateOrder(int id, EditOrderDto dto, List<ItemsDto> dto2);

        Task<bool> DeleteOrder(int id);

        Task<bool> IsOrderRestored(int id);
    }
}
