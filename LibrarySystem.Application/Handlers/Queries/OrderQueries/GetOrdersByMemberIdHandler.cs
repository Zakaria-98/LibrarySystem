using LibrarySystem.Dto;
using LibrarySystem.Models;
using LibrarySystem.Queries.OrderQueries;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Queries.OrderQueries
{
    public class GetOrdersByMemberIdHandler : IRequestHandler<GetOrdersByMemberIdQuery, IEnumerable<DisplayOutput>>
    {
        private readonly IUnitOfWork _unitofwork;

        public GetOrdersByMemberIdHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<IEnumerable<DisplayOutput>> Handle(GetOrdersByMemberIdQuery request, CancellationToken cancellationToken)
        {
            var Member = await _unitofwork.Members.GetByIdAsync(request.MemberId);
            if (Member == null)
                return null;

            var orders = await _unitofwork.Orders.GetListOrdersAsync(
                o => o.MemberId == request.MemberId);
                

            return orders;
        }
    }
}
