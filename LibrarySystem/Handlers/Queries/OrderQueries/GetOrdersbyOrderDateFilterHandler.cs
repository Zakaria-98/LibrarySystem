using LibrarySystem.Dto;
using LibrarySystem.Models;
using LibrarySystem.Queries.OrderQueries;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Queries.OrderQueries
{
    public class GetOrdersbyOrderDateFilterHandler : IRequestHandler<GetOrdersbyOrderDateFilterQuery, IEnumerable<DisplayOutput>>
    {
        private readonly IUnitOfWork _unitofwork;

        public GetOrdersbyOrderDateFilterHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<IEnumerable<DisplayOutput>> Handle(GetOrdersbyOrderDateFilterQuery request, CancellationToken cancellationToken)
        {
            var orders = await _unitofwork.Orders.GetListOrdersAsync(
                o => 
                (DateTime.Compare(request.date1, o.OrderDate) <= 0 
                && DateTime.Compare(request.date2, o.OrderDate) >= 0));




            return orders;
        }
    }
}
