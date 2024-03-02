using LibrarySystem.Dto;
using LibrarySystem.Models;
using LibrarySystem.Queries.OrderQueries;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Queries.OrderQueries
{
    public class GetOrdersByOrderIdHandler : IRequestHandler<GetOrdersByOrderIdQuery, DisplayOutput>
    {
        private readonly IUnitOfWork _unitofwork;

        public GetOrdersByOrderIdHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<DisplayOutput> Handle(GetOrdersByOrderIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _unitofwork.Orders.GetByIdOrderAsync(request.Orderid);




            return orders;
        }
    }
}
