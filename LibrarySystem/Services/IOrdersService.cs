using LibrarySystem.Dto;
using LibrarySystem.Models;

namespace LibrarySystem.Services
{
    public interface IOrdersService
    {
        Task<IEnumerable<OrdersListDto>> GetAllOrders();

        Task<Order> GetOrdersByOrderId(int Orderid);

        Task<IEnumerable<OrdersListDto>> GetOrderslate();

        Task<IEnumerable<OrdersListDto>> GetOrdersbyOrderDateFilter(DateTime date1, DateTime date2);

        Task<IEnumerable<OrdersListDto>> GetOrdersbyRestorationDateFilter(DateTime date1, DateTime date2);

        Task<IEnumerable<OrdersListDto>> GetOrdersByMemberId( int MemberId);

        Task<IEnumerable<OrdersListDto>> GetOrdersByBookId(int BookId);
        Task<bool> AddOrder(OrderDto dto, List<ItemsDto> dto2);

        Task<bool> UpdateOrder(int id, EditOrderDto dto, List<ItemsDto> dto2);

        Task<bool> DeleteOrder(int id);

        Task<bool> IsOrderRestored(int id);
    }
}
