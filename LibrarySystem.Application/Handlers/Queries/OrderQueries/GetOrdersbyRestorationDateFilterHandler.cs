using LibrarySystem.Dto;
using LibrarySystem.Models;
using LibrarySystem.Queries.OrderQueries;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Queries.OrderQueries
{
    public class GetOrdersbyRestorationDateFilterHandler : IRequestHandler<GetOrdersbyRestorationDateFilterQuery, IEnumerable<DisplayOutput>>
    {
        private readonly IUnitOfWork _unitofwork;

        public GetOrdersbyRestorationDateFilterHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<IEnumerable<DisplayOutput>> Handle(GetOrdersbyRestorationDateFilterQuery request, CancellationToken cancellationToken)
        {
            var orders = await _unitofwork.Orders.GetListOrdersAsync(
                o => (DateTime.Compare(request.date1, o.RestorationDate) <= 0
                && DateTime.Compare(request.date2, o.RestorationDate) >= 0));




            return orders;
        }
    }
}
