using LibrarySystem.Dto;
using LibrarySystem.Models;
using MediatR;
namespace LibrarySystem.Queries.OrderQueries
{
    public class GetOrdersByOrderIdQuery : IRequest<DisplayOutput>
    {
        public int Orderid;
        public GetOrdersByOrderIdQuery(int id)
        {
             this.Orderid = id;
        }
    }
}
