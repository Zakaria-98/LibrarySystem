using LibrarySystem.Dto;
using LibrarySystem.Models;
using LibrarySystem.Queries.OrderQueries;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Queries.OrderQueries
{
    public class GetOrderslateHandler : IRequestHandler<GetOrderslateQuery, IEnumerable<DisplayOutput>>
    {
        private readonly IUnitOfWork _unitofwork;

        public GetOrderslateHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<IEnumerable<DisplayOutput>> Handle(GetOrderslateQuery request, CancellationToken cancellationToken)
        {
            var orders = await _unitofwork.Orders.GetListOrdersAsync(
                o => (DateTime.Compare(o.RestorationDate, DateTime.Now) < 0 
                && o.Restoration.RestorationDate == null));



            return orders;
        }
    }
}
