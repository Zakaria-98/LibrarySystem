using LibrarySystem.Dto;
using LibrarySystem.Models;
using LibrarySystem.Queries.OrderQueries;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Queries.OrderQueries
{
    public class GetOrdersByBookIdHandler : IRequestHandler<GetOrdersByBookIdQuery, IEnumerable<DisplayOutput>>
    {
        private readonly IUnitOfWork _unitofwork;

        public GetOrdersByBookIdHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<IEnumerable<DisplayOutput>> Handle(GetOrdersByBookIdQuery request, CancellationToken cancellationToken)
        {
            var Book = await _unitofwork.Books.GetByIdAsync(request.BookId);
            if (Book == null)
                return null;

            var orders = await _unitofwork.Items.GetListOrdersAsync(o => o.BookId == request.BookId);


            return orders;
        }
    }
}
